using Homence_Smart_Device.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Homence_Smart_Device.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LightBulbScheduleView : ContentView
    {
        public event EventHandler ItemClicked;
        public LightBulbScheduleView()
        {
            InitializeComponent();
            /*
            var scheduleDataTemplate = new DataTemplate(() =>
            {
                var swipeView = new SwipeView();

                var scheduleItem = new SwipeItem
                {
                    Text = "Delete",
                    IconImageSource = "TrashCanIcon.png",
                    BackgroundColor = Color.Tomato
                };

                scheduleItem.Invoked += SwipeItem_Invoked;


                swipeView.LeftItems.Add(scheduleItem);

                var grid = new Grid
                {
                    RowDefinitions = new RowDefinitionCollection
                    {
                        new RowDefinition() { Height = new GridLength(0.2, GridUnitType.Star) },
                        new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) },
                        new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) },
                        new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) },
                        new RowDefinition() { Height = new GridLength(0.2, GridUnitType.Star) }
                    },
                    ColumnDefinitions = new ColumnDefinitionCollection()
                    {
                        new ColumnDefinition(){Width=new GridLength(3, GridUnitType.Star)},
                        new ColumnDefinition(){Width=new GridLength(1, GridUnitType.Star)}
                    },
                };

                var frame = new Frame
                {
                    BackgroundColor = Color.FromHex("#646464"),
                    CornerRadius = 10,
                    Opacity = 0.3
                };

                var timeLbl = new Label { TextColor = Color.White, FontFamily = "Poppins Bold", FontSize = 20, Text = "9:30 AM" };
                var commandLbl = new Label { TextColor = Color.FromHex("#e1e1e1"), FontFamily = "Poppins Bold", FontSize = 15, Text = "Turn On" };
                var dateLbl = new Label { TextColor = Color.FromHex("#e1e1e1"), FontFamily = "Poppins Bold", FontSize = 15, Text = "Monday" };
                var stateSwitch = new Switch
                {
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    WidthRequest = 30,
                    HeightRequest = 20,
                    OnColor = Color.LightGray,
                    ThumbColor = Color.White
                };


                timeLbl.SetBinding(Label.TextProperty, "date");
                commandLbl.SetBinding(Label.TextProperty, "command");
                dateLbl.SetBinding(Label.TextProperty, "date.DayOfYear");
                stateSwitch.SetBinding(Switch.IsToggledProperty, "isEnabled");

                grid.Children.Add(frame, 0, 0);
                grid.Children.Add(timeLbl, 0, 1);
                grid.Children.Add(dateLbl, 0, 2);
                grid.Children.Add(commandLbl, 0, 3);
                grid.Children.Add(frame, 1, 0);

                Grid.SetColumnSpan(frame, 2);
                Grid.SetRowSpan(frame, 5);

                Grid.SetRowSpan(stateSwitch, 5);

                swipeView.Content = grid;

                return swipeView;
            });

            BindableLayout.SetItemTemplate(stackLayout, scheduleDataTemplate);*/
        }

        private void SwipeItem_Invoked(object sender, EventArgs e)
        {

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            ItemClicked?.Invoke(this, new EventArgs());
        }
    }
}