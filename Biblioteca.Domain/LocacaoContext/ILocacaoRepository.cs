using Biblioteca.Domain.Common;
using Biblioteca.Domain.LocacaoContext.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Biblioteca.Domain.LocacaoContext
{
    public interface ILocacaoRepository : IRepository<Locacao>
    {
        Task<List<LocacaoListaDto>> Todos();
    }
}
