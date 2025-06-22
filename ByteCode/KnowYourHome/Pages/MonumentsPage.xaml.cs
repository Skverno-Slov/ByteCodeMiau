using DataBaseLibrary.Models;
using KnowYourHome.UserControls;
using KnowYourHome.Windows;
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
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var restaurants = (DataContext as MonumentsViewModel).EntertainmentItems;

            foreach (var hotel in restaurants)
            {
                EntertamentUserControl entertamentUserControl = new EntertamentUserControl(hotel)
                {
                    DataContext = hotel
                };
                entertamentUserControl.MoreButtonClicked += EntertamentUserControl_MoreButtonClicked;
                MonumentsStackPanel.Children.Add(entertamentUserControl);
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
