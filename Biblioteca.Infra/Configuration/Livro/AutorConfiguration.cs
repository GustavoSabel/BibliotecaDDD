using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Biblioteca.Infra.Configuration.Livro
{
    class AutorConfiguration : IEntityTypeConfiguration<Domain.LivroContext.Autor>
    {
        public void Configure(EntityTypeBuilder<Domain.LivroContext.Autor> builder)
        {
            builder.ToTable("Autor", schema: "Livro");
            builder.Property(x => x.Nome).HasMaxLength(Domain.LivroContext.Autor.TamanhoMaxNome);

            builder.HasData(
                new Domain.LivroContext.Autor("Robert Cecil Martin", new DateTime(1500, 1, 1)) { Id = 1 },
                new Domain.LivroContext.Autor("Eric Evans", new DateTime(1600, 1, 1)) { Id = 2 },
                new Domain.LivroContext.Autor("vaughn vernon", new DateTime(1700, 1, 1)) { Id = 3 },
                new Domain.LivroContext.Autor("Erich Gamma", new DateTime(1800, 1, 1)) { Id = 4 },
                new Domain.LivroContext.Autor("John Vlissides", new DateTime(1900, 1, 1)) { Id = 5 },
                new Domain.LivroContext.Autor("Richard Helm", new DateTime(2000, 1, 1)) { Id = 6 },
                new Domain.LivroContext.Autor("Ralph Johnson", new DateTime(1975, 1, 1)) { Id = 7 }
            );
        }
    }
}
