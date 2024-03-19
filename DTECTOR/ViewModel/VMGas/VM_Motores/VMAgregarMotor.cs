using DTECTOR.View;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using DTECTOR.Modelo.Motor;
using Newtonsoft.Json;

namespace DTECTOR.ViewModel.VMGas.VM_Motores
{
    public class VMAgregarMotor : BaseViewModel
    {
        private string _numeroMotor;
        private string _ubicacionMotor;
        private string _fecha;
        public string NumeroMotor
        {
            get { return _numeroMotor; }
            set { SetValue(ref _numeroMotor, value); }
        }
        public string UbicacionMotor
        {
            get { return _ubicacionMotor; }
            set { SetValue(ref _ubicacionMotor, value); }
        }
        public string Fecha
        {
            get { return _fecha; }
            set { SetValue(ref _fecha, value); }
        }
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
