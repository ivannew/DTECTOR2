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
    public partial class EditarMotores : ContentPage
    {
        public EditarMotores()
        {
            InitializeComponent();
            BindingContext = new VMEditarMotor(Navigation);

        }
    }
}