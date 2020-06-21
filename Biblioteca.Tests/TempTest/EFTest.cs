using Biblioteca.Domain.Common.Events;
using Biblioteca.Infra;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Biblioteca.Tests.TempTest
{
    public class EFTest
    {
        protected readonly BibliotecaContext _dbContext;
        private readonly string _dbName;
        private static int _contador = 1;

        public EFTest()
        {
            _dbName = $"Db{_contador++}";
            _dbContext = CriarDbContext();
        }

        protected BibliotecaContext CriarDbContext()
        {
            var options = new DbContextOptionsBuilder<BibliotecaContext>()
                                .UseInMemoryDatabase(_dbName)
                                .UseLazyLoadingProxies()
                                .Options;

            var dbContext = new BibliotecaContext(options, Mock.Of<IBus>());
            return dbContext;
        }
    }
}
