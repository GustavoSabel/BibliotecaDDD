using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Infra.Configuration.Livro
{
    class LivroAutorConfiguration : IEntityTypeConfiguration<Domain.LivroContext.LivroAutor>
    {
        public void Configure(EntityTypeBuilder<Domain.LivroContext.LivroAutor> builder)
        {
            builder.ToTable("LivroAutor", schema: "Livro").HasKey(x => x.Id);
        }
    }
}
