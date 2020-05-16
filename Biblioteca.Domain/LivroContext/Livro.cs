using Biblioteca.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Domain.LivroContext
{
    public class Livro : AggregateRoot
    {
        private List<Autor> _autores;

        private Livro()
        {
            Nome = "";
            _autores = new List<Autor>();
            Serial = "";
        }

        public Livro(string nome, IReadOnlyList<Autor> autores)
        {
            Nome = nome;
            Serial = Guid.NewGuid().ToString();
            Situacao = SituacaoLivro.Disponivel;

            _autores = new List<Autor>();
            foreach (var autor in autores)
                AddAutor(autor);

            if (Autores.Count == 0)
                throw new InvalidEntityException("É obrigatório informar pelo menos um autor");
        }

        public string Nome { get; private set; }
        public string Serial { get; private set; }
        public string Descricao { get; set; } = "";
        public IReadOnlyList<Autor> Autores { get => _autores; private set => _autores = value.ToList(); }
        public SituacaoLivro Situacao { get; set; }

        public void AddAutor(Autor autor)
        {
            if (_autores.Any(x => x.Id == autor.Id))
                throw new InvalidEntityException($"O Autor {autor.Nome} já está vinculado ao livro");
            _autores.Add(autor);
        }

        public void RemoverAutor(int autorId)
        {
            var autor = _autores.FirstOrDefault(x => x.Id == autorId);
            if (autor is null)
                throw new InvalidEntityException($"Autor {autorId} não encontrado no livro");

            _autores.Remove(autor);
        }
    }
}
