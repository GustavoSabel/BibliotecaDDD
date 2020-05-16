using Biblioteca.Infra;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Biblioteca.Tests.TempTest
{
    public class EFTest
    {
        protected readonly BibliotecaContext _dbContext;

        public EFTest()
        {
            var options = new DbContextOptionsBuilder<BibliotecaContext>()
                    .UseSqlite(CreateInMemoryDatabase())
                    .Options;            

            _dbContext = new BibliotecaContext(options);
            _dbContext.Database.Migrate();
        }

        private static DbConnection CreateInMemoryDatabase()
        {
            var connection = new SqliteConnection("Filename=:memory:");
            connection.Open();
            return connection;
        }
    }
}
