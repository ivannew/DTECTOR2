using DTECTOR.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DTECTOR.ViewModel.VMGas.VM_Motores
{
    public class VMMotores : BaseViewModel
    {
        #region Builder
        public VMMotores(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion
        #region Process
        public async Task Volver()
        {
            await Navigation.PushModalAsync(new MainPage());
        }
        public async Task Crear()
        {
            await Navigation.PushModalAsync(new AgregarMotor());
        }
        public async Task Editar()
        {
            await Navigation.PushModalAsync(new EditarMotores());
        }
        public async Task Alerta(string mensaje, string boton)
        {
            await Application.Current.MainPage.DisplayAlert("Exito", mensaje, boton);
        }
        public async Task Eliminar()
        {
            await Alerta("Se elimino correctamente", "OK");
        }
        #endregion
        #region Commands
        public ICommand VolverCommand => new Command(async () => await Volver());
        public ICommand CrearCommand => new Command(async () => await Crear());
        public ICommand EditarCommand => new Command(async () => await Editar());
        public ICommand EliminarCommand => new Command(async () => await Eliminar());
        #endregion
    }
}
