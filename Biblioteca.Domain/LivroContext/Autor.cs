using Biblioteca.Domain.Common;

namespace Biblioteca.Domain.LivroContext
{
    public class Autor : AggregateRoot
    {
        public Autor(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; }
    }
}
