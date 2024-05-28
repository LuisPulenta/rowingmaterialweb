using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using rowingmaterialweb.Frontend.Repositories;
using rowingmaterialweb.Shared.Entities;
using System.Net;

namespace rowingmaterialweb.Frontend.Pages.Equipos
{
    public partial class EquipoEdit
    {
        private AppInstalacionesEquipo? equipo;
        private List<AppInstalacionesEquiposDetalle>? equipos;
        public List<string> photos = [];
        private EquipoForm? equipoForm;

        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Inject] private IRepository Repository { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;
        [EditorRequired, Parameter] public int Id { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            var responseHttp = await Repository.GetAsync<AppInstalacionesEquipo>($"api/appinstalacionesequipos/{Id}");

            if (responseHttp.Error)
            {
                if (responseHttp.HttpResponseMessage.StatusCode == HttpStatusCode.NotFound)
                {
                    NavigationManager.NavigateTo("equipos");
                }
                else
                {
                    var messageError = await responseHttp.GetErrorMessageAsync();
                    await SweetAlertService.FireAsync("Error", messageError, SweetAlertIcon.Error);
                }
            }
            else
            {
                equipo = responseHttp.Response;
            }

            var responseHttp2 = await Repository.GetAsync<List<AppInstalacionesEquiposDetalle>>($"api/appinstalacionesequiposdetalles/{Id}");
            if (responseHttp2.Error)
            {
                if (responseHttp.HttpResponseMessage.StatusCode == HttpStatusCode.NotFound)
                {
                    NavigationManager.NavigateTo("equipos");
                }
                else
                {
                    var messageError = await responseHttp.GetErrorMessageAsync();
                    await SweetAlertService.FireAsync("Error", messageError, SweetAlertIcon.Error);
                }
            }
            else
            {
                equipos = responseHttp2.Response;
                if (equipos != null)
                {
                    foreach (var equipo in equipos!)
                    {
                        photos.Add(equipo.LinkFotoFullPath);
                    }
                }
                var a = 1;
            }
        }

        private async Task EditAsync()
        {
            var responseHTTP = await Repository.PutAsync("api/appinstalacionesequipos", equipo);

            if (responseHTTP.Error)
            {
                var mensajeError = await responseHTTP.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", mensajeError, SweetAlertIcon.Error);
                return;
            }

            Return();
            var toast = SweetAlertService.Mixin(new SweetAlertOptions
            {
                Toast = true,
                Position = SweetAlertPosition.Center,
                ShowConfirmButton = true,
                Timer = 3000,
                Background = "LightSkyBlue",
            });
            await toast.FireAsync(icon: SweetAlertIcon.Success, message: "Cambios guardados con éxito.");
        }


        private void Return()
        {
            equipoForm!.FormPostedSuccessfully = true;
            NavigationManager.NavigateTo("equipos");
        }
    }
}
