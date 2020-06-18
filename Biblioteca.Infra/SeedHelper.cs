using Biblioteca.Domain.LivroContext;
using Biblioteca.Domain.LivroContext.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Infra
{
    class SeedHelper
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var semData = new DateTime(1900, 1, 1);

            var autorRobertCecilmartin = new Autor("Robert Cecil Martin", new DateTime(1952, 12, 5));
            var autorEricEvans = new Autor("Eric Evans", semData);
            var autorVaughnVernon = new Autor("Vaughn Vernon", semData);
            var autor4 = new Autor("Erich Gamma", new DateTime(1961, 1, 1));
            var autor5 = new Autor("John Vlissides", semData);
            var autor6 = new Autor("Richard Helm", semData);
            var autor7 = new Autor("Ralph Johnson", semData);

            int idAutor = 0;
            var listaAutores = new List<(int id, Autor autor)>()
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
                modelBuilder.Entity<Autor>().HasData(new
                {
                    Id = autor.id,
                    autor.autor.Nome,
                    autor.autor.DataNascimento
                });
            }

            foreach (var estado in Estado.Listar())
            {
                modelBuilder.Entity<Estado>().HasData(estado);
            }

            var livros = new[] {
                new Livro(new Titulo("Agile Software Development, Principles, Patterns, and Practices", null), null, 2002,
                    Estado.Otimo, new[] { autorRobertCecilmartin }),

                new Livro(new Titulo("Clean Code", "A Handbook of Agile Software Craftsmanship"), null, 2009,
                    Estado.Otimo, new[] { autorRobertCecilmartin }),

                new Livro(new Titulo("The Clean Coder", "A Code Of Conduct For Professional Programmers"), null, 2011,
                    Estado.Ruim, new[] { autorRobertCecilmartin }),

                new Livro(new Titulo("Clean Architecture", "A Craftsman's Guide to Software Structure and Design"), null, 2017,
                    Estado.Bom, new[] { autorRobertCecilmartin }),

                new Livro(new Titulo("Clean Agile", "Back to Basics"), null, 2019,
                    Estado.Otimo, new[] { autorRobertCecilmartin }),

                new Livro(new Titulo("Domain-Driven Design", "Tackling Complexity in the Heart of Software"), null, 2003,
                    Estado.Ruim, new[] { autorEricEvans }),

                new Livro(new Titulo("Implementing Domain-Driven Design", null), null, 2013,
                    Estado.Bom, new[] { autorVaughnVernon }),

                new Livro(new Titulo("Domain-Driven Design Distilled", null), null, 2016,
                    Estado.Ruim, new[] { autorVaughnVernon })
            };

            int idLivro = 0;
            int idLivroAutor = 0;
            foreach (var livro in livros)
            {
                modelBuilder.Entity<Livro>().HasData(new
                {
                    Id = ++idLivro,
                    Serial = idLivro.ToString().PadLeft(10, '0'),
                    livro.Ano,
                    livro.Descricao,
                    livro.Situacao,
                    EstadoId = livro.Estado.Id
                });

                modelBuilder.Entity<Livro>().OwnsOne(x => x.Titulo).HasData(new
                {
                    LivroId = idLivro,
                    livro.Titulo.Principal,
                    livro.Titulo.SubTitulo,
                });

                foreach (var a in livro.Autores)
                {
                    modelBuilder.Entity<LivroAutor>().HasData(new
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
