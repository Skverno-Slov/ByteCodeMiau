
using DataBaseLibrary.DataBase;
using DataBaseLibrary.Models;
using DataBaseLibrary.Repositories;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace KnowYourHome
{
    public class HotelsViewModel : BaseViewModel
    {
        public ObservableCollection<Entertament> EntertainmentItems { get; }
        public ICommand NavigateBackCommand { get; }

        private readonly Frame _frame;

        public HotelsViewModel(Frame frame)
        {
            _frame = frame;

            EntertainmentItems = new ObservableCollection<Entertament>();

            LoadData();
            NavigateBackCommand = new RelayCommand(_ => NavigateBack());
        }

        private void LoadData()
        {
            try
            {
                string connectionString = "Data Source=DataBase.db;";
                IDbConnectionFactory factory = new SqliteFactory(connectionString);

                EntertamentRepository repository = new(factory);
                var hotels = repository.GetAllHotels();
                foreach (var hotel in hotels)
                    EntertainmentItems.Add(hotel);
            }
            catch
            {
                MessageBox.Show("Ошибка подключения");
            }
        }
        private void NavigateBack()
            => _frame.GoBack();
    }
}
