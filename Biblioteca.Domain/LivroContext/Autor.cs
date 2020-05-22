using Biblioteca.Domain.Common;
using System;

namespace Biblioteca.Domain.LivroContext
{
    public class Autor : AggregateRoot
    {
        public const int TamanhoMaxNome = 300;

        public Autor(string nome, DateTime dataNascimento)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Validar();
        }

        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }

        public void SetDataNascimento(DateTime dataNascimento)
        {
            DataNascimento = dataNascimento;
            Validar();
        }

        public void SetNome(string nome)
        {
            Nome = nome;
            Validar();
        }

        private void Validar()
        {
            if (string.IsNullOrWhiteSpace(Nome))
                throw new InvalidEntityException("Nome do autor é obrigatório");

            if (Nome.Length > TamanhoMaxNome)
                throw new InvalidEntityException($"Nome deve ter menos de {TamanhoMaxNome} caracteres. Foi informado {Nome.Length}");

            if (DataNascimento.Year > DateTime.Now.Year)
                throw new InvalidEntityException("Data de nascimento inválida");
        }
    }
}
