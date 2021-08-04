using Homence_Smart_Device.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Homence_Smart_Device.ViewModels
{
    class SmartSwitchViewModel
    {
        public List<SmartSwitch> smartSwitches { get; set; }

        public SmartSwitchViewModel() => Initialize();

        private void Initialize()
        {
            smartSwitches = new List<SmartSwitch>()
            {
                new SmartSwitch
                {
                    Name="Kitchen",
                    LightBulbs=new List<LightBulb>
                    {
                        new LightBulb{Name="Device 1", Colors=new List<Color>(){ Color.White },
                            DimmingValue=120, Image="lightbulbicon.png",IsSmartBulb=false},
                        new LightBulb{Name="Device 2", Colors = new List<Color>(){ Color.Magenta, Color.CadetBlue, Color.Chocolate, Color.CornflowerBlue,
                            Color.DeepPink, Color.ForestGreen, Color.MediumPurple, Color.LightSeaGreen, Color.OrangeRed, Color.Coral},
                            DimmingValue=0, Image="SmartBulbIcon.png", IsSmartBulb=true},
                        new LightBulb{Name="Device 3", Colors=new List<Color>(){ Color.White },
                            DimmingValue=0, Image="FluorescentLightBulbIcon.png", IsSmartBulb=false}
                    }
                },
                new SmartSwitch
                {
                    Name="Garden",
                    LightBulbs=new List<LightBulb>
                    {
                        new LightBulb{Name="Device 1", Colors=new List<Color>(){ Color.White },
                            DimmingValue=0, Image="lightbulbicon.png",IsSmartBulb=false},
                        new LightBulb{Name="Device 2", Colors = new List<Color>(){ Color.LemonChiffon, Color.CadetBlue, Color.Chocolate, Color.CornflowerBlue,
                            Color.DeepPink, Color.ForestGreen, Color.MediumPurple, Color.LightSeaGreen, Color.OrangeRed, Color.Coral},
                            DimmingValue=0, Image="SmartBulbIcon.png", IsSmartBulb=true},
                        new LightBulb{Name="Device 3", Colors=new List<Color>(){ Color.Red },
                            DimmingValue=0, Image="FluorescentLightBulbIcon.png", IsSmartBulb=false}
                    }
                }
            };
        }
    }
}



