using Biblioteca.Domain.Common;

namespace Biblioteca.Domain.LocacaoContext
{
    public class Livro
    {
        public Livro(int livroId, string nome, string serial)
        {
            LivroId = livroId;
            Nome = nome;
            Serial = serial;
        }

        public int LivroId { get; private set; }
        public string Nome { get; private set; }
        public string Serial { get; private set; }
    }
}
