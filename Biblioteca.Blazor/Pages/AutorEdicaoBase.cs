using Biblioteca.Api.Dtos;
using Biblioteca.Blazor.Model;
using Biblioteca.Blazor.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace Biblioteca.Blazor.Pages
{
    public class AutorEdicaoBase : ComponentBase
    {
        [Inject] public IAutorService AutorService { get; set; }

        [Inject] public NavigationManager NavManager { get; set; }

        [Parameter] public int? Id { get; set; }

        public AutorModel Autor { get; private set; } 

        protected override async Task OnInitializedAsync()
        {
            if (Id.HasValue)
                Autor = await AutorService.ObterPorId(Id.Value);
            else
                Autor = new AutorModel();
        }

        public async Task Excluir_Click()
        {
            await AutorService.Delete(Autor.Id);
            NavManager.NavigateTo("/Autores");
        }

        public string Mensagem { get; private set; } = "";
        public string MensagemStatus { get; private set; } = "";

        public async Task HandleValidSubmit()
        {
            try
            {
                if (Autor.Id > 0)
                {
                    await AutorService.Put(Autor.Id, new AtualizarAutorDto
                    {
                        Nome = Autor.Nome,
                        DataNascimento = Autor.DataNascimento
                    });
                    Mensagem = "Salvo com sucesso!";
                    MensagemStatus = "alert-success";
                }
                else
                {
                    Autor = await AutorService.Post(new SalvarAutorDto
                    {
                        Nome = Autor.Nome,
                        DataNascimento = Autor.DataNascimento
                    });
                    Mensagem = "Salvo com sucesso!";
                    MensagemStatus = "alert-success";
                }
            }
            catch (Exception ex)
            {
                Mensagem = "Erro ao salvar. " + ex.Message;
                MensagemStatus = "alert-danger";
            }
        }
    }
}
