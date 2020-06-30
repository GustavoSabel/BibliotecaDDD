using System;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Dto.Livro
{
    public class SalvarAutorCommand
    {
        [Required]
        [StringLength(300)]
        public string Nome { get; set; }

        [Required]
        public DateTime? DataNascimento { get; set; }
    }
}
