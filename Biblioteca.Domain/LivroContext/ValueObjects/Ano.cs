using Biblioteca.Domain.Common;
using System;

namespace Biblioteca.Domain.LivroContext.ValueObjects
{
    public class Ano : ValueObject<Ano>
    {
        public Ano(int valor)
        {
            if (valor < -5000)
                throw new InvalidEntityException("Ano não pode ser menor que -5000");

            if (valor > DateTime.Now.Year)
                throw new InvalidEntityException($"Ano não pode ser maior que {DateTime.Now.Year}");

            Valor = valor;
        }

        public int Valor { get; }

        protected override bool EqualsCore(Ano other) => Valor == other.Valor;

        protected override int GetHashCodeCore() => Valor.GetHashCode();

        public static implicit operator int(Ano ano) => ano.Valor;
        public static implicit operator Ano(int ano) => new Ano(ano);
    }
}
