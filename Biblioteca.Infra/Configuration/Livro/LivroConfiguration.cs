using Biblioteca.Domain.LivroContext.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Infra.Configuration.Livro
{
    class LivroConfiguration : IEntityTypeConfiguration<Domain.LivroContext.Livro>
    {
        public void Configure(EntityTypeBuilder<Domain.LivroContext.Livro> builder)
        {
            builder.ToTable("Livro", schema: "Livro").HasKey(x => x.Id);
            builder.Property(x => x.Serial).HasMaxLength(50);
            builder.Property(x => x.Descricao).HasMaxLength(Domain.LivroContext.Livro.DescricaoTamanhoMax);
            builder.HasMany(x => x.Autores).WithOne(x => x.Livro)
                .Metadata.PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.HasOne(x => x.Estado).WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Ano)
                .HasConversion(x => x.Valor, x => new Domain.LivroContext.ValueObjects.Ano(x));

            builder.OwnsOne(x => x.Titulo, b =>
            {
                b.Property(y => y.Principal).HasColumnName("Titulo").HasMaxLength(Titulo.TituloTamanhoMax);
                b.Property(y => y.SubTitulo).HasColumnName("SubTitulo").HasMaxLength(Titulo.SubTituloTamanhoMax);
            });
        }
    }
}
