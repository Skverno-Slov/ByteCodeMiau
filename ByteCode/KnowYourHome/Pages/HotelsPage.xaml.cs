using System.Windows;
using System.Windows.Controls;

namespace KnowYourHome
{
    /// <summary>
    /// Логика взаимодействия для HotelsPage.xaml
    /// </summary>
    public partial class HotelsPage : Page
    {
        public HotelsPage()
        {
            InitializeComponent();
            DataContext = new HotelsViewModel(FindName("MainFrame") as Frame);
        }
    }
}
