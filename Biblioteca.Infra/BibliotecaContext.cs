using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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

        private static void Seed(ModelBuilder modelBuilder)
        {
            var semData = new DateTime(1900, 1, 1);

            var autorRobertCecilmartin = new Domain.LivroContext.Autor("Robert Cecil Martin", new DateTime(1952, 12, 5));
            var autorEricEvans = new Domain.LivroContext.Autor("Eric Evans", semData);
            var autorVaughnVernon = new Domain.LivroContext.Autor("Vaughn Vernon", semData);
            var autor4 = new Domain.LivroContext.Autor("Erich Gamma", new DateTime(1961, 1, 1));
            var autor5 = new Domain.LivroContext.Autor("John Vlissides", semData);
            var autor6 = new Domain.LivroContext.Autor("Richard Helm", semData);
            var autor7 = new Domain.LivroContext.Autor("Ralph Johnson", semData);

            int idAutor = 0;
            var listaAutores = new List<(int id, Domain.LivroContext.Autor autor)>()
            {
                (++idAutor, autorRobertCecilmartin),
                (++idAutor, autorEricEvans),
                (++idAutor, autorVaughnVernon),
                (++idAutor, autor4),
                (++idAutor, autor5),
                (++idAutor, autor6),
                (++idAutor, autor7),
            };

            foreach (var autor in listaAutores)
            {
                modelBuilder.Entity<Domain.LivroContext.Autor>().HasData(new
                {
                    Id = autor.id,
                    autor.autor.Nome,
                    autor.autor.DataNascimento
                });
            }

            var livros = new[] {
                new Domain.LivroContext.Livro("Agile Software Development, Principles, Patterns, and Practices", null, 2002, new[] { autorRobertCecilmartin }),
                new Domain.LivroContext.Livro("Clean Code", "A Handbook of Agile Software Craftsmanship", 2009, new[] { autorRobertCecilmartin }),
                new Domain.LivroContext.Livro("The Clean Coder", "A Code Of Conduct For Professional Programmers", 2011, new[] { autorRobertCecilmartin }),
                new Domain.LivroContext.Livro("Clean Architecture", "A Craftsman's Guide to Software Structure and Design", 2017, new[] { autorRobertCecilmartin }),
                new Domain.LivroContext.Livro("Clean Agile", "Back to Basics", 2019, new[] { autorRobertCecilmartin }),
                new Domain.LivroContext.Livro("Domain-Driven Design", "Tackling Complexity in the Heart of Software", 2003, new[] { autorEricEvans }),
                new Domain.LivroContext.Livro("Implementing Domain-Driven Design", null, 2013, new[] { autorVaughnVernon }),
                new Domain.LivroContext.Livro("Domain-Driven Design Distilled", null, 2016, new[] { autorVaughnVernon })
            };

            int idLivro = 0;
            int idLivroAutor = 0;
            foreach (var livro in livros)
            {
                modelBuilder.Entity<Domain.LivroContext.Livro>().HasData(new
                {
                    Id = ++idLivro,
                    Serial = idLivro.ToString().PadLeft(10, '0'),
                    livro.Titulo,
                    livro.SubTitulo,
                    livro.Ano,
                    livro.Descricao,
                    livro.Situacao
                });

                foreach (var a in livro.Autores)
                {
                    modelBuilder.Entity<Domain.LivroContext.LivroAutor>().HasData(new
                    {
                        Id = ++idLivroAutor,
                        AutorId = listaAutores.Single(x => x.autor == a.Autor).id,
                        LivroId = idLivro,
                    });
                }
            }
        }
    }
}
