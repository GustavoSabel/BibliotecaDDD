using Biblioteca.BlazorClient.Model;
using Biblioteca.Dto.Livro;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Biblioteca.BlazorClient.Services
{
    public interface ILivroService
    {
        [Get("/api/livro")]
        Task<IEnumerable<LivroListaModel>> ObterLivros();

        [Get("/api/livro/{id}")]
        Task<LivroModel> ObterPorId(int id);

        [Post("/api/livro")]
        Task<LivroModel> Post([Body] SalvarLivroCommand livro);

        [Put("/api/livro/{id}")]
        Task<LivroModel> Put(int id, [Body] SalvarLivroCommand livro);

        [Delete("/api/livro/{id}")]
        Task Delete(int id);
    }
}