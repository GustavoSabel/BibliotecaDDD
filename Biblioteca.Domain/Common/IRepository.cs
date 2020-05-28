using System.Threading.Tasks;

namespace Biblioteca.Domain.Common
{
    public interface IRepository<T> where T : AggregateRoot
    {
        ValueTask<T?> ObterPorIdAsync(int id);
        Task SalvarAsync(T aggregateRoot);
        Task ExcluirAsync(T aggregateRoot);
        Task ExcluirAsync(int id);
    }
}
