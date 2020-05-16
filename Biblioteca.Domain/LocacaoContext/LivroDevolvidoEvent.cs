using Biblioteca.Domain.Common;

namespace Biblioteca.Domain.LocacaoContext
{
    public class LivroDevolvidoEvent : IDomainEvent
    {
        public LivroDevolvidoEvent(int livroId)
        {
            LivroId = livroId;
        }

        public int LivroId { get; }
    }
}
