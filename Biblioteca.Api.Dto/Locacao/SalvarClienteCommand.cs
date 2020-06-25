using System;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Api.Dtos
{
    public class SalvarClienteCommand
    {
        [Required]
        [StringLength(300)]
        public string Nome { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }

        [Required]
        [StringLength(maximumLength: 14, MinimumLength = 11)]
        public string Cpf { get; set; }
    }
}
