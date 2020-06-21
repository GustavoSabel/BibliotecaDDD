using Biblioteca.Domain.Common.Events;

namespace Biblioteca.Domain.LocacaoContext
{
    public class LivroAlugadoEvent : IDomainEvent
    {
        public LivroAlugadoEvent(int livroId)
        {
            LivroId = livroId;
        }

        public int LivroId { get; }
    }
}
