using DataBaseLibrary.DataBase;
using DataBaseLibrary.Models;
using DataBaseLibrary.Repositories;
using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace KnowYourHome.Pages
{
    /// <summary>
    /// Логика взаимодействия для CreatePointPage.xaml
    /// </summary>
    public partial class CreatePointPage : Page
    {
        private string _selectedImagePath = string.Empty;

        public CreatePointPage(Frame frame)
        {
            InitializeComponent();
            DataContext = new HotelsViewModel(frame.FindName("MainFrame") as Frame);

            LoadComboBoxData();
        }

        private void AddImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new();
            dialog.Filter = "Images|*.jpg;*.jpeg;*.png;*.bmp";

            if (dialog.ShowDialog() == true)
                _selectedImagePath = dialog.FileName;
        }

        private void AddToTableButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string connectionString = "Data Source=DataBase.db;";
                IDbConnectionFactory factory = new DataBaseLibrary.DataBase.SqliteFactory(connectionString);

                EntertamentRepository repository = new(factory);

                if (!decimal.TryParse(txtLatitude.Text, out decimal latitude) ||
                !decimal.TryParse(txtLongitude.Text, out decimal longitude) ||
                !decimal.TryParse(txtPrice.Text, out decimal price))
                {
                    MessageBox.Show("Некорректный ввод");
                    return;
                }
                int selectedCityId = (int)comboCity.SelectedValue;
                int selectedEntertamentTypeId = (int)comboEntertamentType.SelectedValue;
                int selectedTuristTypeId = (int)comboTuristType.SelectedValue;

                string name = txtEntertamentName.Text;
                string address = txtAddress.Text;
                string description = txtDescription.Text;
                string siteLink = txtSiteLink.Text;

                string imagesFolder = null;
                string imageFileName = null;
                if (_selectedImagePath != null)
                {
                    string extension = Path.GetExtension(_selectedImagePath);
                    imageFileName = Guid.NewGuid().ToString() + extension;

                    imagesFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");

                    if (!Directory.Exists(imagesFolder))
                        Directory.CreateDirectory(imagesFolder);

                    string destPath = Path.Combine(imagesFolder, imageFileName);
                    File.Copy(_selectedImagePath, destPath, true);
                }

                Entertament entertament = new()
                {
                    CityId = selectedCityId,
                    EntertamentTypeId = selectedEntertamentTypeId,
                    TuristTypeId = selectedTuristTypeId,
                    ImageName = $"{imagesFolder}\\{imageFileName}",
                    Address = address,
                    EntertamentName = name,
                    Description = description,
                    Latitude = latitude,
                    Longitude = longitude,
                    SiteLink = siteLink,
                    Price = price
                };
                repository.Create(entertament);
            }
            catch
            {
                MessageBox.Show("Ошибка подключения", "Ошибка");
            }
            MessageBox.Show("Добавлена запись","Успех");
        }

        private void LoadComboBoxData()
        {
            try
            {
                string connectionString = "Data Source=DataBase.db;";
                IDbConnectionFactory factory = new DataBaseLibrary.DataBase.SqliteFactory(connectionString);

                CityRepository repository = new(factory);
                comboCity.ItemsSource = repository.GetAll();
                comboCity.DisplayMemberPath = "CityName";
                comboCity.SelectedValuePath = "CityId";
            }
            catch
            {
                MessageBox.Show("Ошибка подключения");
            }

            try
            {
                string connectionString = "Data Source=DataBase.db;";
                IDbConnectionFactory factory = new DataBaseLibrary.DataBase.SqliteFactory(connectionString);

                EntertamentTypeRepository repository = new(factory);
                comboEntertamentType.ItemsSource = repository.GetAll();
                comboEntertamentType.DisplayMemberPath = "EntertamentTypeName";
                comboEntertamentType.SelectedValuePath = "EntertamentTypeId";
            }
            catch
            {

                MessageBox.Show("Ошибка подключения");
            }

            try
            {
                string connectionString = "Data Source=DataBase.db;";
                IDbConnectionFactory factory = new DataBaseLibrary.DataBase.SqliteFactory(connectionString);

                TuristTypeRepostitory repository = new(factory);
                comboTuristType.ItemsSource = repository.GetAll();
                comboTuristType.DisplayMemberPath = "TuristTypeName";
                comboTuristType.SelectedValuePath = "TuristTypeId";
            }
            catch
            {
                MessageBox.Show("Ошибка подключения");
            }
        }
    }
}
