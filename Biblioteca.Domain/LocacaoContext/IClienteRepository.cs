using Biblioteca.Domain.Common;
using Biblioteca.Domain.LocacaoContext.Dtos;
using Biblioteca.Domain.SharedKernel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Biblioteca.Domain.LocacaoContext
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<List<ClienteListaDto>> ObterTodosAsync();
        Task<Cliente?> ObterPorCpfAsync(Cpf cpf);
    }
}
