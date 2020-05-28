using Biblioteca.Api.Dtos;
using Biblioteca.Domain.LivroContext;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Biblioteca.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorRepository _autorRepository;

        public AutorController(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }

        [HttpGet]
        public Task<IReadOnlyList<Autor>> Get()
        {
            return _autorRepository.ObterTodosAsync();
        }

        [HttpGet("{id}")]
        public ValueTask<Autor> Get(int id)
        {
            return _autorRepository.ObterPorIdAsync(id);
        }

        [HttpPost]
        public async Task<Autor> Post([FromBody] SalvarAutorDto autorDto)
        {
            var autor = new Autor(autorDto.Nome, autorDto.DataNascimento);
            await _autorRepository.SalvarAsync(autor);
            return autor;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AtualizarAutorDto autorAlterado)
        {
            var autor = await _autorRepository.ObterPorIdAsync(id);
            autor.SetNome(autorAlterado.Nome);
            autor.SetDataNascimento(autorAlterado.DataNascimento);
            await _autorRepository.SalvarAsync(autor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _autorRepository.ExcluirAsync(id);
            return NoContent();
        }
    }
}
