using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Infra.Configuration.Locacao
{
    class LocacaoConfiguration : IEntityTypeConfiguration<Domain.LocacaoContext.Locacao>
    {
        public void Configure(EntityTypeBuilder<Domain.LocacaoContext.Locacao> builder)
        {
            builder.ToTable("Locacao", schema: "Locacao").HasKey(x => x.Id);
            builder.OwnsMany(x => x.Livros, x =>
            {
                x.Property<int>("Id").HasColumnName("Id");
                x.ToTable("Livro", schema: "Locacao").HasKey("Id");
                x.Property(x => x.LivroId);
                x.Property(x => x.Titulo).HasMaxLength(300);
                x.Property(x => x.SubTitulo).HasMaxLength(300);
                x.Property(x => x.Estado).HasMaxLength(300);
            });
        }
    }
}
