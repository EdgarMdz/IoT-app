using Homence_Smart_Device.Models;
using Homence_Smart_Device.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Homence_Smart_Device
{
    public partial class MainPage : ContentPage
    {
        private readonly IGoogleManager googleManager;
        User GoogleUser = new User();

        public bool IsLogedIn { get; set; }
        bool animate;

        public MainPage()
        {
            InitializeComponent();
            FrameOpacity();
            NavigationPage.SetHasNavigationBar(this, false);
            googleManager = DependencyService.Get<IGoogleManager>();
            this.Appearing += new EventHandler(MainPage_Appearing);
            this.Disappearing += new EventHandler(MainPage_Disappearing);
        }

        private void MainPage_Disappearing(object sender, EventArgs e)
        {
            animate = false;
        }

        private void MainPage_Appearing(object sender, EventArgs e)
        {
            BlinkAnimation();
        }

        private void CheckUserLoggedIn()
        {
            googleManager.Login(OnLoginComplete);
        }

        private  void OnLoginComplete(User googleUser, string message)
        {
            if (googleUser != null)
            {
                GoogleUser = googleUser;
                UserTxt.Text = GoogleUser.Email;
                IsLogedIn = true;
                 Application.Current.MainPage.Navigation.PushAsync(new SmartSwitchesView(GoogleUser,googleManager));
            }
            else
            {
                 DisplayAlert("Message", message, "OK");
            }
        }

        private async void FrameOpacity()
        {
            Thread.Sleep(500);
            await CoverFrame.FadeTo(0, 3000, Easing.BounceOut);

            BlinkAnimation();
        }

        private async void BlinkAnimation()
        {
            void setOpacity(double opacity) => CoverFrame.Opacity = opacity;

            Random random = new Random();
            animate = true;
            while (animate)
            {

                CoverFrame.Animate("FadeOut", callback: setOpacity, start: (double)random.Next(1, 4) / 10, end: 0, length: 1000, easing: Easing.BounceOut);
                await Task.Delay(random.Next(2000, 4000));
            }
        }

        void OnTapped(object sender, EventArgs e)
        {
            CoverFrame.Opacity = 0.1;
        }

        private async void SignInBtn_Clicked(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new SmartSwitchesView());
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            CheckUserLoggedIn();
        }
    }
}
