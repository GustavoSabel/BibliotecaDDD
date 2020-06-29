using Biblioteca.BlazorClient.Model;
using Biblioteca.BlazorClient.Services;
using Biblioteca.BlazorClient.Components;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.BlazorClient.Pages
{
    public class AutoresBase : ComponentBase
    {
        [Inject]
        public IAutorService AutorService { get; set; }

        public List<AutorModel> Autores { get; private set; }

        protected EditAutorDialog EditAutorDialog { get; set; }

        public int AutorEditarId { get; private set; }

        protected override async Task OnInitializedAsync()
        {
            Autores = (await AutorService.ObterAutores()).ToList();
        }

        protected async Task AddAutor()
        {
            await EditAutorDialog.Show();
        }

        public async Task EditarAutor(AutorModel autor)
        {
            await EditAutorDialog.Show(autor.Id);
        }

        public async Task ExcluirAutor(AutorModel autor)
        {
            await AutorService.Delete(autor.Id);
            Autores = (await AutorService.ObterAutores()).ToList();
            StateHasChanged();
        }

        protected void EditAutorDialog_Salvo(AutorModel autor)
        {
            var index = Autores.FindIndex(x => x.Id == autor.Id);
            if (index < 0)
            {
                Autores.Add(autor);
            }
            else
            {
                Autores.RemoveAt(index);
                Autores.Insert(index, autor);
            }
            StateHasChanged();
        }

        protected void EditAutordialog_Excluido(AutorModel autor)
        {
            var index = Autores.FindIndex(x => x.Id == autor.Id);
            if (index > 0)
            {
                Autores.RemoveAt(index);
                StateHasChanged();
            }
        }
    }
}
