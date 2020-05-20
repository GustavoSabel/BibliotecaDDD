using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Infra.Configuration.Livro
{
    class AutorConfiguration : IEntityTypeConfiguration<Domain.LivroContext.Autor>
    {
        public void Configure(EntityTypeBuilder<Domain.LivroContext.Autor> builder)
        {
            builder.ToTable("Autor", schema: "Livro");
            builder.Property(x => x.Nome).HasMaxLength(Domain.LivroContext.Autor.TamanhoMaxNome);

            builder.HasData(
                new Domain.LivroContext.Autor("Robert Cecil Martin") { Id = 1 },
                new Domain.LivroContext.Autor("Eric Evans") { Id = 2 },
                new Domain.LivroContext.Autor("vaughn vernon") { Id = 3 },
                new Domain.LivroContext.Autor("Erich Gamma") { Id = 4 },
                new Domain.LivroContext.Autor("John Vlissides") { Id = 5 },
                new Domain.LivroContext.Autor("Richard Helm") { Id = 6 },
                new Domain.LivroContext.Autor("Ralph Johnson") { Id = 7 }
            );
        }
    }
}
