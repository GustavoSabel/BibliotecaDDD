using Biblioteca.Domain.Common.Events;
using Biblioteca.Domain.LocacaoContext;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Biblioteca.Domain.LivroContext
{
    public class LivroDevolvidoEventHandler : Handler<LivroDevolvidoEvent>
    {
        private readonly ILivroRepository _livroRepository;

        public LivroDevolvidoEventHandler(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        protected override async Task Handle(LivroDevolvidoEvent domainEvent, CancellationToken cancellationToken)
        {
            var livro = await _livroRepository.ObterPorIdAsync(domainEvent.LivroId);
            if (livro is null)
                throw new Exception($"Livro {domainEvent.LivroId} não encontrado");

            livro.AlterarSituacao(SituacaoLivro.Disponivel);
            await _livroRepository.SalvarAsync();
        }
    }
}
