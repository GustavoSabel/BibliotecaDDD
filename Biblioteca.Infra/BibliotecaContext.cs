using Biblioteca.Domain.Common;
using Biblioteca.Domain.LivroContext;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Biblioteca.Infra
{
    public class BibliotecaContext : DbContext
    {
        private readonly IMediator _mediator;

        public BibliotecaContext(DbContextOptions<BibliotecaContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            foreach (var property in modelBuilder.Model.GetEntityTypes()
               .SelectMany(t => t.GetProperties())
               .Where(p => p.ClrType == typeof(string)))
            {
                if (property.GetColumnType() == null)
                {
                    var maxLenght = property.GetMaxLength();
                    if (maxLenght != null)
                        property.SetColumnType($"varchar({maxLenght.Value})");
                    else
                        property.SetColumnType("varchar(100)");
                }
            }

            foreach (var property in modelBuilder.Model.GetEntityTypes()
               .SelectMany(t => t.GetProperties())
               .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                if (property.GetColumnType() == null)
                    property.SetColumnType("decimal(13,4)");
            }

            Seed(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries().Where(x => x.Entity is Entity).ToList();

            foreach (var entry in entries)
            {
                if (entry.Entity is Estado)
                    entry.State = EntityState.Unchanged;
            }

            var resultado = await base.SaveChangesAsync(cancellationToken);

            await DispatchDomainEvents(entries, cancellationToken);

            return resultado;
        }

        private async Task DispatchDomainEvents(List<Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry> entries, CancellationToken cancellationToken)
        {
            var domainEvents = new List<IDomainEvent>();
            foreach (var entry in entries)
            {
                if (entry.Entity is AggregateRoot aggregateRoot)
                {
                    domainEvents.AddRange(aggregateRoot.DomainEvents);
                    aggregateRoot.ClearEvents();
                }
            }

            foreach (var domainEvent in domainEvents)
                await _mediator.Send(domainEvent, cancellationToken);
        }

        public static void Configurar(DbContextOptionsBuilder options, string connectionString, bool ativarLog)
        {
            options
                .UseSqlServer(connectionString)
                .UseLazyLoadingProxies();

            if (ativarLog)
            {
                var logger = LoggerFactory.Create(builder =>
                {
                    builder.AddFilter((category, level) => category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information);
                    builder.AddConsole();
                });
                options
                    .UseLoggerFactory(logger)
                    .EnableSensitiveDataLogging();
            }
        }

        private static void Seed(ModelBuilder modelBuilder) => SeedHelper.Seed(modelBuilder);
    }
}
