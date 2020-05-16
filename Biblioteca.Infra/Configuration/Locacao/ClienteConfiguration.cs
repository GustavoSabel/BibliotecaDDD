using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Infra.Configuration.Locacao
{
    class ClienteConfiguration : IEntityTypeConfiguration<Domain.LocacaoContext.Cliente>
    {
        public void Configure(EntityTypeBuilder<Domain.LocacaoContext.Cliente> builder)
        {
            builder.ToTable("Cliente", schema: "Locacao");
        }
    }
}
