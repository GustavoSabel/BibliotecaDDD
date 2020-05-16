using Biblioteca.Domain.LocacaoContext;
using Biblioteca.Infra.Common;

namespace Biblioteca.Infra.Repository.LocacaoContext
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(BibliotecaContext context) : base(context)
        {
        }
    }
}
