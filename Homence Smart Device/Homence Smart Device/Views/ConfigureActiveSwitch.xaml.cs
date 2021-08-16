using System;
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
            ColorTabBtn.TextColor = Color.FromHex("FFDE9A");
        }
        private void ShowTimerTab(object sender, EventArgs e)
        {
            HideAllTabs();
            TimerTab.IsVisible = true;
            TimerTabBtn.TextColor = Color.FromHex("FFDE9A");
        }

        private void HideAllTabs()
        {
            HeaderLbl.IsVisible = true;
            OnOffSwitch.IsVisible = true;
            NewEventBtn.IsVisible = false;

            ColorTab.IsVisible = false;
            ColorTabBtn.TextColor = Color.FromHex("939292");

            TimerTab.IsVisible = false;
            TimerTabBtn.TextColor = Color.FromHex("939292"); 
            
            ConfigTab.IsVisible = false;
            ConfigTabBtn.TextColor = Color.FromHex("939292");
            
            ScheduleTab.IsVisible = false;
            SchedulesBtn.TextColor = Color.FromHex("939292");
        }

        private void ShowConfigTab(object sender, EventArgs e)
        {
            HideAllTabs();
            HeaderLbl.IsVisible = false;
            ConfigTab.IsVisible = true;
            ConfigTabBtn.TextColor = Color.FromHex("FFDE9A");
        }

        private void ShowScheduleTab(object sender, EventArgs e)
        {
            HideAllTabs();
            ScheduleTab.IsVisible = true;
            SchedulesBtn.TextColor = Color.FromHex("FFDE9A");
            NewEventBtn.IsVisible = true;
            OnOffSwitch.IsVisible = false;
        }

        private async void ScheduleTab_ItemClicked(object sender, EventArgs e)
        {
            await DisplayAlert("thing clicked", "something was clicked", "fuck off");
        }

        private async void CreateNewEvent(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new NewEventView());
        }
    }
}