using Biblioteca.Domain.Common;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace Biblioteca.Domain.LivroContext
{
    public class Estado : Entity
    {
        public static Estado Otimo = new Estado(1, "Ótimo");
        public static Estado Bom = new Estado(2, "Bom");
        public static Estado Ruim = new Estado(3, "Ruim");

        public static List<Estado> Listar() => new List<Estado> { Otimo, Bom, Ruim };

        public Estado(int id, string descricao) : base(id)
        {
            Descricao = descricao;
        }

        protected Estado()
        {
            Descricao = null!;
        }

        public string Descricao { get; }

        public override string ToString() => Descricao;

        public static Estado ObterPorDescricao(string descricao)
        {
            return Listar().FirstOrDefault(x => x.Descricao.Equals(descricao, System.StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
