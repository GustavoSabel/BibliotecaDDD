using Biblioteca.Domain.LocacaoContext;
using Biblioteca.Infra.Common;

namespace Biblioteca.Infra.Repository.LocacaoContext
{
    public class LocacaoRepository : Repository<Locacao>, ILocacaoRepository
    {
        public LocacaoRepository(BibliotecaContext context) : base(context)
        {
        }
    }
}
