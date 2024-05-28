using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using rowingmaterialweb.Shared.Entities;

namespace rowingmaterialweb.Frontend.Pages.Equipos
{
    public partial class EquipoForm
    {
        private EditContext editContext = null!;

        [EditorRequired, Parameter] public AppInstalacionesEquipo Equipo { get; set; } = null!;
        [EditorRequired, Parameter] public List<AppInstalacionesEquiposDetalle> Equipos { get; set; } = null!;
        [EditorRequired, Parameter] public List<string> Photos { get; set; } = null!;
        [EditorRequired, Parameter] public EventCallback OnValidSubmit { get; set; }
        [EditorRequired, Parameter] public EventCallback ReturnAction { get; set; }
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;

        protected override void OnInitialized()
        {
            editContext = new(Equipo);
        }

        public bool FormPostedSuccessfully { get; set; } = false;

        private async Task OnBeforeInternalNavigation(LocationChangingContext context)
        {
            var formWasEdited = editContext.IsModified();

            if (!formWasEdited || FormPostedSuccessfully)
            {
                return;
            }

            var result = await SweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = "Confirmaci�n",
                Text = "�Deseas abandonar la p�gina y perder los cambios?",
                Icon = SweetAlertIcon.Warning,
                ShowCancelButton = true
            });

            var confirm = !string.IsNullOrEmpty(result.Value);

            if (confirm)
            {
                return;
            }

            context.PreventNavigation();
        }
    }
}
