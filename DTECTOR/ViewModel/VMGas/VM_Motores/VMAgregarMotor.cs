using DTECTOR.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DTECTOR.ViewModel.VMGas.VM_Motores
{
    public class VMAgregarMotor : BaseViewModel
    {
        public VMAgregarMotor(INavigation navigation)
        {
            Navigation = navigation;
        }
        #region Process
        public async Task Alerta(string mensaje, string boton)
        {
            await Application.Current.MainPage.DisplayAlert("Exito", mensaje, boton);
        }
        public async Task Agregar()
        {
            await Navigation.PushModalAsync(new Motor());
            await Alerta("Se agrego correctamente", "OK");
        }
        public async Task Volver()
        {
            await Navigation.PushModalAsync(new Motor());
        }
        #endregion
        #region Commands
        public ICommand AgregarCommand => new Command(async () => await Agregar());
        public ICommand VolverCommand => new Command(async () => await Volver());
        #endregion
    }
}
