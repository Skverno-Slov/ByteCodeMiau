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
    }
}
