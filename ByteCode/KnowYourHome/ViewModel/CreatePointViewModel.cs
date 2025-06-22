using DataBaseLibrary.DataBase;
using DataBaseLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace KnowYourHome.ViewModel
{
    internal class CreatePointViewModel : BaseViewModel
    {
        public ICommand NavigateBackCommand { get; }

        private readonly Frame _frame;

        public CreatePointViewModel(Frame frame)
        {
            _frame = frame;

            NavigateBackCommand = new RelayCommand(_ => NavigateBack());
        }

        private void NavigateBack()
            => _frame.GoBack();
    }
}
