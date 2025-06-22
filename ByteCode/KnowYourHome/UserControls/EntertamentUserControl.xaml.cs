using DataBaseLibrary.DataBase;
using DataBaseLibrary.Models;
using DataBaseLibrary.Repositories;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace KnowYourHome.UserControls
{
    /// <summary>
    /// Логика взаимодействия для EntertamentUserControl.xaml
    /// </summary>
    public partial class EntertamentUserControl : UserControl
    {
        public event EventHandler<RoutedEventArgs> MoreButtonClicked;

        private object _obj;

        public EntertamentUserControl(object obj)
        {
            _obj = obj;
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                string connectionString = "Data Source=DataBase.db;";
                IDbConnectionFactory factory = new SqliteFactory(connectionString);

                CityRepository repository = new(factory);
                City? city = repository.GetById((_obj as Entertament).CityId);

                CityTextBlock.Text = city.CityName;
            }
            catch
            {
                MessageBox.Show("Ошибка подключения");
            }

            try
            {
                string connectionString = "Data Source=DataBase.db;";
                IDbConnectionFactory factory = new SqliteFactory(connectionString);

                TuristTypeRepostitory repository = new(factory);
                TuristType? turistType = repository.GetById((_obj as Entertament).TuristTypeId);

                TuristTypeTextBlock.Text = turistType.TuristTypeName;
            }
            catch
            {
                MessageBox.Show("Ошибка подключения");
            }

            try
            {
                string connectionString = "Data Source=DataBase.db;";
                IDbConnectionFactory factory = new SqliteFactory(connectionString);

                EntertamentRepository repository = new(factory);
                Entertament entertament = repository.GetById((_obj as Entertament).EntertamentId);

                var path = Path.Combine(Environment.CurrentDirectory, "images", $"{entertament.ImageName}");
                if (File.Exists(path))
                {
                    BitmapImage bitmapImage = new BitmapImage(new Uri(path));
                    EntertamentImage.Source = bitmapImage;
                }
                else
                    SetPlaceholder();
            }
            catch
            {

                MessageBox.Show("Ошибка подключения");
            }
        }

        private void SetPlaceholder()
        {
            var path = System.IO.Path.Combine(Environment.CurrentDirectory, "images", "placeholder.png");
            BitmapImage bitmapImage = new BitmapImage(new Uri(path));
            EntertamentImage.Source = bitmapImage;
        }

        private void MoreButton_Click(object sender, RoutedEventArgs e)
        {
            MoreButtonClicked?.Invoke(this, e);
        }
    }
}
