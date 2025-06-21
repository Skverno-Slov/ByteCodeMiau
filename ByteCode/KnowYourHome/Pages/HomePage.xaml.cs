using System.Windows;
using System.Windows.Controls;

namespace KnowYourHome
{
    public partial class HomePage : Page
    {
        public HomePage(Window window)
        {
            InitializeComponent();
            DataContext = new HomeViewModel(window.FindName("MainFrame") as Frame);
        }
    }
}
