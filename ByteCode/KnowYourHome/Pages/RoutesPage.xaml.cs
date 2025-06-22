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
    /// Логика взаимодействия для RoutesPage.xaml
    /// </summary>
    public partial class RoutesPage : Page
    {
        //public ICommand NavigateToRouteCommand { get;}
        //private Frame _frame { get; set; }
        public RoutesPage(Frame frame)
        {
            InitializeComponent();
            DataContext = new RoutesViewModel(frame.FindName("MainFrame") as Frame);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var routes = (DataContext as RoutesViewModel).EntertainmentItems;

            foreach (var route in routes)
            {
                EntertamentUserControl entertamentUserControl = new EntertamentUserControl(route)
                {
                    DataContext = route
                };
                entertamentUserControl.MoreButtonClicked += EntertamentUserControl_MoreButtonClicked;
                RoutesStackPanel.Children.Add(entertamentUserControl);

            }
        }


        private void EntertamentUserControl_MoreButtonClicked(object? sender, RoutedEventArgs e)
        {
            RouteWindow routeWindow = new()
            {
                DataContext = (sender as EntertamentUserControl).DataContext as Entertament
            };
            routeWindow.Show();
        }
    }
}
