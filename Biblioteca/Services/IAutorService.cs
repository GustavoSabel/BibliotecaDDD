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
    }
}