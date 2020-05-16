using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Infra.Configuration.Livro
{
    class AutorConfiguration : IEntityTypeConfiguration<Domain.LivroContext.Autor>
    {
        public void Configure(EntityTypeBuilder<Domain.LivroContext.Autor> builder)
        {
            builder.ToTable("Autor", schema: "Livro");
            builder.Property(x => x.Nome).HasMaxLength(300);
        }
    }
}
