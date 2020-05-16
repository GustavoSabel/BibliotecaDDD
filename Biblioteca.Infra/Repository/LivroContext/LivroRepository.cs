using Biblioteca.Domain.LivroContext;
using Biblioteca.Infra.Common;

namespace Biblioteca.Infra.Repository.LivroContext
{
    public class LivroRepository : Repository<Livro>, ILivroRepository
    {
        public LivroRepository(BibliotecaContext context) : base(context)
        {
        }
    }
}
