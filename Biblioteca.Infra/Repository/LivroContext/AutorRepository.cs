using Biblioteca.Domain.LivroContext;
using Biblioteca.Infra.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Biblioteca.Infra.Repository.LivroContext
{
    public class AutorRepository : Repository<Autor>, IAutorRepository
    {
        public AutorRepository(BibliotecaContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<Autor>> ObterTodosAsync()
        {
            return await _context.Set<Autor>().ToListAsync();
        }
    }
}
