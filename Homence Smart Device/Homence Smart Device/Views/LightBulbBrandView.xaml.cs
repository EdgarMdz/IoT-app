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
    public partial class LightBulbBrandView : Grid
    {
        public new bool IsVisible
        {
            get => (bool)GetValue(IsVisibleProperty); 
            set => SetValue(IsVisibleProperty, value);
        }


        Color ActiveColor = Color.FromHex("FDDC97");
        Color InactiveColor = Color.FromHex("CCC4C4C4");

        public LightBulbBrandView()
        {
            InitializeComponent();
            
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            var button = sender as View;

            if (button is null) return;

            ResetButtonsBackground();
            button.BackgroundColor = ActiveColor;
        }

        private void ResetButtonsBackground()
        {
            NanoleafBtn.BackgroundColor = InactiveColor;
            HueBtn.BackgroundColor = InactiveColor;
            LifxBtn.BackgroundColor = InactiveColor;
            OtherBtn.BackgroundColor = InactiveColor;
        }
    }
}