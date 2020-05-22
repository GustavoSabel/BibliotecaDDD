using Biblioteca.Domain.LivroContext;
using Xunit;

namespace Biblioteca.Tests.TempTest
{
    public class CriarAutor : EFTest
    {
        [Fact]
        public void Teste()
        {
            _dbContext.Set<Autor>().Add(new Autor("Teste", new System.DateTime(2000, 1, 1)));
            _dbContext.SaveChanges();
        }
    }
}
