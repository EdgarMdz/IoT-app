using Homence_Smart_Device.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Homence_Smart_Device.ViewModels
{
    class DevicesViewModel : BaseViewModel
    {
        private List<LightBulb> lights;

        public List<LightBulb> Lights
        {
            get => lights; set
            {
                if (value != lights)
                {
                    lights = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
