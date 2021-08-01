﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace Homence_Smart_Device.Models
{
    public class LightBulb : INotifyPropertyChanged
    {
        private string name;
        private int dimmingValue;
        private string image;
        private List<Color> colors;
        private bool isSmartBulb;

        public string Name { get => name; set { name = value; OnPropertyChanged(); } }
        public int DimmingValue { get => dimmingValue; set { dimmingValue = value; OnPropertyChanged(); } }
        public string Image { get => image; set { image = value; OnPropertyChanged(); } }
        public List<Color> Colors { get => colors; set { colors = value; OnPropertyChanged(); } }
        public bool IsSmartBulb { get => isSmartBulb;
            set { isSmartBulb = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}