using Biblioteca.Domain.LivroContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Biblioteca.Infra
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options) { }

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

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Estado)
                    entry.State = EntityState.Unchanged;
            }

            return base.SaveChangesAsync(cancellationToken);
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
