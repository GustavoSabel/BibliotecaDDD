using System.Threading.Tasks;

namespace Biblioteca.Domain.Common
{
    public interface IHandler<T>
        where T : IDomainEvent
    {
        Task HandleAsync(T domainEvent);
    }
}
