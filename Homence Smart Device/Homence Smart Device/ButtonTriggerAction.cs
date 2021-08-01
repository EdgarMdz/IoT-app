using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;


namespace Homence_Smart_Device
{
    public class ButtonTriggerAction : TriggerAction<VisualElement>
    {
        public Color BackgroundColor { get; set; }

        protected override void Invoke(VisualElement sender)
        {
            var btn = sender as Button;
            if (btn is null) return;
            if (BackgroundColor != null)
                btn.BackgroundColor = BackgroundColor;
        }
    }
}
