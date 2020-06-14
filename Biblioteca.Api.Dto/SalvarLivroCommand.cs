namespace Biblioteca.Api.Dto
{
    public class SalvarLivroCommand
    {
        public string Titulo { get; set; }
        public string SubTitulo { get; set; }
        public int Ano { get; set; }
        public string Descricao { get; set; }
        public int[] IdAutores { get; set; }
        public string Estado { get; set; }
    }
}
