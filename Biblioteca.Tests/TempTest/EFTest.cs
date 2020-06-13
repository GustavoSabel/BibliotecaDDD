using Biblioteca.Infra;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Tests.TempTest
{
    public class EFTest
    {
        protected readonly BibliotecaContext _dbContext;
        private readonly string _dbName;
        private static int contador = 1;

        public EFTest()
        {
            _dbName = $"Db{contador++}";
            _dbContext = CriarDbContext();
        }

        protected BibliotecaContext CriarDbContext()
        {
            var options = new DbContextOptionsBuilder<BibliotecaContext>()
                                .UseInMemoryDatabase(_dbName)
                                .UseLazyLoadingProxies()
                                .Options;

            var dbContext = new BibliotecaContext(options);
            return dbContext;
        }
    }
}
