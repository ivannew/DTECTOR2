using DTECTOR.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DTECTOR.ViewModel.VMGas
{
    public class VMUser : BaseViewModel
    {
        #region Constructor
        public VMUser(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion
        #region Proces
        public async Task Details()
        {
            await Navigation.PushModalAsync(new TiempoReal());
        }
        public async Task closesesion()
        {
            await Navigation.PushModalAsync(new Login());
        }
        #endregion
        #region Commands
        public ICommand DetailsCommand => new Command(async () => await Details());
        public ICommand CloseSesionCommand => new Command(async () => await closesesion());
        #endregion
    }
}
