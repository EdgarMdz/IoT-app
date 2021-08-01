using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Homence_Smart_Device
{
   public class CustomEntry : Entry
    {
        public static BindableProperty CornerRadiusProperty =
            BindableProperty.Create(nameof(CornerRadius), returnType: typeof(int), declaringType: typeof(CustomEntry), defaultValue: 0);
        
        public static BindableProperty BorderThicknessProperty =
            BindableProperty.Create(nameof(BorderThickness), returnType: typeof(int), declaringType: typeof(CustomEntry), defaultValue: 1);
        
        public static BindableProperty BorderColorProperty =
            BindableProperty.Create(nameof(BorderThickness), returnType: typeof(Color), declaringType: typeof(CustomEntry), defaultValue: Color.Black);

        public static BindableProperty PaddingProperty =
            BindableProperty.Create(nameof(Padding), returnType: typeof(Thickness), declaringType: typeof(CustomEntry), defaultValue: new Thickness(0));
        public int CornerRadius
        {
            get => (int)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty,value);
        }

        public int BorderThickness
        {
            get => (int)GetValue(BorderThicknessProperty);
            set => SetValue(BorderThicknessProperty, value);
        }

        public Color BorderColor
        {
            get => (Color)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }

        public Thickness Padding
        {
            get => (Thickness)GetValue(PaddingProperty);
            set => SetValue(PaddingProperty, value);
        }
    }
}
