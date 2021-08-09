using Homence_Smart_Device.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            await Application.Current.MainPage.Navigation.PopAsync(true);
        }

        private void OnOffSwitch_Toggled(object sender, ToggledEventArgs e)
        {

        }

        private void ShowColorTab(object sender, EventArgs e)
        {
            HideAllTabs();
            ColorTab.IsVisible = true;
        }
        private void ShowTimerTab(object sender, EventArgs e)
        {
            HideAllTabs();
            TimerTab.IsVisible = true;
        }

        private void HideAllTabs()
        {
            ColorTab.IsVisible = false;
            TimerTab.IsVisible = false;
        }

        
    }
}