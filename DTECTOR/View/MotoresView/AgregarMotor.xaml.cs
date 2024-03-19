using DTECTOR.ViewModel.VMGas.VM_Motores;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using DTECTOR.Modelo;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DTECTOR.Modelo.Motor;
using System.Globalization;


namespace DTECTOR.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgregarMotor : ContentPage
    {
        public AgregarMotor()
        {
            InitializeComponent();
            BindingContext = new VMAgregarMotor(Navigation);

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            // Validar la entrada de usuario
            if (string.IsNullOrEmpty(txtid.Text) || string.IsNullOrEmpty(txtnumero.Text) || string.IsNullOrEmpty(txtubicacion.Text) || string.IsNullOrEmpty(txtfecha.Text))
            {
                await DisplayAlert("Error", "Por favor, complete todos los campos.", "OK");
                return;
            }

            int numeroMotor;
            if (!int.TryParse(txtnumero.Text, out numeroMotor))
            {
                await DisplayAlert("Error", "Por favor, ingrese un número válido para el motor.", "OK");
                return;
            }

            DateTime fecha;
            if (!DateTime.TryParse(txtfecha.Text, out fecha))
            {
                await DisplayAlert("Error", "Por favor, ingrese una fecha válida.", "OK");
                return;
            }

            // Crear el objeto MotorModel con los datos actualizados
            MotorModel mo = new MotorModel
            {
                Id = txtid.Text,
                numeroMotor = numeroMotor,
                ubicacionMotor = txtubicacion.Text,
                fecha = fecha
            };

            // Enviar la solicitud HTTP para actualizar el registro en la base de datos
            Uri RequestUri = new Uri("http://www.ApiGas.somee.com/Motor/" + txtid.Text); // Suponiendo que necesitas pasar el ID del motor en la URL
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(mo);
            var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync(RequestUri, contentJson); // Utiliza el método PUT para actualizar el registro

            // Manejar la respuesta
            if (response.StatusCode == HttpStatusCode.OK)
            {
                await DisplayAlert("Datos", "Se actualizó correctamente la información", "OK");
                txtid.Text = "";
                txtnumero.Text = "";
                txtubicacion.Text = "";
                txtfecha.Text = ""; // Limpia el campo de fecha después de la operación
            }
            else
            {
                await DisplayAlert("Datos", "Ocurrió un error", "OK");
            }
        }
    }
}