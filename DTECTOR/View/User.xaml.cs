using DTECTOR.ViewModel.VMGas;
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
    public partial class User : ContentPage
    {
        public User()
        {
            InitializeComponent();
            BindingContext = new VMUser(Navigation);

        }
    }
}