using Biblioteca.Api.Dtos;
using Biblioteca.Domain.LocacaoContext;
using Biblioteca.Domain.LocacaoContext.Dtos;
using Biblioteca.Domain.SharedKernel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Biblioteca.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public Task<List<ClienteListaDto>> Get()
        {
            return _clienteRepository.ObterTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<ClienteDto> Get(int id)
        {
            return Converter(await _clienteRepository.ObterPorIdAsync(id));
        }

        [HttpGet("cfp/{cpf}")]
        public async Task<ClienteDto> Get(string cpf)
        {
            return Converter(await _clienteRepository.ObterPorCpfAsync(new Cpf(cpf)));
        }

        [HttpPost]
        public async Task<ClienteDto> Post([FromBody] SalvarClienteDto value)
        {
            var cpf = new Cpf(value.Cpf);
            var clieteExistente = await _clienteRepository.ObterPorCpfAsync(cpf);
            if (clieteExistente != null)
                throw new Exception($"Já existe o cliente {clieteExistente.Nome} com esse CPF");

            var cliente = new Cliente(value.Nome, cpf, value.DataNascimento);
            await _clienteRepository.SalvarAsync(cliente);
            return Converter(cliente);
        }

        [HttpPut("{id}")]
        public async Task<ClienteDto> Put(int id, [FromBody] AtualizarClienteDto value)
        {
            var cliente = await _clienteRepository.ObterPorIdAsync(id);
            if (cliente == null)
                throw new Exception($"Cliente {id} não encontrado");

            cliente.AtualizarDados(value.Nome, value.DataNascimento);

            await _clienteRepository.SalvarAsync(cliente);

            return Converter(cliente);
        }

        [HttpDelete("{id}")]
        public Task Delete(int id)
        {
            return _clienteRepository.ExcluirAsync(id);
        }

        private ClienteDto Converter(Cliente cliente)
        {
            return new ClienteDto
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                DataNascimento = cliente.DataNascimento,
                Cpf = cliente.Cpf.ToString()
            };
        }
    }
}
