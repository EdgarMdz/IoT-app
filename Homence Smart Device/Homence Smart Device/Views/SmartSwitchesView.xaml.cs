 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.CommunityToolkit.UI.Views;
using System.Windows;
using Homence_Smart_Device.Models;

namespace Homence_Smart_Device.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SmartSwitchesView : ContentPage
    {
        private User googleUser;
        private IGoogleManager Manager;
        private SmartSwitch @SmartSwitch { get; set; }
        ViewCell LastCell { get; set; }

        public SmartSwitchesView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        public SmartSwitchesView(User googleUser, IGoogleManager googleManager)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.googleUser = googleUser;
            userBtn.Source = ImageSource.FromUri(googleUser.Picture);
            Manager = googleManager;
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var se = sender as Expander;
            var image = (se.Header as StackLayout).Children[0] as ImageButton;
            await image.RotateXTo(se.IsExpanded ? -360 : -180, 250, easing: Easing.SinIn);
            
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        private async void ViewCell_Tapped(object sender, EventArgs e)
        {
            if (LastCell != null)
                LastCell.View.BackgroundColor = Color.Transparent;

            var viewcell = (ViewCell)sender;
            if (viewcell != null)
            {
                viewcell.View.BackgroundColor = Color.FromHex("0a0a0a");
                LastCell = viewcell;
            }

            await Application.Current.MainPage.Navigation.PushAsync(new ConfigureInactiveSwitch());
        }

        private async void LogOut(object sender, EventArgs e)
        {
            Manager.Logout();
            await Application.Current.MainPage.Navigation.PopAsync(true);
        }
    }
}