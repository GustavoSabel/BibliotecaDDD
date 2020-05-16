using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Infra.Configuration.Livro
{
    class LivroConfiguration : IEntityTypeConfiguration<Domain.LivroContext.Livro>
    {
        public void Configure(EntityTypeBuilder<Domain.LivroContext.Livro> builder)
        {
            builder.ToTable("Livro", schema: "Livro");
            builder.Property(x => x.Nome).HasMaxLength(300);
            builder.Property(x => x.Serial).HasMaxLength(50);
            builder.Property(x => x.Descricao).HasMaxLength(5000);
        }
    }
}
