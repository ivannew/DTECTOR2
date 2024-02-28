using DTECTOR.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DTECTOR.ViewModel.VMGas
{
    public class VMLogin : BaseViewModel
    {
        #region Variables
        private string email;
        private string password;
        private bool showError;

        #endregion
        #region Constructor
        public VMLogin(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion
        #region Proces
        public async Task RegistrarUser()
        {
            await Navigation.PushModalAsync(new SignIn());
        }

        public async Task GoToMain()
        {
            await Navigation.PushModalAsync(new TiempoReal());
        }
        public bool ShowError
        {
            get { return showError; }
            set { SetProperty(ref showError, value); }
        }

        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }

        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }
        #endregion

        #region F



        public async Task SignInUser()
        {
            if (Email == "josecin@gmail.com" && Password == "1234")
            {
                await GoToMain();
            }
            else
            {
                ShowError = true; // Este es el que hace que se muestre el mensaje en la vista XD
            }
        }


        #endregion
        #region Commands
        public ICommand IniciarCommand => new Command(async () => await SignInUser());
        public ICommand registrarCommand => new Command(async () => await RegistrarUser());
        #endregion
    }
}
