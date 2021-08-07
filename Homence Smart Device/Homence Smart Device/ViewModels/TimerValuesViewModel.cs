using Homence_Smart_Device.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homence_Smart_Device.ViewModels
{
    public class TimerValuesViewModel
    {
        public TimerValues Values { get; set; }

        public TimerValuesViewModel()
        {
            Values = Initialize();
        }

        private TimerValues Initialize()
        {
            return new TimerValues()
            {
                HourValues = InitializeValues(0, 99),
                MinuteAndSecondValues = InitializeValues(0, 59)
            };
        }

        private List<string> InitializeValues(int start, int end)
        {
            List<string> values = new List<string>();

            for (int i = start; i <= end; i++)
            {
                values.Add(i.ToString("D2"));
            }

            return values;
        }
    }
}