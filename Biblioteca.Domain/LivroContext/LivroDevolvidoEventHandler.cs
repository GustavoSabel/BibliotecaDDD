using Biblioteca.Domain.Common;
using Biblioteca.Domain.LocacaoContext;
using System;
using System.Threading.Tasks;

namespace Biblioteca.Domain.LivroContext
{
    public class LivroDevolvidoEventHandler : IHandler<LivroAlugadoEvent>
    {
        private readonly ILivroRepository _livroRepository;

        public LivroDevolvidoEventHandler(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public async Task HandleAsync(LivroAlugadoEvent domainEvent)
        {
            var livro = await _livroRepository.ObterPorIdAsync(domainEvent.LivroId);
            if (livro is null)
                throw new Exception($"Livro {domainEvent.LivroId} não encontrado");

            livro.AlterarSituacao(SituacaoLivro.Alugado);
            await _livroRepository.SalvarAsync(livro);
        }
    }
}
