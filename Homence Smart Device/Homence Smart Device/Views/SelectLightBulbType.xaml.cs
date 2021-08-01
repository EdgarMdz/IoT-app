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
    public partial class SelectLightBulbType : Grid
    {
        public static new readonly BindableProperty BackgroundColorProperty =
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(SelectLightBulbType), defaultValue: Color.Black);
        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(SelectLightBulbType));
        public static readonly BindableProperty IsSmartProperty =
            BindableProperty.Create(nameof(IsSmart), typeof(bool), typeof(SelectLightBulbType), defaultValue: false);

        public new Color BackgroundColor { get => (Color)GetValue(BackgroundColorProperty); set => SetValue(BackgroundColorProperty, value); }
        public string Text { get => (string)GetValue(TextProperty); set => SetValue(TextProperty, value); }
        public bool IsSmart { get => (bool)GetValue(IsSmartProperty); set => SetValue(IsSmartProperty, value); }


        Color ActiveColor= Color.FromHex("FDDC97");
        Color InactiveColor = Color.White;

        public SelectLightBulbType()
        {
            InitializeComponent();
        }

        private async void filamentBtn_Clicked(object sender, EventArgs e)
        {
            var btn = sender as Button;

            if (btn is null) return;

            fadeOutSelection(170, 0);
            await Task.Delay(100);
            Grid.SetColumn(gradientBoxView, 0);
            fadeOutSelection(0, 170);

            ResetLabelColor();

            FilamentLbl.TextColor = ActiveColor;

            IsSmart = false;
        }

        private void ResetLabelColor()
        {
            gradientBoxView.IsVisible = true;

            FilamentLbl.TextColor = InactiveColor;
            fluorescentLbl.TextColor = InactiveColor;
            LEDLbl.TextColor = InactiveColor;
            SmartLbl.TextColor = InactiveColor;
        }

        private async void fluorescentBtn_Clicked(object sender, EventArgs e)
        {
            var btn = sender as Button;

            if (btn is null) return;

            fadeOutSelection(170, 0);
            await Task.Delay(100);
            Grid.SetColumn(gradientBoxView, 1);
            fadeOutSelection(0, 170);

            ResetLabelColor();

            fluorescentLbl.TextColor = ActiveColor;

            IsSmart = false;
        }

        private async void LEDBtn_Clicked(object sender, EventArgs e)
        {
            var btn = sender as Button;

            if (btn is null) return;

            fadeOutSelection(170, 0);
            await Task.Delay(100);
            Grid.SetColumn(gradientBoxView, 2);
            fadeOutSelection(0, 170);

            ResetLabelColor();

            LEDLbl.TextColor = ActiveColor;

            IsSmart = false;
        }

        private async void smartBtn_Clicked(object sender, EventArgs e)
        {
            var btn = sender as Button;

            if (btn is null) return;

            fadeOutSelection(170, 0);
            await Task.Delay(100);
            Grid.SetColumn(gradientBoxView, 3);
            fadeOutSelection(0, 210);

            ResetLabelColor();

            SmartLbl.TextColor = ActiveColor;
            IsSmart = true;
        }

        private void fadeOutSelection(double start, double end)
        {
            void fadeout(double val)
            {
                var integer = Convert.ToInt32(val);
                gradientStopMiddle.Color = Color.FromHex(integer.ToString("X") + "FDDC97");
            }
            gradientBoxView.Animate("fadeoutAnimation", callback: fadeout, start: start, end: end, length: 500, easing: Easing.SinOut);
        }
    }
}