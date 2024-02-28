using DTECTOR.ViewModel.VMGas.VM_Motores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
    }
}