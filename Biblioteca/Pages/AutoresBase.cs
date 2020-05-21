using Biblioteca.Services;
using Microsoft.AspNetCore.Components;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Pages
{
    public class AutoresBase : ComponentBase
    {
        [Inject]
        public IAutorService AutorService { get; set; }

        public AutorModel[] Autores { get; private set; }

        protected override async Task OnInitializedAsync()
        {
            Autores = (await AutorService.ObterAutores()).ToArray();
        }
    }
}
