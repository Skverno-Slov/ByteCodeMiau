using DataBaseLibrary.Models;
using KnowYourHome.UserControls;
using KnowYourHome.Windows;
using System.Windows;
using System.Windows.Controls;

namespace KnowYourHome.Pages
{
    /// <summary>
    /// Логика взаимодействия для RestaurantsPage.xaml
    /// </summary>
    public partial class RestaurantsPage : Page
    {
        public RestaurantsPage(Frame frame)
        {
            InitializeComponent();
            DataContext = new RestaurantsViewModel(frame.FindName("MainFrame") as Frame);
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var restaurants = (DataContext as RestaurantsViewModel).EntertainmentItems;

            foreach (var hotel in restaurants)
            {
                EntertamentUserControl entertamentUserControl = new EntertamentUserControl(hotel)
                {
                    DataContext = hotel
                };
                entertamentUserControl.MoreButtonClicked += EntertamentUserControl_MoreButtonClicked;

                RestaurantsStackPanel.Children.Add(entertamentUserControl);
            }
        }

        private void EntertamentUserControl_MoreButtonClicked(object? sender, RoutedEventArgs e)
        {
            EntertamentWindow entertamentWindow = new()
            {
                DataContext = (sender as EntertamentUserControl).DataContext as Entertament
            };
            entertamentWindow.Show();
        }
    }
}
