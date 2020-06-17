using System;

namespace Biblioteca.Domain.LocacaoContext.Dtos
{
    public class LocacaoListaDto
    {
        public int Id { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime DataPrevistaDevolucao { get; set; }
        public DateTime? DataDevolucao { get; set; }
        public string NomeCliente { get; set; } = "";
        public bool Devolvido => DataDevolucao != null;
    }
}
