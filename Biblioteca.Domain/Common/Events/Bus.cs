using Biblioteca.Domain.Common;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Common.Events
{
    public class Bus : IBus
    {
        private readonly IMediator _mediator;

        public Bus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task Send<T>(T request, CancellationToken cancellationToken = default) where T : IDomainEvent
        {
            return _mediator.Send(request, cancellationToken);
        }
    }
}
