using System.Threading.Tasks;

namespace Biblioteca.Domain.Common
{
    public interface IRepository<T> where T : AggregateRoot
    {
        ValueTask<T?> ObterPorId(int id);
        Task Salvar(T aggregateRoot);
        Task Excluir(T aggregateRoot);
        Task Excluir(int id);
    }
}
