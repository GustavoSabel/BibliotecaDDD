using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Biblioteca.Services
{
    public interface IAutorService
    {
        [Get("/api/autor")]
        Task<IEnumerable<AutorModel>> ObterAutores();

        [Get("/api/autor/{id}")]
        Task<AutorModel> ObterPorId(int id);

        [Post("/api/autor")]
        Task<AutorModel> Post([Body] AutorModel autor);

        [Put("/api/autor/{id}")]
        Task Put(int id, [Body] AutorModel autor);

        [Delete("/api/autor/{id}")]
        Task Delete(int id);
    }
}