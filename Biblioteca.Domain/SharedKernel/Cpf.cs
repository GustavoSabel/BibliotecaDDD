using Biblioteca.Domain.Common;
using System;
using System.Text.RegularExpressions;

namespace Biblioteca.Domain.SharedKernel
{
    public class Cpf : ValueObject<Cpf>
    {
        public Cpf(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new ArgumentException("CPF não informado", nameof(valor));

            valor = ObterApenasNumeros(valor);

            if (valor.Length != 11)
                throw new Exception($"CPF {valor} inválido");

            Valor = valor;
            ValorFormatado = long.Parse(valor).ToString(@"000\.000\.000-00");
        }

        private static string ObterApenasNumeros(string valor)
        {
            valor = Regex.Replace(valor, @"[^\d]", "");
            return valor;
        }

        public string Valor { get; }
        public string ValorFormatado { get; }

        protected override bool EqualsCore(Cpf other)
        {
            return other.Valor == other.Valor;
        }

        protected override int GetHashCodeCore()
        {
            return Valor.GetHashCode();
        }
    }
}
