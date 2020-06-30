using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Dto.Livro
{
    public class SalvarLivroCommand
    {
        [Required]
        [StringLength(300)]
        public string Titulo { get; set; }

        [StringLength(300)]
        public string SubTitulo { get; set; }

        [Range(-9999,9999)]
        public int Ano { get; set; }

        [StringLength(5000)]
        public string Descricao { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public int[] IdAutores { get; set; }

        [Required]
        [StringLength(50)]
        public string Estado { get; set; }
    }
}
