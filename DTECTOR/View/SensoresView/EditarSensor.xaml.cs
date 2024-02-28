﻿using DTECTOR.ViewModel.VMGas.VM_Sensores;
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
    public partial class EditarSensor : ContentPage
    {
        public EditarSensor()
        {
            InitializeComponent();
            BindingContext = new VMEditarSensor(Navigation);//cambios

        }
    }
}