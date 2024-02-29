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
        private bool _encenderActivo;
        private bool _apagarActivo;

        public bool EncenderActivo
        {
            get => _encenderActivo;
            set => SetProperty(ref _encenderActivo, value);
        }

        public bool ApagarActivo
        {
            get => _apagarActivo;
            set => SetProperty(ref _apagarActivo, value);
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
        #endregion
        #region Commands
        public ICommand irCommand => new Command(async () => await IRA());
        public ICommand MotoresCommand => new Command(async () => await DetallesMotores());
        public ICommand VolverCommand => new Command(async () => await Volver());
        #endregion
        public ICommand MotoresTrigerCommand => new Command<string>((accion) =>
        {
            // Lógica para procesar la acción (encender o apagar)

            // Actualizar propiedades booleanas
            EncenderActivo = accion == "Encender";
            ApagarActivo = accion == "Apagar";
        });
    }
}
