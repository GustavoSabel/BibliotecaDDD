namespace Biblioteca.BlazorClient.Model
{
    public class LivroListaModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string SubTitulo { get; set; }
        public string TituloESubTitulo => Titulo + (string.IsNullOrEmpty(SubTitulo) ? "" : ": " + SubTitulo);
        public int Ano { get; set; }
        public string Serial { get; set; }
        public string Descricao { get; set; }
        public SituacaoLivro Situacao { get; set; }
        public string SituacaoStr => Situacao switch
        {
            SituacaoLivro.Disponivel => "Disponível",
            _ => Situacao.ToString(),
        };
    }
}
