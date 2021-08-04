using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Homence_Smart_Device.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfigureSwitch : ContentPage
    {
        public ConfigureSwitch()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        /*private void LightBulbBrandView_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(IsVisible))
            {
                var control = sender as LightBulbBrandView;
                if (control is null) return;

                if (control.IsVisible)
                    DisplayView(control);
            }
        }*/

        private void DisplayView(LightBulbBrandView control, double start, double end)
        {
            void displayAnimation(double height)
            => control.HeightRequest = height;


            control.Animate("DisplayAnimation", displayAnimation, start: start, end: end, easing: Easing.SinOut, length: 250);
            
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("", "Configuration saved.", "Ok");
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        private  void LightBulbTypeSelector_SelectedItemChanged(object sender, EventArgs e)
        {
            var control = sender as SelectLightBulbType;
            if(control.IsSmart)
            {
                BrandSelector.IsVisible = true;
                DisplayView(BrandSelector, 0, 202);
                
            }
            else
            {
                DisplayView(BrandSelector,202, 0);
            }

        }
    }
}