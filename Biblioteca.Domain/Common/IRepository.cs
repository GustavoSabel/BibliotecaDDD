using System.Threading.Tasks;

namespace Biblioteca.Domain.Common
{
    public interface IRepository<T> where T : AggregateRoot
    {
        ValueTask<T?> GetById(long id);
        Task Save(T aggregateRoot);
    }
}
