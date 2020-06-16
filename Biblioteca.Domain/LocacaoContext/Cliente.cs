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

        public void AtualizarDados(string nome, DateTime dataNascimento)
        {
            Nome = nome;
            DataNascimento = dataNascimento;

            Validar();
        }

        private void Validar()
        {
            if (string.IsNullOrWhiteSpace(Nome))
                throw new Exception("Nome é obrigatório");

            if (Nome.Length > NomeTamanhoMax)
                throw new Exception($"Nome deve ter menos de {NomeTamanhoMax} caracteres");

            if (DataNascimento.Year > DateTime.Now.Year || DataNascimento.Year < 1800)
                throw new Exception("Data de Nascimento inválido");
        }
    }
}
