using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Biblioteca.Infra
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(
        //        @"Server=.;Database=Biblioteca;Integrated Security=True");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
