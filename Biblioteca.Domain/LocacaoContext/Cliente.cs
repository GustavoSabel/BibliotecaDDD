using Biblioteca.Domain.Common;
using Biblioteca.Domain.SharedKernel;
using System;

namespace Biblioteca.Domain.LocacaoContext
{
    public class Cliente : AggregateRoot
    {
        public const int NomeTamanhoMax = 300;

        protected Cliente()
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

        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public Cpf Cpf { get; private set; }
    }
}
