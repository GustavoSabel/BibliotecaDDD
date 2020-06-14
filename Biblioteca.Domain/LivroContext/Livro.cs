using Biblioteca.Domain.Common;
using Biblioteca.Domain.LivroContext.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Domain.LivroContext
{
    public class Livro : AggregateRoot
    {
        public const int TituloTamanhoMax = 300;
        public const int SubTituloTamanhoMax = 300;
        public const int DescricaoTamanhoMax = 5000;

        private readonly List<LivroAutor> _autores;

        protected Livro()
        {
            Titulo = null!;
            Serial = null!;
            _autores = null!;
            SubTitulo = null!;
            Descricao = null!;
            Estado = null!;
            Ano = null!;
        }

        public Livro(string titulo, string? subTitulo, string? descricao, Ano ano, Estado estado, IEnumerable<Autor> autores)
        {
            Titulo = titulo;
            SubTitulo = subTitulo;
            Ano = ano;
            Serial = Guid.NewGuid().ToString();
            Situacao = SituacaoLivro.Disponivel;
            Descricao = descricao;
            Estado = estado;

            _autores = new List<LivroAutor>();
            foreach (var autor in autores)
                AddAutor(autor);

            Validar();
        }

        public string Titulo { get; private set; }
        public string? SubTitulo { get; private set; }
        public virtual Ano Ano { get; private set; }
        public string Serial { get; private set; }
        public SituacaoLivro Situacao { get; private set; }
        public virtual Estado Estado { get; private set; }
        public string? Descricao { get; private set; }
        public virtual IReadOnlyList<LivroAutor> Autores => _autores;

        public void AlterarSituacao(SituacaoLivro novaSituacao)
        {
            Situacao = novaSituacao;
        }

        public void AtualizarDadosDoLivro(string titulo, string? subTitulo, string? descricao, Ano ano, Estado estado)
        {
            Titulo = titulo;
            SubTitulo = subTitulo;
            Ano = ano;
            Estado = estado;
            Descricao = descricao;

            Validar();
        }

        public void AddAutor(Autor autor)
        {
            if (_autores.Any(x => x == autor))
                throw new InvalidEntityException($"O Autor {autor.Nome} já está vinculado ao livro");
            _autores.Add(new LivroAutor(autor, this));
        }

        public void RemoverAutor(int autorId)
        {
            var autor = _autores.FirstOrDefault(x => x.Autor.Id == autorId);
            if (autor is null)
                throw new InvalidEntityException($"Autor {autorId} não encontrado no livro");

            _autores.Remove(autor);

            Validar();
        }

        private void Validar()
        {
            if (string.IsNullOrWhiteSpace(Titulo))
                throw new InvalidEntityException("Título é obrigatório");

            if (Titulo.Length > TituloTamanhoMax)
                throw new InvalidEntityException($"Título deve ter menos de {TituloTamanhoMax} caracteres");

            if (SubTitulo != null && SubTitulo.Length > SubTituloTamanhoMax)
                throw new InvalidEntityException($"Título deve ter menos de {SubTituloTamanhoMax} caracteres");

            if (Descricao != null && Descricao.Length > DescricaoTamanhoMax)
                throw new InvalidEntityException($"Descrição deve ter menos de {DescricaoTamanhoMax} caracteres");

            if (Autores.Count == 0)
                throw new InvalidEntityException("Livro não pode ficar sem autores");
        }
    }
}
