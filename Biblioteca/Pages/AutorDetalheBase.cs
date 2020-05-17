using Biblioteca.Domain.LivroContext;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Biblioteca.Pages
{
    public class AutorDetalheBase : ComponentBase
    {
        [Inject]
        public IAutorRepository AutorRepository { get; set; }

        [Parameter]
        public int Id { get; set; }

        public Autor Autor { get; private set; }

        protected override async Task OnInitializedAsync()
        {
            Autor = await AutorRepository.GetById(Id);
        }
    }
}
