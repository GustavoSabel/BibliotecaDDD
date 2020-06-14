using Biblioteca.Domain.LivroContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Infra.Configuration.Livro
{
    public class EstadoConfiguration : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder.ToTable("Estado", schema: "Livro").HasKey(x => x.Id);
            builder.Property(x => x.Descricao).HasMaxLength(100);
        }
    }
}
