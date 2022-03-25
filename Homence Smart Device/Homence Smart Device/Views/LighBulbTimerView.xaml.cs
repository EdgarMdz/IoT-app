using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Homence_Smart_Device.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LighBulbTimerView : ContentView
    {
        bool PauseTimer { get; set; }
        bool StopTimer { get; set; }
        TimeSpan CountdownTimeSpan { get; set; }
        double ProggressFraction { get; set; }

        public LighBulbTimerView()
        {
            InitializeComponent();
            hourPicker.SelectedIndex = 0;
            minutePicker.SelectedIndex = 0;
            secondPicker.SelectedIndex = 0;
            NavigationPage.SetHasNavigationBar(this, false);

        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {

        }

        private void TimePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            TimeSpan timeSpan = new TimeSpan(hourPicker.SelectedIndex, minutePicker.SelectedIndex, secondPicker.SelectedIndex);
            startButton.IsEnabled = timeSpan.TotalSeconds != 0;
        }

        private void startButton_Clicked(object sender, EventArgs e)
        {
            SwitchToSecondView(true);

            CountdownTimeSpan = new TimeSpan(hourPicker.SelectedIndex, minutePicker.SelectedIndex, secondPicker.SelectedIndex+1);


            HourCountDown.Text = hourPicker.SelectedIndex.ToString("D2");
            MinuteCountDown.Text = minutePicker.SelectedIndex.ToString("D2");
            SecondCountDown.Text = secondPicker.SelectedIndex.ToString("D2");


            ProggressFraction = 1 / (CountdownTimeSpan.TotalSeconds - 2);
            PauseTimer = false;
            StopTimer = false;

            StartTimer();
        }

        private void StartTimer()
        {
            Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
            {
                CountdownTimeSpan = CountdownTimeSpan.Subtract(TimeSpan.FromMilliseconds(100));

                if (CountdownTimeSpan.TotalSeconds >= 0 && !PauseTimer && !StopTimer)
                {
                    HourCountDown.Text = CountdownTimeSpan.Hours.ToString("D2");
                    MinuteCountDown.Text = CountdownTimeSpan.Minutes.ToString("D2");
                    SecondCountDown.Text = CountdownTimeSpan.Seconds > 0 ? CountdownTimeSpan.Seconds.ToString("D2") : "00";
                    ProgressRing.AnimatedProgress -= ProggressFraction / 10;
                    return true;
                }
                else if (PauseTimer && !StopTimer)
                {
                    return false;
                }
                else
                {
                    ProgressRing.AnimatedProgress = 0;
                    SwitchToSecondView(false);
                    return false;
                }
            });
        }

        private void SwitchToSecondView(bool ShowSecondView)
        {
            PickerGrid.IsVisible = !ShowSecondView;
            CountdownGrid.IsVisible = ShowSecondView;
            startButton.IsVisible = !ShowSecondView;
            ButtonLayout.IsVisible = ShowSecondView;
            ProgressRing.AnimatedProgress = 1;
        }

        private void PauseButton_Clicked(object sender, EventArgs e)
        {
            if (!PauseTimer)
            {
                PauseTimer = true;
                PauseButton.Text = "Resume";
                ProgressRing.RingProgressColor = Color.DimGray;
            }
            else
            {
                ProgressRing.RingProgressColor = Color.FromHex("#aaFFD273");
                PauseTimer = false;
                PauseButton.Text = "Pause";
                StartTimer();
            }
        }

        private void CancelButton_Clicked(object sender, EventArgs e)
        {
            StopTimer = true;
            SwitchToSecondView(false);
            ProgressRing.AnimationLength = 1;
            ProgressRing.AnimatedProgress = 1;
            ProgressRing.AnimationLength = 800;
        }
    }
}