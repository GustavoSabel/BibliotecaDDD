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
            return _autorRepository.ObterPorId(id);
        }

        [HttpPost]
        public async Task<Autor> Post([FromBody] SalvarAutorDto autorDto)
        {
            var autor = new Autor(autorDto.Nome);
            await _autorRepository.Salvar(autor);
            return autor;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] SalvarAutorDto autorAlterado)
        {
            var autor = await _autorRepository.ObterPorId(id);
            autor.SetNome(autorAlterado.Nome);
            await _autorRepository.Salvar(autor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _autorRepository.Excluir(id);
            return NoContent();
        }
    }
}
