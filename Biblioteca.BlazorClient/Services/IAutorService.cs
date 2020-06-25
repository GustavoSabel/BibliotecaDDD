using Biblioteca.Api.Dtos;
using Biblioteca.BlazorClient.Model;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Biblioteca.BlazorClient.Services
{
    public interface IAutorService
    {
        [Get("/api/autor")]
        Task<IEnumerable<AutorModel>> ObterAutores();

        [Get("/api/autor/{id}")]
        Task<AutorModel> ObterPorId(int id);

        [Post("/api/autor")]
        Task<AutorModel> Post([Body] SalvarAutorCommand autor);

        [Put("/api/autor/{id}")]
        Task Put(int id, [Body] AtualizarAutorCommand autor);

        [Delete("/api/autor/{id}")]
        Task Delete(int id);
    }
}