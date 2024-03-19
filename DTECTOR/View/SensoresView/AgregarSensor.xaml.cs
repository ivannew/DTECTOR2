using DTECTOR.Modelo.Motor;
using DTECTOR.ViewModel.VMGas.VM_Sensores;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DTECTOR.View;
using Xamarin.Forms;
using Newtonsoft;
using Xamarin.Forms.Xaml;
using System.Globalization;

namespace DTECTOR.View.SensoresView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgregarSensor : ContentPage
    {
        public AgregarSensor()
        {
            InitializeComponent();
            BindingContext = new VMAgregarSensor(Navigation);//le cambiamos nombre

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            string sensorId = Guid.NewGuid().ToString();

            // Crea un objeto SensorModel con los nuevos valores
            SensorModel sensorModel = new SensorModel
            {
                Id = sensorId,
                numero = int.Parse(txtnumero.Text),
                modelo = txtmodelo.Text,
                ubicacion = txtubicacion.Text
            };

            // Intenta analizar la fecha
            if (DateTime.TryParseExact(txtfecha.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fecha))
            {
                sensorModel.fecha = fecha;

                // Construye la URL para editar el sensor
                Uri Request = new Uri($"http://ApiGas.somee.com/api/Sensor/{sensorId}");

                // Crea una solicitud HTTP PUT para editar el sensor
                var Client = new HttpClient();
                var json = JsonConvert.SerializeObject(sensorModel);
                var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync(Request, contentJson);

                // Verifica el estado de la respuesta
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    await DisplayAlert("Mensaje", "Sensor editado correctamente", "Ok");
                }
                else
                {
                    await DisplayAlert("Mensaje", "se guardo correctamente tu sensor", "OK");
                }
            }
            else
            {
                await DisplayAlert("Mensaje", "Formato de fecha incorrecto", "OK");
            }
        }
    }
}