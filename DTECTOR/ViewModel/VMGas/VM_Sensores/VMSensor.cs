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
        public ICommand IrARegistrocommand => new Command(async () => await IrARegistro());
        public ICommand IrAEditarCommand => new Command(async () => await IrAEditar());
        public ICommand VolverCommand => new Command(async () => await Volver());

    }
}
