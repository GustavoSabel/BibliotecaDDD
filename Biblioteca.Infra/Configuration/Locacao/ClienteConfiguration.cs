using Biblioteca.Domain.LocacaoContext;
using Biblioteca.Domain.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Infra.Configuration.Locacao
{
    class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente", schema: "Locacao").HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasMaxLength(Cliente.NomeTamanhoMax);
            builder.Property(x => x.Cpf)
                .HasColumnType("CHAR(11)")
                .HasConversion(x => x.Valor, x => new Cpf(x));
        }
    }
}
