using Biblioteca.Domain.LocacaoContext;
using Biblioteca.Domain.LocacaoContext.Dtos;
using Biblioteca.Infra.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Infra.Repository.LocacaoContext
{
    public class LocacaoRepository : Repository<Locacao>, ILocacaoRepository
    {
        public LocacaoRepository(BibliotecaContext context) : base(context)
        {
        }

        public Task<List<LocacaoListaDto>> Todos()
        {
            return Set.Select(x => new LocacaoListaDto
            {
                Id = x.Id,
                DataDevolucao = x.DataDevolucao,
                DataLocacao = x.DataLocacao,
                DataPrevistaDevolucao = x.DataPrevistaDevolucao,
                NomeCliente = x.Cliente.Nome
            }).ToListAsync();
        }
    }
}
