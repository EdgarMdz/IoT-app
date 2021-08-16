using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace Homence_Smart_Device.Models
{
    public class LightBulb
    {
        public string Name { get; set; }
        public int DimmingValue { get; set; }
        public string Image { get; set; }
        public List<Color> Colors { get; set; }
        public bool IsSmartBulb { get; set; }
        public bool IsBussy { get; set; }
        public List<(DateTime date, TimeSpan offset, bool AtSunset, bool AtSunrise, bool[] repetitionDays, LightBulbCommand command, bool isEnabled)> AlarmList { get; set; }

    }
}
