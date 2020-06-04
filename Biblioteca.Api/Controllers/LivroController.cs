using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Api.Dto;
using Biblioteca.Domain.LivroContext;
using Biblioteca.Domain.LivroContext.Dtos;
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
        public async Task<LivroDto> Get(int id)
        {
            var livro = await _livroRepository.ObterPorIdAsync(id);
            return new LivroDto
            {
                Id = livro.Id,
                Ano = livro.Ano,
                Titulo = livro.Titulo,
                SubTitulo = livro.SubTitulo,
                Descricao = livro.Descricao,
                Serial = livro.Serial,
                Situacao = livro.Situacao,
                Autores = livro.Autores.Select(x => x.Autor).ToList()
            };
        }

        [HttpPost]
        public async Task Post([FromBody] SalvarLivroCommand command)
        {
            var autores = new List<Autor>();
            foreach (var id in command.IdAutores)
                autores.Add(await ObterAutor(id));

            var livro = new Livro(command.Titulo, command.SubTitulo ?? "", command.Ano, autores);
            await _livroRepository.SalvarAsync(livro);
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] SalvarLivroCommand command)
        {
            var livro = await _livroRepository.ObterPorIdAsync(id);
            if (livro == null)
                throw new Exception($"Livro {id} não encontrado");

            livro.Titulo = command.Titulo;
            livro.SubTitulo = command.SubTitulo;
            livro.Descricao = command.Descricao;
            livro.Ano = command.Ano;

            foreach (var idAutor in command.IdAutores)
            {
                if (!livro.Autores.Any(x => x.Autor.Id == idAutor))
                    livro.AddAutor(await ObterAutor(id));
            }

            foreach (var autor in livro.Autores)
            {
                if (!command.IdAutores.Contains(autor.Autor.Id))
                    livro.RemoverAutor(autor.Autor.Id);
            }
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
