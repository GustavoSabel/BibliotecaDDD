using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Api.Dto
{
    public class AlugarLivrosCommand
    {
        [Required]
        [MinLength(1)]
        public int[] LivrosId { get; set; }

        [Required]
        [Range(1, 999999)]
        public int ClienteId { get; set; }
    }
}
