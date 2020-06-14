using Biblioteca.Domain.Common;

namespace Biblioteca.Domain.LivroContext.ValueObjects
{
    public class Titulo : ValueObject<Titulo>
    {
        public const int TituloTamanhoMax = 300;
        public const int SubTituloTamanhoMax = 300;

        protected Titulo()
        {
            Principal = null!;
            SubTitulo = null!;
        }

        public Titulo(string principal, string? subTitulo)
        {
            if (string.IsNullOrWhiteSpace(principal))
                throw new InvalidEntityException("Título é obrigatório");

            if (principal.Length > TituloTamanhoMax)
                throw new InvalidEntityException($"Título deve ter menos de {TituloTamanhoMax} caracteres");

            if (string.IsNullOrWhiteSpace(subTitulo))
                subTitulo = null;

            if (subTitulo != null && subTitulo.Length > SubTituloTamanhoMax)
                throw new InvalidEntityException($"Título deve ter menos de {SubTituloTamanhoMax} caracteres");

            Principal = principal;
            SubTitulo = subTitulo;
        }

        public string Principal { get; }
        public string? SubTitulo { get; }

        protected override bool EqualsCore(Titulo other)
        {
            return Principal == other.Principal && SubTitulo == other.SubTitulo;
        }

        protected override int GetHashCodeCore()
        {
            return Principal.GetHashCode() + (SubTitulo?.GetHashCode() ?? 0);
        }

        public override string ToString()
        {
            var titulo = Principal;
            if (SubTitulo != null)
                titulo += ": " + SubTitulo;
            return titulo;
        }
    }
}
