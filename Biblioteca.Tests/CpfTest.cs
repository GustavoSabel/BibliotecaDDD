using Biblioteca.Domain.SharedKernel;
using FluentAssertions;
using System;
using Xunit;

namespace Biblioteca.Tests
{
    public class CpfTest
    {
        [Fact]
        public void Criar_cpf()
        {
            var cpf = new Cpf("12345678912");
            cpf.Valor.Should().Be("12345678912");
            cpf.ValorFormatado.Should().Be("123.456.789-12");
        }

        [Fact]
        public void Cpf_em_branco()
        {
            var criarCpf = new Action(() => new Cpf(""));
            criarCpf
                .Should().Throw<Exception>().Which.Message
                .Should().Contain("não informado");
        }

        [Fact]
        public void Cpf_null()
        {
            var criarCpf = new Action(() => new Cpf(null));
            criarCpf
                .Should().Throw<Exception>().Which.Message
                .Should().Contain("não informado");
        }

        [Fact]
        public void Cpf_com_10_caracteres()
        {
            var criarCpf = new Action(() => new Cpf("1111111111"));
            criarCpf
                .Should().Throw<Exception>().Which.Message
                .Should().Contain("CPF").And.Contain("inválido");
        }

        [Fact]
        public void Cpf_com_12_caracteres()
        {
            var criarCpf = new Action(() => new Cpf("1111111111"));
            criarCpf
                .Should().Throw<Exception>().Which.Message
                .Should().Contain("CPF").And.Contain("inválido");
        }
    }
}
