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
    public partial class NewEventView : ContentPage
    {
        public NewEventView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var siblings = ((sender as RadioButton).Parent as FlexLayout).Children.Where(
                (v) => v.GetType() == typeof(RadioButton)
            );

            foreach (RadioButton view in siblings)
            {
                view.TextColor = Color.FromHex("#BCC0C4");
            }
            (sender as RadioButton).TextColor = Color.FromHex("#EED7A7");

        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var label = sender as Label;

            if (label.TextColor == Color.FromHex("#DFC285"))
                label.TextColor = Color.DimGray;
            else
                label.TextColor = Color.FromHex("#DFC285");
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            var current = sender as Label;
            var sibling = ((sender as Label).Parent as FlexLayout).Children.First(v => (v as Label).Text != current.Text) as Label;

            current.TextColor= Color.FromHex("#DFC285");
            sibling.TextColor = Color.DimGray;
        }


        private async void SaveEvent(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PopAsync(true);
        }

        private async void CancelEvent(object sender, EventArgs e)
        {
            if (await DisplayAlert("Cancel", "¿Are you sure you?", "No", "Yes") == false)
                await Application.Current.MainPage.Navigation.PopAsync(true);
        }
    }
}