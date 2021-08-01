using System;
using System.Collections.Generic;
using System.Text;

namespace Homence_Smart_Device.Models
{
    class SmartSwitch
    {
        public string Name { get; set; }
        public List<LightBulb> lightBulbs { get; set; }
    }
}
