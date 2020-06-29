using System;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.BlazorClient.Model
{
    public class AutorModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(300, ErrorMessage = "Nome é muito grande")]
        public string Nome { get; set; }

        [Display(Name = "Data de Nascimento")]
        [Required]
        public DateTime? DataNascimento { get; set; }
    }
}
