using DTECTOR.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DTECTOR.ViewModel.VMGas
{
    public class VMSignIn : BaseViewModel
    {
        #region Constructor
        public VMSignIn(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion
        #region c
        private bool showError;

        public bool ShowError
        {
            get { return showError; }
            set { SetProperty(ref showError, value); }
        }
        #endregion
        #region Proces
        public async Task LogIn()
        {
            await Navigation.PushModalAsync(new Login());
        }

        public async Task GoToMain1(string email)
        {
            bool emailExists = VerificarExistenciaCorreoONumero(email);

            if (emailExists)
            {
                ShowError = true;
                MessagingCenter.Send(this, "EmailOrNumberExists");
            }
            else
            {
                ShowError = false;

                if (!email.Equals("josecin@gmail.com", StringComparison.OrdinalIgnoreCase))
                {
                    await Navigation.PushModalAsync(new TiempoReal());
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Éxito", "Usuario registrado exitosamente", "OK");
                }
            }
        }

        private bool VerificarExistenciaCorreoONumero(string email)
        {

            return email.Equals("josecin@gmail.com", StringComparison.OrdinalIgnoreCase);
        }
        #endregion

        #region Commands
        public ICommand LoginCommand => new Command(async () => await LogIn());
        public ICommand GoMainCommand => new Command<string>(async (email) => await GoToMain1(email));
        #endregion
    }
}

