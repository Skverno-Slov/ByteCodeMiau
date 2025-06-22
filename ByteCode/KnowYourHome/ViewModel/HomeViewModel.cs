using KnowYourHome.Pages;
using System.Windows.Controls;
using System.Windows.Input;

namespace KnowYourHome
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly Frame _frame;

        public ICommand NavigateToHotelsCommand { get; }
        public ICommand NavigateToRestaurantsCommand { get; }
        public ICommand NavigateToMonumentsCommand { get; }
        public ICommand NavigateToRoutesCommand { get; }
        public ICommand NavigateToTestMapCommand { get; }

        public HomeViewModel(Frame frame)
        {
            _frame = frame;
            NavigateToHotelsCommand = new RelayCommand(_ => NavigateToHotels());
            NavigateToRestaurantsCommand = new RelayCommand(_ => NavigateToRestaurants());
            NavigateToMonumentsCommand = new RelayCommand(_ => NavigateToMonuments());
            NavigateToRoutesCommand = new RelayCommand(_ => NavigateToRoutes());
            NavigateToTestMapCommand = new RelayCommand(_ => NavigateToTestMap());
        }

        private void NavigateToHotels()
        {
            var hotelsPage = new HotelsPage(_frame);
            _frame.Navigate(hotelsPage);
        }
        private void NavigateToRestaurants()
        {
            var restaurantsPage = new RestaurantsPage(_frame);
            _frame.Navigate(restaurantsPage);
        }
        private void NavigateToMonuments()
        {
            var monumentsPage = new MonumentsPage(_frame);
            _frame.Navigate(monumentsPage);
        }
        private void NavigateToRoutes()
        {
            var routesPage = new RoutesPage(_frame);
            _frame.Navigate(routesPage);
        }
        private void NavigateToTestMap()
        {
            var testMapPage = new TestMapPage(_frame);
            _frame.Navigate(testMapPage);
        }
    }
}
