using System;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Dto.Locacao
{
    public class ClienteDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Cpf { get; set; }
    }
}
