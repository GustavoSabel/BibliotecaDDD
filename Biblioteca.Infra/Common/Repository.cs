using Biblioteca.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Biblioteca.Infra.Common
{
    public abstract class Repository<T> : IRepository<T> where T : AggregateRoot
    {
        protected readonly BibliotecaContext _context;
        protected DbSet<T> Set => _context.Set<T>();

        public Repository(BibliotecaContext context)
        {
            _context = context;
        }

        public async Task ExcluirAsync(int id)
        {
            var entity = await ObterPorIdAsync(id);
            if (entity is null)
                throw new System.Exception($"Entidade {typeof(T).Name} com id {id} não foi encontrada");
            await ExcluirAsync(entity);
        }

        public Task ExcluirAsync(T aggregateRoot)
        {
            _context.Set<T>().Remove(aggregateRoot);
            return _context.SaveChangesAsync();
        }

        public ValueTask<T?> ObterPorIdAsync(int id)
        {
#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
            return _context.Set<T>().FindAsync(id);
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.
        }

        public Task SalvarAsync(T aggregateRoot)
        {
            _context.Update(aggregateRoot);
            return _context.SaveChangesAsync();
        }
    }
}
