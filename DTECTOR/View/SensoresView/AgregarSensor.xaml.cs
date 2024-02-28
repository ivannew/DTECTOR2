using DTECTOR.ViewModel.VMGas.VM_Sensores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
    }
}