using DataBaseLibrary.DataBase;
using DataBaseLibrary.Models;
using DataBaseLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace KnowYourHome
{
    public class RouteViewModel : BaseViewModel
    {
        public ObservableCollection<Entertament> EntertainmentItems { get; }
        public ICommand NavigateBackCommand { get; }

        private readonly Frame _frame;

        public RouteViewModel(Frame frame, int id)
        {
            _frame = frame;

            EntertainmentItems = new ObservableCollection<Entertament>();

            LoadData(id);
            NavigateBackCommand = new RelayCommand(_ => NavigateBack());
        }

        private void LoadData(int id)
        {
            try
            {
                string connectionString = "Data Source=DataBase.db;";
                IDbConnectionFactory factory = new SqliteFactory(connectionString);

                EntertamentRepository repository = new(factory);
                var routes = repository.GetById(id);
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