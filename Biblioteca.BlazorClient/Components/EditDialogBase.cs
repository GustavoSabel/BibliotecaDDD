using Microsoft.AspNetCore.Components;

namespace Biblioteca.BlazorClient.Components
{
    public abstract class EditDialogBase : ComponentBase
    {
        [Parameter]
        public RenderFragment Body { get; set; }

        protected bool ShowDialog { get; set; }

        [Parameter]
        public string Titulo { get; set; }

        public void Show()
        {
            ShowDialog = true;
            StateHasChanged();
        }

        public void Close()
        {
            ShowDialog = false;
            StateHasChanged();
        }
    }
}
