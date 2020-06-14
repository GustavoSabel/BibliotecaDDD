using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Api.Dto;
using Biblioteca.Domain.LivroContext;
using Biblioteca.Domain.LivroContext.Dtos;
using Biblioteca.Domain.LivroContext.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroRepository _livroRepository;
        private readonly IAutorRepository _autorRepository;

        public LivroController(ILivroRepository livroRepository, IAutorRepository autorRepository)
        {
            _livroRepository = livroRepository;
            _autorRepository = autorRepository;
        }

        [HttpGet]
        public Task<List<LivroListaDto>> Get()
        {
            return _livroRepository.ObterTodosAsync();
        }

        [HttpGet("{id}")]
        public Task<LivroDto> Get(int id)
        {
            return ObterLivroDto(id);
        }

        private async Task<LivroDto> ObterLivroDto(int id)
        {
            var livro = await _livroRepository.ObterPorIdAsync(id);
            return new LivroDto
            {
                Id = livro.Id,
                Ano = livro.Ano,
                Titulo = livro.Titulo.Principal,
                SubTitulo = livro.Titulo.SubTitulo,
                Descricao = livro.Descricao,
                Serial = livro.Serial,
                Situacao = livro.Situacao,
                Estado = livro.Estado.Descricao,
                Autores = livro.Autores.Select(x => x.Autor).ToList()
            };
        }

        [HttpPost]
        public async Task<LivroDto> Post([FromBody] SalvarLivroCommand command)
        {
            var estado = ObterEstado(command);

            var autores = new List<Autor>();
            foreach (var id in command.IdAutores)
                autores.Add(await ObterAutor(id));

            var livro = new Livro(new Titulo(command.Titulo, command.SubTitulo), command.Descricao, new Ano(command.Ano), estado, autores);

            await _livroRepository.SalvarAsync(livro);

            return await ObterLivroDto(livro.Id);
        }

        [HttpPut("{id}")]
        public async Task<LivroDto> Put(int id, [FromBody] SalvarLivroCommand command)
        {
            var livro = await _livroRepository.ObterPorIdAsync(id);
            if (livro == null)
                throw new Exception($"Livro {id} não encontrado");

            var estado = ObterEstado(command);

            livro.AtualizarDadosDoLivro(new Titulo(command.Titulo, command.SubTitulo), command.Descricao,command.Ano, estado);

            foreach (var idAutor in command.IdAutores)
            {
                if (!livro.Autores.Any(x => x.Autor.Id == idAutor))
                    livro.AddAutor(await ObterAutor(idAutor));
            }

            foreach (var autor in livro.Autores.ToList())
            {
                if (!command.IdAutores.Contains(autor.Autor.Id))
                    livro.RemoverAutor(autor.Autor.Id);
            }

            await _livroRepository.SalvarAsync(livro);

            return await ObterLivroDto(id);
        }

        private static Estado ObterEstado(SalvarLivroCommand command)
        {
            if (string.IsNullOrWhiteSpace(command.Estado))
                throw new Exception($"Estado não informado");

            var estado = Estado.ObterPorDescricao(command.Estado);
            if (estado == null)
                throw new Exception($"Estado {command.Estado} não encontrado");
            return estado;
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _livroRepository.ExcluirAsync(id);
        }

        private async Task<Autor> ObterAutor(int id)
        {
            var autor = await _autorRepository.ObterPorIdAsync(id);
            if (autor == null)
                throw new Exception($"Autor {id} não encontrado");
            return autor;
        }
    }
}
