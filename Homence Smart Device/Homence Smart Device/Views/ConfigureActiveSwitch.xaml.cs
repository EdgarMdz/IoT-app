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
    public partial class ConfigureActiveSwitch : ContentPage
    {
        public ConfigureActiveSwitch()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private  void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PopAsync(true);
        }

        private void OnOffSwitch_Toggled(object sender, ToggledEventArgs e)
        {

        }
    }
}