using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Biblioteca.Infra.Configuration.Livro
{
    class AutorConfiguration : IEntityTypeConfiguration<Domain.LivroContext.Autor>
    {
        public void Configure(EntityTypeBuilder<Domain.LivroContext.Autor> builder)
        {
            builder.ToTable("Autor", schema: "Livro").HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasMaxLength(Domain.LivroContext.Autor.TamanhoMaxNome);
        }
    }
}
