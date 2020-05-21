using Biblioteca.Services;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Biblioteca.Pages
{
    public class AutorDetalheBase : ComponentBase
    {
        [Inject]
        public IAutorService AutorService { get; set; }

        [Parameter]
        public int Id { get; set; }

        public AutorModel Autor { get; private set; }

        protected override async Task OnInitializedAsync()
        {
            Autor = await AutorService.ObterPorId(Id);
        }
    }
}
