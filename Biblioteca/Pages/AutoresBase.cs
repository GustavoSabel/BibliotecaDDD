using Biblioteca.Services;
using Microsoft.AspNetCore.Components;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Pages
{
    public class AutoresBase : ComponentBase
    {
        [Inject]
        public AutorService AutorService { get; set; }

        protected AutorModel[] autores;

        protected override async Task OnInitializedAsync()
        {
            autores = (await AutorService.ObterAutores()).ToArray();
        }
    }
}
