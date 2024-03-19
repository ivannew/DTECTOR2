using DTECTOR.View;
using DTECTOR.View.SensoresView;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DTECTOR.ViewModel.VMGas.VM_Sensores
{
    public class VMSensor : BaseViewModel
    {
        public VMSensor(INavigation navigation)
        {
            Navigation = navigation;
        }

        public async Task IrARegistro()
        {
            await Navigation.PushModalAsync(new AgregarSensor());
        }

        public async Task IrAEditar()
        {
            await Navigation.PushModalAsync(new EditarSensor());
        }
        public async Task Volver()
        {
            await Navigation.PushModalAsync(new TiempoReal());
        }
        public async Task Alerta(string mensaje, string boton)
        {
            await Application.Current.MainPage.DisplayAlert("Exito", mensaje, boton);
        }
        public async Task Eliminar()
        {
            await Alerta("Se elimino correctamente", "OK");
        }
        public ICommand IrARegistrocommand => new Command(async () => await IrARegistro());
        public ICommand EditarCommand => new Command(async () => await IrAEditar());
        public ICommand VolverCommand => new Command(async () => await Volver());
        public ICommand EliminarCommand => new Command(async () => await Eliminar());

    }
}
