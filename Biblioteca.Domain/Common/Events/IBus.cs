using Biblioteca.Domain.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Common.Events
{
    public interface IBus
    {
        Task Send<T>(T request, CancellationToken cancellationToken = default) where T : IDomainEvent;
    }
}
