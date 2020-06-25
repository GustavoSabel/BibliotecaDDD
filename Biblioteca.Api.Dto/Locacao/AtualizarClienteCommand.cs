using System;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Api.Dtos
{
    public class AtualizarClienteCommand
    {
        [Required]
        [StringLength(300)]
        public string Nome { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }
    }
}
