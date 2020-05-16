using Biblioteca.Domain.LivroContext;
using Xunit;

namespace Biblioteca.Tests.TempTest
{
    public class CriarAutor : EFTest
    {
        [Fact]
        public void Teste()
        {
            _dbContext.Set<Autor>().Add(new Autor("Teste"));
            _dbContext.SaveChanges();
        }
    }
}
