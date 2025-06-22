using KnowYourHome.UserControls;
using System.Windows;
using System.Windows.Controls;

namespace KnowYourHome
{
    /// <summary>
    /// Логика взаимодействия для HotelsPage.xaml
    /// </summary>
    public partial class HotelsPage : Page
    {
        public HotelsPage(Frame frame)
        {
            InitializeComponent();
            DataContext = new HotelsViewModel(frame.FindName("MainFrame") as Frame);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var hotels = (DataContext as HotelsViewModel).EntertainmentItems;

            foreach (var hotel in hotels)
            {
                EntertamentUserControl entertamentUserControl = new EntertamentUserControl(hotel)
                { 
                    DataContext = hotel
                };
                HotelsStackPanel.Children.Add(entertamentUserControl);
            }
        }
    }
}
