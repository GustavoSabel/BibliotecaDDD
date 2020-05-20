using Biblioteca.Domain.Common;
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

        public async Task Excluir(int id)
        {
            var entity = await ObterPorId(id);
            if (entity is null)
                throw new System.Exception($"Entidade {typeof(T).Name} com id {id} não foi encontrada");
            await Excluir(entity);
        }

        public Task Excluir(T aggregateRoot)
        {
            _context.Set<T>().Remove(aggregateRoot);
            return _context.SaveChangesAsync();
        }

        public ValueTask<T?> ObterPorId(int id)
        {
#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
            return _context.Set<T>().FindAsync(id);
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.
        }

        public Task Salvar(T aggregateRoot)
        {
            _context.Update(aggregateRoot);
            return _context.SaveChangesAsync();
        }
    }
}
