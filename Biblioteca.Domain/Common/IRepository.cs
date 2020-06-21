using System.Threading.Tasks;

namespace Biblioteca.Domain.Common
{
    public interface IRepository<T> where T : AggregateRoot
    {
        ValueTask<T?> ObterPorIdAsync(int id);
        Task ExcluirAsync(T aggregateRoot);
        Task ExcluirAsync(int id);
        void Add(T aggregateRoot);
        Task SalvarAsync();
    }
}
