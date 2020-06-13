using Biblioteca.Domain.LivroContext;
using Biblioteca.Domain.LivroContext.Dtos;
using Biblioteca.Infra.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Infra.Repository.LivroContext
{
    public class LivroRepository : Repository<Livro>, ILivroRepository
    {
        public override Task PosObterAsync(Livro livro)
        {
            return _context.Entry(livro).Collection(x => x.Autores).LoadAsync();
        }

        public LivroRepository(BibliotecaContext context) : base(context)
        {
        }

        public Task<List<LivroListaDto>> ObterTodosAsync()
        {
            return Set.Select(x => new LivroListaDto
            {
                Id = x.Id,
                Ano = x.Ano,
                Descricao = x.Descricao,
                Serial = x.Serial,
                Situacao = x.Situacao,
                SubTitulo = x.SubTitulo,
                Titulo = x.Titulo
            }).ToListAsync();
        }
    }
}
