using System;
using System.Collections.Generic;
using System.Text;

namespace Homence_Smart_Device.Models
{
    public class SmartSwitch : BaseModel
    {
        private string name;
        private List<LightBulb> lightBulbs;

        public string Name { get => name; set { name = value; OnPropertyChanged(); } }
        public List<LightBulb> LightBulbs { get => lightBulbs; set { lightBulbs = value; OnPropertyChanged(); } }
    }
}
