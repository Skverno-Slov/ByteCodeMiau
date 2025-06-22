using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KnowYourHome.Pages
{
    /// <summary>
    /// Логика взаимодействия для MonumentsPage.xaml
    /// </summary>
    public partial class MonumentsPage : Page
    {
        public MonumentsPage(Frame frame)
        {
            InitializeComponent();
            DataContext = new MonumentsViewModel(frame.FindName("MainFrame") as Frame);
        }
    }
}
