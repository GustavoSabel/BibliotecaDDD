using Biblioteca.Domain.LivroContext;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace Biblioteca.Tests.LivroContexto
{
    public class LivroTest
    {
        private readonly Autor _autor1;

        public LivroTest()
        {
            _autor1 = new Autor("Robert Cecil Martin", new DateTime(2000, 1, 1));
        }

        [Fact]
        public void Criar()
        {
            var livro = new Livro(new Domain.LivroContext.ValueObjects.Titulo("Clean Code", null), null, 2013, Estado.Bom,new List<Autor>() { _autor1 });
            livro.Titulo.ToString().Should().Be("Clean Code");
            livro.Autores.Should().HaveCount(1).And.Contain(x => x.Autor.Nome == _autor1.Nome);
        }

        [Fact]
        public void Criar_sem_autor()
        {
            var act = new Action(() => new Livro(new Domain.LivroContext.ValueObjects.Titulo("Clean Code", null), null, 2013, Estado.Bom, new List<Autor>()));
            act.Should().Throw<Exception>().Which.Message.Contains("autor");
        }
    }
}
