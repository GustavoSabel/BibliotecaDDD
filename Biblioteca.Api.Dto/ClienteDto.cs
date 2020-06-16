using System;

namespace Biblioteca.Api.Dtos
{
    public class ClienteDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
    }

    public class SalvarClienteDto
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
    }

    public class AtualizarClienteDto
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
