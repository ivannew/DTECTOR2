using DTECTOR.View.SensoresView;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using DTECTOR.Modelo.Motor;
using DTECTOR.View;
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
        public async Task AgregarSensor()
        {
            SensorModel sensorModel = new SensorModel
            {
             
            };

            Uri Request = new Uri("http://ApiGas.somee.com/api/Sensor");

            var Client = new HttpClient();
            var json = JsonConvert.SerializeObject(sensorModel);
            var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync(Request, contentJson);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                await DisplayAlert("Mensaje", "Sensor Agregada Correctamente", "Ok");

            }
            else
            {
                await DisplayAlert("Mensaje", "Sensor no agregada", "OK");
            }

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
