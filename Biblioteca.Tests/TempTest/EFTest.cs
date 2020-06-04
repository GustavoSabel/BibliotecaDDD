using Biblioteca.Infra;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Tests.TempTest
{
    public class EFTest
    {
        protected readonly BibliotecaContext _dbContext;
        private static int contador = 1;

        public EFTest()
        {
            var options = new DbContextOptionsBuilder<BibliotecaContext>()
                    .UseInMemoryDatabase($"Db{contador++}")
                    .UseLazyLoadingProxies()
                    .Options;            

            _dbContext = new BibliotecaContext(options);
        }
    }
}
