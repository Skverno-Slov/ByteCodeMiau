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
    public class MonumentsViewModel : BaseViewModel
    {
        public ObservableCollection<Entertament> EntertainmentItems { get; }
        public ICommand NavigateBackCommand { get; }

        private readonly Frame _frame;

        public MonumentsViewModel(Frame frame)
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
                var monuments = repository.GetAllMonuments();
                foreach (var monument in monuments)
                    EntertainmentItems.Add(monument);
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