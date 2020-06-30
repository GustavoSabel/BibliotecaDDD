using Biblioteca.BlazorClient.Model;
using Biblioteca.BlazorClient.Pages.Livro;
using Biblioteca.BlazorClient.Services;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.BlazorClient.Pages
{
    public class LivrosBase : ComponentBase
    {
        [Inject]
        public ILivroService LivroService { get; set; }
        public List<LivroListaModel> Livros { get; private set; }

        protected override async Task OnInitializedAsync()
        {
            Livros = (await LivroService.ObterLivros()).ToList();
        }

        protected void Novo() { }
        protected void Editar(LivroListaModel livro) { }
        protected void Excluir(LivroListaModel livro) { }
    }
}
