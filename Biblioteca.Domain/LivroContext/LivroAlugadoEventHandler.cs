using Biblioteca.Domain.Common;
using Biblioteca.Domain.LocacaoContext;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Biblioteca.Domain.LivroContext
{
    public class LivroAlugadoEventHandler : Handler<LivroAlugadoEvent>
    {
        private readonly ILivroRepository _livroRepository;

        public LivroAlugadoEventHandler(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        protected override async Task Handle(LivroAlugadoEvent @event, CancellationToken cancellationToken)
        {
            var livro = await _livroRepository.ObterPorIdAsync(@event.LivroId);
            if (livro is null)
                throw new Exception($"Livro {@event.LivroId} não encontrado");

            livro.AlterarSituacao(SituacaoLivro.Alugado);
            await _livroRepository.SalvarAsync();
        }
    }
}
