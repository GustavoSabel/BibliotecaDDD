namespace Biblioteca.Domain.LivroContext.Dtos
{
    public class LivroListaDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = "";
        public string? SubTitulo { get; set; }
        public int Ano { get; set; }
        public string Serial { get; set; } = "";
        public string Descricao { get; set; } = "";
        public SituacaoLivro Situacao { get; set; }
    }
}
