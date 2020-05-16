using Biblioteca.Domain.Common;
using System;
using System.Collections.Generic;

namespace Biblioteca.Domain.LocacaoContext
{
    public class Locacao : AggregateRoot
    {
        private Locacao()
        {
            Livros = null!;
            Cliente = null!;
        }

        public Locacao(DateTime dataLocacao, DateTime dataPrevistaDevolucao, Cliente cliente, IReadOnlyList<Livro> livros)
        {
            DataLocacao = dataLocacao;
            DataPrevistaDevolucao = dataPrevistaDevolucao.Date;
            Cliente = cliente;
            Livros = livros;

            if (DataPrevistaDevolucao <= DataLocacao)
                throw new InvalidEntityException("Data prevista da devolução deve ser maior que a data da locação");

            foreach (var livro in livros)
                AddDomainEvent(new LivroAlugadoEvent(livro.LivroId));
        }

        public DateTime DataLocacao { get; private set; }
        public DateTime DataPrevistaDevolucao { get; private set; }
        public DateTime? DataDevolucao { get; private set; }
        public Cliente Cliente { get; private set; }
        public IReadOnlyList<Livro> Livros { get; private set; }
        public bool TeveMulta { get; private set; }

        public void Devolver(DateTime dataDevolucao)
        {
            if (dataDevolucao < DataLocacao)
                throw new InvalidEntityException("Data de devolução não pode ser menor que a data de locação");

            DataDevolucao = dataDevolucao;

            if (dataDevolucao.Date > DataPrevistaDevolucao)
                TeveMulta = true; 
            
            foreach (var livro in Livros)
                AddDomainEvent(new LivroDevolvidoEvent(livro.LivroId));
        }
    }
}
