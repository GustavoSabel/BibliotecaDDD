using Biblioteca.Domain.Common;

namespace Biblioteca.Domain.LivroContext
{
    public class LivroAutor : Entity
    {
        protected LivroAutor()
        {
            Autor = null!;
            Livro = null!;
        }

        public LivroAutor(Autor autor, Livro livro)
        {
            Autor = autor;
            Livro = livro;
        }

        public virtual Autor Autor { get; }
        public virtual Livro Livro { get; }
    }
}
