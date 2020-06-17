namespace Biblioteca.Api.Dto
{
    public class AlugarLivrosCommand
    {
        public int[] LivrosId { get; set; }
        public int ClienteId { get; set; }
    }
}
