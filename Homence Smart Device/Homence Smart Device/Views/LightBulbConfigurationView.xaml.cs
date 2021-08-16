using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Homence_Smart_Device.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LightBulbConfigurationView : ContentView
    {
        public static readonly BindableProperty LightBulbNameProperty =
            BindableProperty.Create(nameof(LightBulbName), typeof(string), typeof(LightBulbConfigurationView));

        /// <summary>
        /// Gets or sets the name of the device.
        /// </summary>
        public string LightBulbName { get => (string)GetValue(LightBulbNameProperty); set => SetValue(LightBulbNameProperty, value); }

        public LightBulbConfigurationView()
        {
            InitializeComponent();
            BindingContext = LightBulbName;
        }

        private void LightBulbTypeSelector_SelectedItemChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var control = sender as SelectLightBulbType;
            if (control.IsSmart)
            {
                BrandSelector.IsVisible = true;
                DisplayView(BrandSelector, 0, 202);

            }
            else
            {
                DisplayView(BrandSelector, 202, 0);
            }
        }

        private void DisplayView(LightBulbBrandView control, double start, double end)
        {
            void displayAnimation(double height) => control.HeightRequest = height;
            control.Animate("DisplayAnimation", displayAnimation, start: start, end: end, easing: Easing.SinOut, length: 250);
        }

        private void LightBulbNameEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            LightBulbName = e.NewTextValue;
        }
    }
}