using MediatR;

namespace Biblioteca.Domain.Common
{
    public abstract class Handler<T> : AsyncRequestHandler<T> where T : IDomainEvent
    {
        
    }
}
