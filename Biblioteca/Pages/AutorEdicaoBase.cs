﻿using Biblioteca.Services;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Biblioteca.Pages
{
    public class AutorEdicaoBase : ComponentBase
    {
        [Inject]
        public IAutorService AutorService { get; set; }

        [Inject]
        public NavigationManager NavManager { get; set; }

        [Parameter]
        public int Id { get; set; }

        public AutorModel Autor { get; private set; }

        protected override async Task OnInitializedAsync()
        {
            if (Id > 0)
                Autor = await AutorService.ObterPorId(Id);
            else
                Autor = new AutorModel();
        }

        public async void Salvar_Click()
        {
            if (Autor.Id > 0)
                await AutorService.Put(Autor.Id, Autor);
            else
                Autor = await AutorService.Post(Autor);

            NavManager.NavigateTo("/Autores");
        }

        public async void Excluir_Click()
        {
            await AutorService.Delete(Autor.Id);

            NavManager.NavigateTo("/Autores");
        }
    }
}
