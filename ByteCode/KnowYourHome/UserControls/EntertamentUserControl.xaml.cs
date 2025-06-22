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

namespace KnowYourHome.UserControls
{
    /// <summary>
    /// Логика взаимодействия для EntertamentUserControl.xaml
    /// </summary>
    public partial class EntertamentUserControl : UserControl
    {
        public event EventHandler<RoutedEventArgs> MoreButtonClicked;
        public EntertamentUserControl()
        {
            InitializeComponent();
        }

        private void MoreButton_Click(object sender, RoutedEventArgs e)
        {
            MoreButtonClicked?.Invoke(this, e);
        }
    }
}
