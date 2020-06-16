using System;

namespace Biblioteca.Domain.LocacaoContext.Dtos
{
    public class ClienteListaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = "";
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; } = "";
    }
}
