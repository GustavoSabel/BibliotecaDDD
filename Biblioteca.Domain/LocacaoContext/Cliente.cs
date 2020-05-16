using Biblioteca.Domain.Common;
using Biblioteca.Domain.SharedKernel;
using System;

namespace Biblioteca.Domain.LocacaoContext
{
    public class Cliente : AggregateRoot
    {
        private Cliente()
        {
            Nome = null!;
            Cpf = null!;
        }

        public Cliente(string nome, Cpf cpf, DateTime dataNascimento)
        {
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
        }

        public string Nome { get; }
        public DateTime DataNascimento { get; }
        public Cpf Cpf { get; }
    }
}
