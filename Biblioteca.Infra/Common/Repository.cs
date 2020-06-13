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

        public async ValueTask<T?> ObterPorIdAsync(int id)
        {
            var result = (T?)(await _context.Set<T>().FindAsync(id));
            if (result is object)
                await PosObterAsync(result);
            return result;
        }

        public virtual Task PosObterAsync(T aggregateRoot) => Task.CompletedTask;

        public Task SalvarAsync(T aggregateRoot)
        {
            _context.Attach(aggregateRoot);
            return _context.SaveChangesAsync();
        }
    }
}
