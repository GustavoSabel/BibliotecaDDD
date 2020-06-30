using System.ComponentModel;

namespace Biblioteca.BlazorClient.Model
{
    public enum SituacaoLivro
    {
        [Description("Disponível")]
        Disponivel,

        [Description("Alugado")]
        Alugado
    }
}
