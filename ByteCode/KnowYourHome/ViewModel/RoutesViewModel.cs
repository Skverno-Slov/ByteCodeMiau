﻿using DataBaseLibrary.DataBase;
using DataBaseLibrary.Models;
using DataBaseLibrary.Repositories;
using KnowYourHome.Pages;
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
    public class RoutesViewModel : BaseViewModel
    {
        public ObservableCollection<Entertament> EntertainmentItems { get; }
        public ICommand NavigateBackCommand { get; }
        public ICommand NavigateToRouteCommand { get; }

        private readonly Frame _frame;

        public RoutesViewModel(Frame frame)
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
                var routes = repository.GetAllRoutes();
                foreach (var route in routes)
                    EntertainmentItems.Add(route);
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
