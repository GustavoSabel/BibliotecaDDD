using Biblioteca.Domain.LivroContext;
using Biblioteca.Dto.Livro;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
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
        public Task<List<AutorDto>> Get()
        {
            return _autorRepository.ObterTodosAsync().ContinueWith(x => x.Result.Select(a => Converter(a)).ToList());
        }

        private static AutorDto Converter(Autor a)
        {
            return new AutorDto
            {
                Id = a.Id,
                DataNascimento = a.DataNascimento,
                Nome = a.Nome
            };
        }

        [HttpGet("{id}")]
        public async Task<AutorDto> Get(int id)
        {
            return Converter(await _autorRepository.ObterPorIdAsync(id));
        }

        [HttpPost]
        public async Task<AutorDto> Post([FromBody] SalvarAutorCommand autorDto)
        {
            var autor = new Autor(autorDto.Nome, autorDto.DataNascimento.Value);
            _autorRepository.Add(autor);
            await _autorRepository.SalvarAsync();
            return Converter(autor);
        }

        [HttpPut("{id}")]
        public async Task<AutorDto> Put(int id, [FromBody] SalvarAutorCommand autorAlterado)
        {
            var autor = await _autorRepository.ObterPorIdAsync(id);
            autor.SetNome(autorAlterado.Nome);
            autor.SetDataNascimento(autorAlterado.DataNascimento.Value);
            await _autorRepository.SalvarAsync();
            return Converter(autor);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _autorRepository.ExcluirAsync(id);
            return NoContent();
        }
    }
}
