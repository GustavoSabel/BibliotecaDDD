using Biblioteca.Domain.Common;
using Biblioteca.Domain.LivroContext.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Biblioteca.Domain.LivroContext
{
    public interface ILivroRepository : IRepository<Livro>
    {
        Task<IReadOnlyList<LivroListaDto>> ObterTodosAsync();
    }
}
