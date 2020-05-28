using Microsoft.EntityFrameworkCore;
using System;
using System.Net.Mail;
using System.Reflection;

namespace Biblioteca.Infra
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(
        //        @"Server=.;Database=Biblioteca;Integrated Security=True");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            Seed(modelBuilder);
        }

        private static void Seed(ModelBuilder modelBuilder)
        {
            var semData = new DateTime(1900, 1, 1);
            var autorRobertCecilmartin = new Domain.LivroContext.Autor("Robert Cecil Martin", new DateTime(1952, 12, 5)) { Id = 1 };
            var autorEricEvans = new Domain.LivroContext.Autor("Eric Evans", semData) { Id = 2 };
            var autorVaughnVernon = new Domain.LivroContext.Autor("Vaughn Vernon", semData) { Id = 3 };
            var autor4 = new Domain.LivroContext.Autor("Erich Gamma", new DateTime(1961, 1, 1)) { Id = 4 };
            var autor5 = new Domain.LivroContext.Autor("John Vlissides", semData) { Id = 5 };
            var autor6 = new Domain.LivroContext.Autor("Richard Helm", semData) { Id = 6 };
            var autor7 = new Domain.LivroContext.Autor("Ralph Johnson", semData) { Id = 7 };

            modelBuilder.Entity<Domain.LivroContext.Autor>().HasData(
                autorRobertCecilmartin,
                autorEricEvans,
                autorVaughnVernon,
                autor4,
                autor5,
                autor6,
                autor7
            );

            var livros = new[] { 
                new Domain.LivroContext.Livro("Agile Software Development, Principles, Patterns, and Practices", null, 2002, new[] { autorRobertCecilmartin }) { Id = 1 },
                new Domain.LivroContext.Livro("Clean Code", "A Handbook of Agile Software Craftsmanship", 2009, new[] { autorRobertCecilmartin }) { Id = 2 },
                new Domain.LivroContext.Livro("The Clean Coder", "A Code Of Conduct For Professional Programmers", 2011, new[] { autorRobertCecilmartin }) { Id = 3 },
                new Domain.LivroContext.Livro("Clean Architecture", "A Craftsman's Guide to Software Structure and Design", 2017, new[] { autorRobertCecilmartin }) { Id = 4 },
                new Domain.LivroContext.Livro("Clean Agile", "Back to Basics", 2019, new[] { autorRobertCecilmartin }) { Id = 5 },
                new Domain.LivroContext.Livro("Domain-Driven Design", "Tackling Complexity in the Heart of Software", 2003, new[] { autorEricEvans }) { Id = 6 },
                new Domain.LivroContext.Livro("Implementing Domain-Driven Design", null, 2013, new[] { autorVaughnVernon }) { Id = 7 },
                new Domain.LivroContext.Livro("Domain-Driven Design Distilled", null, 2016, new[] { autorVaughnVernon }) { Id = 8 }
            };

            int idLivroAutor = 0;
            foreach (var livro in livros)
            {
                modelBuilder.Entity<Domain.LivroContext.Livro>().HasData(new
                {
                    livro.Id,
                    Serial = livro.Id.ToString().PadLeft(10, '0'),
                    livro.Titulo,
                    livro.SubTitulo,
                    livro.Ano,
                    livro.Descricao,
                    livro.Situacao
                });

                foreach (var a in livro.Autores)
                {
                    modelBuilder.Entity<Domain.LivroContext.LivroAutor>().HasData(new { 
                        Id = ++idLivroAutor,
                        AutorId = a.Autor.Id,
                        LivroId = livro.Id,
                    });
                }
            }
        }
    }
}
