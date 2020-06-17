using Biblioteca.Domain.Common;

namespace Biblioteca.Domain.LocacaoContext
{
    public class Livro
    {
        public Livro(int livroId, string titulo, string? subTitulo, string estado)
        {
            LivroId = livroId;
            Titulo = titulo;
            SubTitulo = subTitulo;
            Estado = estado;
        }

        public int LivroId { get; private set; }
        public string Titulo { get; private set; }
        public string? SubTitulo { get; private set; }
        public string Estado { get; private set; }
    }
}
