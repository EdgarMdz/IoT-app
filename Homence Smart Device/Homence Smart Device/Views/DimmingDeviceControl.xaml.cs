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
    public partial class DimingDeviceControl : Grid
    {
        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create(nameof(Title), typeof(string), typeof(DimingDeviceControl));
        public static readonly BindableProperty FontFamilyProperty =
            BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(DimingDeviceControl), defaultValue: "Times New Roman");
        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create(nameof(FontSize), typeof(double), typeof(DimingDeviceControl), defaultValue: 10.0);
        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(DimingDeviceControl), defaultValue: Color.White);
        public static readonly BindableProperty HorizontalTextAlignmentProperty =
            BindableProperty.Create(nameof(HorizontalTextAlignment), typeof(TextAlignment), typeof(DimingDeviceControl), defaultValue: TextAlignment.Start);
        public static readonly BindableProperty SmartBulbColorSelectionProperty =
              BindableProperty.Create(nameof(SmartBulbColorSelection), typeof(List<Color>), typeof(DimingDeviceControl), defaultValue:
                  new List<Color>(new[] { Color.White }));
        public static readonly BindableProperty IsSmartProperty =
             BindableProperty.Create(nameof(IsSmart), typeof(bool), typeof(DimingDeviceControl), defaultValue: true);
        public static readonly BindableProperty DimmingValueProperty =
            BindableProperty.Create(nameof(DimmingValue), typeof(int), typeof(DimingDeviceControl), defaultValue: 190);
        public static readonly BindableProperty IconProperty =
            BindableProperty.Create(nameof(Icon), typeof(string), typeof(DimingDeviceControl), defaultValue: "lightBulbIcon.png");
        public static readonly BindableProperty ShowBackgroundFrameProperty =
            BindableProperty.Create(nameof(ShowBackgroundFrame), typeof(bool), typeof(DimingDeviceControl), defaultValue: true);
        /// <summary>
        /// Title of the Contact
        /// </summary>
        public string Title { get => (string)GetValue(TitleProperty); set => SetValue(TitleProperty, value); }

        /// <summary>
        /// Font family for Title field
        /// </summary>
        public string FontFamily { get => (string)GetValue(FontFamilyProperty); set => SetValue(FontFamilyProperty, value); }

        /// <summary>
        /// Font size for Title field
        /// </summary>
        public double FontSize { get => (double)GetValue(FontSizeProperty); set => SetValue(FontSizeProperty, value); }
        /// <summary>
        /// Text color for Tilte field
        /// </summary>
        public Color TextColor { get => (Color)GetValue(TextColorProperty); set => SetValue(TextColorProperty, value); }
        /// <summary>
        /// Text alignment for Title field
        /// </summary>
        public TextAlignment HorizontalTextAlignment { get => (TextAlignment)GetValue(HorizontalTextAlignmentProperty); set => SetValue(HorizontalTextAlignmentProperty, value); }

        /// <summary>
        /// Quick access light colors for smart bulb
        /// </summary>
        public List<Color> SmartBulbColorSelection { get => (List<Color>)GetValue(SmartBulbColorSelectionProperty); set => SetValue(SmartBulbColorSelectionProperty, value); }
        
        /// <summary>
        /// Is this contact for a smart bulb
        /// </summary>
        public bool IsSmart { get => (bool)GetValue(IsSmartProperty); set => SetValue(IsSmartProperty, value); }

        public bool ShowBackgroundFrame { get => (bool)GetValue(ShowBackgroundFrameProperty); set => SetValue(ShowBackgroundFrameProperty, value); }

        /// <summary>
        /// Dimming value from 0 for completely off and 255 for full brightness
        /// </summary>
        public int DimmingValue
        {
            get => (int)GetValue(DimmingValueProperty); set
            {
                double val = value * 190 / 255;
                SetValue(DimmingValueProperty, val);
            }
        }

        /// <summary>
        /// Path of the icon to be displayed
        /// </summary>
        public string Icon { get => (string)GetValue(IconProperty);
            set => SetValue(IconProperty, value); }


        private Color LightColor { get; set; }


        public DimingDeviceControl()
        {
            InitializeComponent();
            LightColor = Color.FromHex("FDDC97");
        }

        private void SetGrid(bool isSmart)
        {
            if (isSmart)
            {
                this.RowDefinitions = new RowDefinitionCollection
                {
                    new RowDefinition() { Height = new GridLength(2, GridUnitType.Star) },
                    new RowDefinition() { Height = new GridLength(35, GridUnitType.Absolute) },
                    new RowDefinition() { Height = new GridLength(30, GridUnitType.Absolute) }
                };

                SetRowSpan(backgroundFrame, 4);
                SetRowSpan(LightBulbGrid, 4);
            }
            else
            {
                this.RowDefinitions = new RowDefinitionCollection
                {
                    new RowDefinition() { Height = new GridLength(2, GridUnitType.Star) },
                    new RowDefinition() { Height = new GridLength(35, GridUnitType.Absolute) }
                };

                SetRowSpan(backgroundFrame, 3);
                SetRowSpan(LightBulbGrid, 3);
                ColorsScrollView.IsVisible = false;
            }
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            string hexLightColor = LightColor.ToHex().Substring(3);

            if ((int)e.NewValue > 0)
            {
                gradientBoxView.IsVisible = true;
                
                DimmingSlider.ThumbColor = Color.FromHsla(LightColor.Hue, LightColor.Saturation, 
                    LightColor.Luminosity - 0.10 >= 0 ? LightColor.Luminosity - 0.10 : LightColor.Luminosity + 0.10);

                gradientStopMiddle.Color = Color.FromHex(((int)e.NewValue).ToString("X") + hexLightColor);
            }
            else
            {
                gradientBoxView.IsVisible = false;
                DimmingSlider.ThumbColor = Color.FromHex("C4C4C4");
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;

            if (button is null)
                return;

            LightColor = button.BackgroundColor;
            string hexLightColor = LightColor.ToHex().Substring(3);

            DimmingSlider.MinimumTrackColor = LightColor;
            gradientStopStart.Color = LightColor;
            gradientStopMiddle.Color = Color.FromHex(((int)DimmingSlider.Value).ToString("X") + hexLightColor);
            gradientStopEnd.Color = Color.FromHex("00" + hexLightColor);

            if ((int)DimmingSlider.Value > 0)
            {
                gradientBoxView.IsVisible = true;
                DimmingSlider.ThumbColor = Color.FromHsla(LightColor.Hue, LightColor.Saturation,
                    LightColor.Luminosity - 0.10 >= 0 ? LightColor.Luminosity - 0.10 : LightColor.Luminosity + 0.10);
            }
            else
            {
                gradientBoxView.IsVisible = false;
                DimmingSlider.ThumbColor = Color.FromHex("C4C4C4");
            }
        }

        private void this_BindingContextChanged(object sender, EventArgs e)
        {
            var dimmingControl = sender as DimingDeviceControl;
            
            if (dimmingControl is null) return;

            SetGrid(dimmingControl.IsSmart);
            DimmingSlider.Value = dimmingControl.DimmingValue;
        }
    }
}