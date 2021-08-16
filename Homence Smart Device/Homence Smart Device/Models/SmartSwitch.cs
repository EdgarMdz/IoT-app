using System;
using System.Collections.Generic;
using System.Text;

namespace Homence_Smart_Device.Models
{
    public class SmartSwitch 
    {
        public string Name { get; set; }
        public List<LightBulb> LightBulbs { get; set; }
    }
}
