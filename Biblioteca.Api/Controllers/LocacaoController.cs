using Biblioteca.Domain.LivroContext;
using Biblioteca.Domain.LocacaoContext;
using Biblioteca.Domain.LocacaoContext.Dtos;
using Biblioteca.Dto.Locacao;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocacaoController : ControllerBase
    {
        private readonly ILocacaoRepository _locacaoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly ILivroRepository _livroRepository;

        public LocacaoController(ILocacaoRepository locacaoRepository, IClienteRepository clienteRepository, ILivroRepository livroRepository)
        {
            _locacaoRepository = locacaoRepository;
            _clienteRepository = clienteRepository;
            _livroRepository = livroRepository;
        }

        [HttpGet]
        public Task<List<LocacaoListaDto>> Get()
        {
            return _locacaoRepository.Todos();
        }

        [HttpPost("Alugar")]
        public async Task<LocacaoDto> Alugar(AlugarLivrosCommand command)
        {
            var cliente = await _clienteRepository.ObterPorIdAsync(command.ClienteId);
            if (cliente == null)
                throw new Exception($"Cliente {command.ClienteId} não encontrado");

            var livros = new List<Domain.LocacaoContext.Livro>();
            foreach (var livroId in command.LivrosId)
            {
                var livro = await _livroRepository.ObterPorIdAsync(livroId);
                if (livro == null)
                    throw new Exception($"Livro {livroId} não encontrado");

                if (livro.Situacao == SituacaoLivro.Alugado)
                    throw new Exception($"O Livro \"{livro.Titulo}\" já está alugado");

                livros.Add(new Domain.LocacaoContext.Livro(livro.Id, livro.Titulo.Principal, livro.Titulo.SubTitulo, livro.Estado.Descricao));
            }

            var locacao = new Locacao(DateTime.Now, DateTime.Now.AddDays(2), cliente, livros);
            _locacaoRepository.Add(locacao);
            await _locacaoRepository.SalvarAsync();

            return ConverterParaDto(locacao);
        }

        [HttpPost("Devolver/{Id}")]
        public async Task<LocacaoDto> Devolver(int id)
        {
            var locacao = await _locacaoRepository.ObterPorIdAsync(id);
            if (locacao.Devolvido)
                throw new Exception($"Essa locação já foi devolvida em {locacao.DataDevolucao:g}");

            locacao.Devolver(DateTime.Now);
            await _locacaoRepository.SalvarAsync();

            return ConverterParaDto(locacao);
        }

        private LocacaoDto ConverterParaDto(Locacao locacao)
        {
            return new LocacaoDto
            {
                Id = locacao.Id,
                Cliente = locacao.Cliente.Nome,
                DataDevolucao = locacao.DataDevolucao,
                DataLocacao = locacao.DataLocacao,
                DataPrevistaDevolucao = locacao.DataPrevistaDevolucao,
                TeveMulta = locacao.TeveMulta,
                Livros = locacao.Livros.Select(x => new LocacaoDto.LocacaoLivroDto
                {
                    Titulo = x.Titulo,
                    SubTitulo = x.SubTitulo
                }).ToList()
            };
        }
    }
}
