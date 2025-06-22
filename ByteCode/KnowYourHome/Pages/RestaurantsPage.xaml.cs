using KnowYourHome.UserControls;
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

                RestaurantsStackPanel.Children.Add(entertamentUserControl);
            }
        }
    }
}
