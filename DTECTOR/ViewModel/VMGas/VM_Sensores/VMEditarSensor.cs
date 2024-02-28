using DTECTOR.View.SensoresView;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DTECTOR.ViewModel.VMGas.VM_Sensores
{
    public class VMEditarSensor : BaseViewModel
    {
        public VMEditarSensor(INavigation navigation)
        {
            Navigation = navigation;
        }
        #region Objetivo;


        #endregion
        #region PROCESOS

        public async Task Editar()
        {

            await Volver();
            await MostrarAlerta("Nota editada correctamente", "OK");

        }
        private async Task MostrarAlerta(string mensaje, string botonOK)
        {
            await Application.Current.MainPage.DisplayAlert("Éxito", mensaje, botonOK);
        }

        public async Task Eliminar()
        {


            await Volver();
            await MostrarAlerta("Nota Eliminada correctamente", "OK");

        }

        public async Task Volver()
        {
            await Navigation.PushModalAsync(new sensores());
        }


        #endregion.
        #region CONTRUCTOR

        #endregion.
        #region COMANDOS
        public ICommand Editarcommand => new Command(async () => await Editar());
        public ICommand Eliminarcommand => new Command(async () => await Eliminar());

        public ICommand Volvercommand => new Command(async () => await Volver());

        #endregion
    }
}
