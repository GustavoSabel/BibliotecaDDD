using Biblioteca.Api.Dtos;
using Biblioteca.BlazorClient.Model;
using Biblioteca.BlazorClient.Services;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Biblioteca.BlazorClient.Components
{
    public class EditAutorDialogBase : ComponentBase
    {
        [Inject] public IAutorService AutorService { get; set; }

        [Parameter]
        public EventCallback<AutorModel> SalvoEventCallback { get; set; }
        [Parameter]
        public EventCallback<AutorModel> ExcluidoEventCallback { get; set; }

        protected EditDialog EditDialog { get; set; }

        public AutorModel Autor { get; private set; } = new AutorModel();

        public string Titulo => Autor.Id == 0 ? "Novo Autor" : "Editar Autor";

        public async Task Show(int autorId = 0)
        {
            if (autorId == 0)
                Autor = new AutorModel();
            else
                Autor = await AutorService.ObterPorId(autorId);

            EditDialog.Show();
        }

        public void Close()
        {
            EditDialog.Close();
        }

        public async Task HandleValidSubmit()
        {
            if (Autor.Id > 0)
            {
                await AutorService.Put(Autor.Id, new AtualizarAutorCommand
                {
                    Nome = Autor.Nome,
                    DataNascimento = Autor.DataNascimento
                });
            }
            else
            {
                Autor = await AutorService.Post(new SalvarAutorCommand
                {
                    Nome = Autor.Nome,
                    DataNascimento = Autor.DataNascimento
                });
            }
            await SalvoEventCallback.InvokeAsync(Autor);
            Close();
        }

        public async Task Excluir_Click()
        {
            await AutorService.Delete(Autor.Id);
            await ExcluidoEventCallback.InvokeAsync(Autor);
            Close();
        }
    }
}
