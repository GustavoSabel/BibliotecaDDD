using Biblioteca.Domain.LocacaoContext;
using Biblioteca.Domain.LocacaoContext.Dtos;
using Biblioteca.Domain.SharedKernel;
using Biblioteca.Infra.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Infra.Repository.LocacaoContext
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(BibliotecaContext context) : base(context)
        {
        }

        public async Task<Cliente?> ObterPorCpfAsync(Cpf cpf)
        {
            return await Set.FirstOrDefaultAsync(x => x.Cpf == cpf);
        }

        public Task<List<ClienteListaDto>> ObterTodosAsync()
        {
            return Set.Select(x => new ClienteListaDto
            {
                Id = x.Id,
                Nome = x.Nome,
                DataNascimento = x.DataNascimento,
                Cpf = x.Cpf.Valor
            }).ToListAsync();
        }
    }
}
