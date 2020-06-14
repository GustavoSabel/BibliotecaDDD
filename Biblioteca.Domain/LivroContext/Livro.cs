using Biblioteca.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Domain.LivroContext
{
    public class Livro : AggregateRoot
    {
        private readonly List<LivroAutor> _autores;

        protected Livro()
        {
            Titulo = null!;
            Serial = null!;
            _autores = null!;
            SubTitulo = null!;
            Descricao = null!;
            Estado = null!;
        }

        public Livro(string titulo, string? subTitulo, int ano, Estado estado, IEnumerable<Autor> autores)
        {
            Titulo = titulo;
            SubTitulo = subTitulo;
            Ano = ano;
            Serial = Guid.NewGuid().ToString();
            Situacao = SituacaoLivro.Disponivel;
            Estado = estado;

            _autores = new List<LivroAutor>();
            foreach (var autor in autores)
                AddAutor(autor);

            if (Autores.Count == 0)
                throw new InvalidEntityException("É obrigatório informar pelo menos um autor");
        }

        public string Titulo { get; set; }
        public string? SubTitulo { get; set; }
        public int Ano { get; set; }
        public string Serial { get; set; }
        public string? Descricao { get; set; }
        public SituacaoLivro Situacao { get; set; }
        public virtual Estado Estado { get; set; }
        public virtual IReadOnlyList<LivroAutor> Autores => _autores;

        public void AddAutor(Autor autor)
        {
            if (_autores.Any(x => x == autor))
                throw new InvalidEntityException($"O Autor {autor.Nome} já está vinculado ao livro");
            _autores.Add(new LivroAutor(autor, this));
        }

        public void RemoverAutor(int autorId)
        {
            var autor = _autores.FirstOrDefault(x => x.Id == autorId);
            if (autor is null)
                throw new InvalidEntityException($"Autor {autorId} não encontrado no livro");

            if (_autores.Count == 1)
                throw new Exception("Livro não pode ficar sem autores");

            _autores.Remove(autor);
        }
    }
}
