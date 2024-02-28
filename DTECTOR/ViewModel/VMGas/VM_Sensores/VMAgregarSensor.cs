using DTECTOR.View.SensoresView;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DTECTOR.ViewModel.VMGas.VM_Sensores
{
    public class VMAgregarSensor : BaseViewModel
    {
        public VMAgregarSensor(INavigation navigation)
        {
            Navigation = navigation;
        }
        #region Objetivo;



        #endregion
        #region PROCESOS
        public async Task Insertar()
        {

            await MostrarAlerta("Se guardó correctamente", "OK");
            await Volver();
        }

        private async Task MostrarAlerta(string mensaje, string botonOK)
        {
            await Application.Current.MainPage.DisplayAlert("Éxito", mensaje, botonOK);
        }
        public async Task Volver()
        {
            await Navigation.PushModalAsync(new sensores());
        }

        #endregion.

        #region CONTRUCTOR
        #endregion.

        #region COMANDOS
        public ICommand Insertarcommand => new Command(async () => await Insertar());
        public ICommand Volvercommand => new Command(async () => await Volver());
        #endregion
    }
}
