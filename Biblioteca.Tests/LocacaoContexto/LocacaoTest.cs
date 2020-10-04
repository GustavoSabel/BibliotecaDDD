using Biblioteca.Domain.LocacaoContext;
using Biblioteca.Domain.SharedKernel;
using FluentAssertions;
using FluentAssertions.Execution;
using System;
using System.Collections.Generic;
using Xunit;

namespace Biblioteca.Tests
{
    public class LocacaoTest
    {
        private readonly Cliente _cliente;
        private readonly Livro _livro1;
        private readonly Livro _livro2;

        public LocacaoTest()
        {
            _cliente = new Cliente("Joao", new Cpf("12345678912"), new DateTime(2000, 1, 1));
            _livro1 = new Livro(1, "O nome do vento", "", "Ruim");
            _livro2 = new Livro(2, "O temor do sávio", null, "Bom");
        }

        [Fact]
        public void Alugar()
        {
            var dataLocacao = new DateTime(2020, 5, 13, 8, 45, 0);
            var dataDevolucaoEsperada = new DateTime(2020, 5, 15, 15, 31, 00);

            var locacao = new Locacao(dataLocacao, dataDevolucaoEsperada, _cliente, new List<Livro> { _livro1, _livro2 });

            using (new AssertionScope())
            {
                locacao.Livros.Should()
                    .HaveCount(2)
                    .And.Contain(x => x.Titulo == _livro1.Titulo)
                    .And.Contain(x => x.Titulo == _livro2.Titulo);

                locacao.DataLocacao.Should().Be(dataLocacao);
                locacao.DataPrevistaDevolucao.Should().Be(dataDevolucaoEsperada.Date); 
                locacao.DomainEvents.Count.Should().Be(2);
                locacao.DomainEvents[0].Should().BeOfType<LivroAlugadoEvent>().Subject.LivroId.Should().Be(_livro1.LivroId);
                locacao.DomainEvents[1].Should().BeOfType<LivroAlugadoEvent>().Subject.LivroId.Should().Be(_livro2.LivroId);
            }
        }

        [Fact]
        public void Devolver_sem_multa()
        {
            var dataLocacao = new DateTime(2020, 5, 13);
            var dataDevolucaoEsperada = new DateTime(2020, 5, 15);
            var dataDevolucao = new DateTime(2020, 5, 15, 13, 0, 0);

            var locacao = new Locacao(dataLocacao, dataDevolucaoEsperada, _cliente, new List<Livro> { _livro1 });
            locacao.Devolver(dataDevolucao);

            using (new AssertionScope())
            {
                locacao.TeveMulta.Should().BeFalse();
                locacao.DataDevolucao.Should().Be(dataDevolucao);
                locacao.DomainEvents.Count.Should().Be(2);
                locacao.DomainEvents[1].Should().BeOfType<LivroDevolvidoEvent>().Which.LivroId.Should().Be(_livro1.LivroId);
            }
        }

        [Fact]
        public void Devolver_com_multa()
        {
            var dataLocacao = new DateTime(2020, 5, 13);
            var dataDevolucaoEsperada = new DateTime(2020, 5, 15);
            var dataDevolucao = new DateTime(2020, 5, 16);

            var locacao = new Locacao(dataLocacao, dataDevolucaoEsperada, _cliente, new List<Livro> { _livro1 });
            locacao.Devolver(dataDevolucao);

            using (new AssertionScope())
            {
                locacao.TeveMulta.Should().BeTrue();
                locacao.DataDevolucao.Should().Be(dataDevolucao);
                locacao.DomainEvents.Count.Should().Be(2);
                locacao.DomainEvents[1].Should().BeOfType<LivroDevolvidoEvent>().Which.LivroId.Should().Be(_livro1.LivroId);
            }
        }
    }
}
