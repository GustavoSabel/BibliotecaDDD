using Biblioteca.Domain.Common;

namespace Biblioteca.Domain.LivroContext
{
    public class LivroAutor : Entity
    {
        private LivroAutor()
        {
            Autor = null!;
            Livro = null!;
        }

        public LivroAutor(Autor autor, Livro livro)
        {
            Autor = autor;
            Livro = livro;
        }

        public Autor Autor { get; private set; }
        public Livro Livro { get; private set; }
    }
}
