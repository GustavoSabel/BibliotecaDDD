using Biblioteca.Api.Dtos;
using Biblioteca.Blazor.Model;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Biblioteca.Blazor.Services
{
    public interface IAutorService
    {
        [Get("/api/autor")]
        Task<IEnumerable<AutorModel>> ObterAutores();

        [Get("/api/autor/{id}")]
        Task<AutorModel> ObterPorId(int id);

        [Post("/api/autor")]
        Task<AutorModel> Post([Body] SalvarAutorDto autor);

        [Put("/api/autor/{id}")]
        Task Put(int id, [Body] AtualizarAutorDto autor);

        [Delete("/api/autor/{id}")]
        Task Delete(int id);
    }
}