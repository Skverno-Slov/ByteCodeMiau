using System.Windows.Controls;
using System.Windows.Input;

namespace KnowYourHome
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly Frame _frame;

        public ICommand NavigateToHotelsCommand { get; }

        public HomeViewModel(Frame frame)
        {
            _frame = frame;
            NavigateToHotelsCommand = new RelayCommand(_ => NavigateToHotels());
        }

        private void NavigateToHotels()
        {
            var hotelsPage = new HotelsPage(_frame);
            _frame.Navigate(hotelsPage);
        }
    }
}
