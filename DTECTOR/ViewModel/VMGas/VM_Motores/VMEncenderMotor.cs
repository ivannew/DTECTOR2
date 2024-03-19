using DTECTOR.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DTECTOR.ViewModel.VMGas.VM_Motores
{
    public class VMEncenderMotor : BaseViewModel
    {
        private bool _isEncenderClicked;
        public bool IsEncenderClicked
        {
            get { return _isEncenderClicked; }
            set
            {
                if (_isEncenderClicked != value)
                {
                    _isEncenderClicked = value;
                    OnPropertyChanged(nameof(IsEncenderClicked));
                    OnPropertyChanged(nameof(StackLayoutBackgroundColor));
                }
            }
        }

        public Color StackLayoutBackgroundColor
        {
            get
            {
                return IsEncenderClicked ? Color.FromHex("#C8E6C9") : Color.FromHex("#F0E8E8");
            }
        }
        #region Builder
        public VMEncenderMotor(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion
        #region Process
        public async Task DetallesMotores()
        {
            await Navigation.PushModalAsync(new Motor());
        }
        public async Task IRA()
        {
            await Navigation.PushModalAsync(new EncenderMotor());
        }
        public async Task Volver()
        {
            await Navigation.PushModalAsync(new TiempoReal());
        }
        public async Task CambiarColor()
        {
            IsEncenderClicked = true;
        }
        public async Task HandleEncenderClicked()
        {
            // Lógica adicional si es necesario
            IsEncenderClicked = true;
        }
        #endregion
        #region Commands
        public ICommand irCommand => new Command(async () => await IRA());
        public ICommand CambiarColorCommand => new Command(async () => await CambiarColor());
        public ICommand MotoresCommand => new Command(async () => await DetallesMotores());
        public ICommand VolverCommand => new Command(async () => await Volver());
        public ICommand TriggerCommand => new Command(async () => await HandleEncenderClicked());
        #endregion
        //public ICommand MotoresTrigerCommand => new Command<string>((accion) =>
        //{
        //    // Lógica para procesar la acción (encender o apagar)

        //    // Actualizar propiedades booleanas
        //    EncenderActivo = accion == "Encender";
        //    ApagarActivo = accion == "Apagar";
        //});
    }
}
