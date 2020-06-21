using MediatR;

namespace Biblioteca.Domain.Common.Events
{
    public abstract class Handler<T> : AsyncRequestHandler<T> where T : IDomainEvent
    {
        
    }
}
