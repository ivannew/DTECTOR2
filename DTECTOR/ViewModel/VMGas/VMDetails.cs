using DTECTOR.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DTECTOR.ViewModel.VMGas
{
    public class VMDetails : BaseViewModel
    {
        #region Constructor
        public VMDetails(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion
        #region Process
        public async Task Volver()
        {
            await Navigation.PushModalAsync(new TiempoReal());
        }
        public async Task Motores()
        {
            await Navigation.PushModalAsync(new Motor());
        }
        #endregion
        #region Commands
        public ICommand VolverCommand => new Command(async () => await Volver());
        public ICommand MotoresCommand => new Command(async () => await Motores());
        #endregion
    }
}