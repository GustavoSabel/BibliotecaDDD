using Biblioteca.Domain.Common;
using System;
using System.Threading.Tasks;

namespace Biblioteca.Infra.Common
{
    public abstract class Repository<T> : IRepository<T> where T : AggregateRoot
    {
        protected readonly BibliotecaContext _context;

        public Repository(BibliotecaContext context)
        {
            _context = context;
        }

        public ValueTask<T?> GetById(long id)
        {
#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
            return _context.Set<T>().FindAsync(id);
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.
        }

        public async Task Save(T aggregateRoot)
        {
            _context.Update(aggregateRoot);
            await _context.SaveChangesAsync();
        }
    }
}
