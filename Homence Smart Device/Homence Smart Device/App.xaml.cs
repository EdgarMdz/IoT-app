﻿using Homence_Smart_Device.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("Syncopate-Bold.ttf", Alias = "Syncopate")]
[assembly: ExportFont("Poppins-Bold.ttf", Alias = "Poppins Bold")]
[assembly: ExportFont("Poppins-Medium.ttf", Alias = "Poppins Medium")]
namespace Homence_Smart_Device
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Device.SetFlags(new []{ "Shapes_Experimental", "Brush_Experimental" });
            MainPage = new NavigationPage(new MainPage());
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
