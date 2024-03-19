using DTECTOR.View;
using DTECTOR.View.SensoresView;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DTECTOR
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AgregarSensor();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
