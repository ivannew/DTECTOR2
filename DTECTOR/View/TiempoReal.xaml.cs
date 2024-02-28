using DTECTOR.ViewModel;
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
    public partial class TiempoReal : ContentPage
    {
        public TiempoReal()
        {
            InitializeComponent();
            BindingContext = new VMtimporeal(Navigation);

        }
    }
}