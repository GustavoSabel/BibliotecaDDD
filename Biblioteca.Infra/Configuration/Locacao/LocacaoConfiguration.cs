using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Cryptography;

namespace Biblioteca.Infra.Configuration.Locacao
{
    class LocacaoConfiguration : IEntityTypeConfiguration<Domain.LocacaoContext.Locacao>
    {
        public void Configure(EntityTypeBuilder<Domain.LocacaoContext.Locacao> builder)
        {
            builder.ToTable("Locacao", schema: "Locacao");
            builder.OwnsMany(x => x.Livros, x => x.ToTable("Livro", schema: "Locacao"));
        }
    }
}
