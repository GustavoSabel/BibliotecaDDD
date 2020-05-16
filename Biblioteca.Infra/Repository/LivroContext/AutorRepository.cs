using Biblioteca.Domain.LivroContext;
using Biblioteca.Infra.Common;

namespace Biblioteca.Infra.Repository.LivroContext
{
    public class AutorRepository : Repository<Autor>, IAutorRepository
    {
        public AutorRepository(BibliotecaContext context) : base(context)
        {
        }
    }
}
