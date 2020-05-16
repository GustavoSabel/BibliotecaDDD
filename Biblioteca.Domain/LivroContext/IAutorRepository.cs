using Biblioteca.Domain.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Biblioteca.Domain.LivroContext
{
    public interface IAutorRepository : IRepository<Autor>
    {
        Task<IReadOnlyList<Autor>> ObterTodosAsync();
    }
}
