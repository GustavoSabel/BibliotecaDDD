using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Infra.Configuration.Locacao
{
    class LocacaoConfiguration : IEntityTypeConfiguration<Domain.LocacaoContext.Locacao>
    {
        public void Configure(EntityTypeBuilder<Domain.LocacaoContext.Locacao> builder)
        {
            builder.OwnsMany(x => x.Livros);
        }
    }
}
