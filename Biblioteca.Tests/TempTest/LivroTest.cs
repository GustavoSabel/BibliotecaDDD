﻿using Biblioteca.Domain.LivroContext;
using FluentAssertions;
using Xunit;

namespace Biblioteca.Tests.TempTest
{
    public class LivroTest : EFTest
    {
        [Fact]
        public void Livro()
        {
            var autor = new Autor("Teste", new System.DateTime(2000, 1, 1));
            var livro = new Livro("Titulo", "Subtitulo", 2000, new[] { autor });

            _dbContext.Set<Autor>().Add(autor);
            _dbContext.Set<Livro>().Add(livro);
            _dbContext.SaveChanges();

            var livroObtido = _dbContext.Set<Livro>().Find(livro.Id);

            livroObtido.Should().Be(livro);

            //var dbContext2 = CriarDbContext();
            //var livro2 = dbContext2.Set<Livro>().Find(livro.Id);
            //livro2.AddAutor(autor);
        }
    }
}
