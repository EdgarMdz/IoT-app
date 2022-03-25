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
    public partial class LightBulbColorView : ContentView
    {
        public LightBulbColorView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            var btn = sender as ImageButton;
            
            foreach (View view in SavedColorsFlexLayout.Children)
            {
                if (CalculateDeltaE(view.BackgroundColor, ColorPicker.SelectedColor) < 0.15)
                {
                    Console.WriteLine(CalculateDeltaE(view.BackgroundColor, ColorPicker.SelectedColor));
                    view.Animate("ScaleAnimation", callback: val => view.Opacity = val, start: 1, end: 0.5, easing: Easing.SinIn, length: 500);
                    view.Animate("ScaleAnimation", callback: val => view.Opacity = val, start: 0.5, end: 1, easing: Easing.SinIn, length: 500);
                    return;
                }
            }

            Button button = new Button()
            {
                CornerRadius = 50,
                WidthRequest = 40,
                HeightRequest = 40,
                BackgroundColor = ColorPicker.SelectedColor,
                BorderColor = Color.White,
                BorderWidth = 3,
                Margin = new Thickness(10)
            };
             
            SavedColorsFlexLayout.Children.Add(button);

            void scale(double size) => button.Opacity = size;


            button.Animate("ScaleAnimation", callback: scale, start: 0, end: 1, easing: Easing.SinIn, length: 500);

            button.Clicked += SetColor_Clicked;
        }

        private double CalculateDeltaE(Color Color1, Color Color2)
        {
            double dR = Math.Pow(Color1.R - Color2.R, 2);
            double dG = Math.Pow(Color1.G - Color2.G, 2);
            double dB = Math.Pow(Color1.B - Color2.B, 2);
            

            return Math.Sqrt(dR + dG + dB); ;
        }

        private void SetColor_Clicked(object sender, EventArgs e)
        {
            ColorPicker.SelectedColor = (sender as Button).BackgroundColor;
        }

        private void OnOffSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            ColorPicker.IsEnabled = e.Value;
            SavedColorsFlexLayout.IsEnabled = e.Value;
        }
    }
}