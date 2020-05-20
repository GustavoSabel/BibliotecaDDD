using Biblioteca.Domain.Common;
using Biblioteca.Domain.LocacaoContext;
using System;
using System.Threading.Tasks;

namespace Biblioteca.Domain.LivroContext
{
    public class LivroAlugadoEventHandler : IHandler<LivroAlugadoEvent>
    {
        private readonly ILivroRepository _livroRepository;

        public LivroAlugadoEventHandler(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public async Task HandleAsync(LivroAlugadoEvent domainEvent)
        {
            var livro = await _livroRepository.ObterPorId(domainEvent.LivroId);
            if (livro is null)
                throw new Exception($"Livro {domainEvent.LivroId} não encontrado");

            livro.Situacao = SituacaoLivro.Disponivel;
            await _livroRepository.Salvar(livro);
        }
    }
}
