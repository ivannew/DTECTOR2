using DTECTOR.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DTECTOR.ViewModel.VMGas.VM_Motores
{
    public class VMEditarMotor : BaseViewModel
    {
        public VMEditarMotor(INavigation navigation)
        {
            Navigation = navigation;
        }
        #region Process
        public async Task Alerta(string mensaje, string boton)
        {
            await Application.Current.MainPage.DisplayAlert("Exito", mensaje, boton);
        }
        public async Task Editar()
        {
            await Navigation.PushModalAsync(new Motor());
            await Alerta("Se edito correctamente", "OK");
        }
        public async Task Volver()
        {
            await Navigation.PushModalAsync(new Motor());
        }
        #endregion
        #region Commands
        public ICommand EditarCommand => new Command(async () => await Editar());
        public ICommand VolverCommand => new Command(async () => await Volver());
        #endregion
    }
}
