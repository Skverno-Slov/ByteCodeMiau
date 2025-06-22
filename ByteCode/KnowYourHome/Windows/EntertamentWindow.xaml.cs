using DataBaseLibrary.DataBase;
using DataBaseLibrary.Models;
using DataBaseLibrary.Repositories;
using GMap.NET;
using GMap.NET.WindowsPresentation;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace KnowYourHome.Windows
{
    /// <summary>
    /// Логика взаимодействия для EntertamentWindow.xaml
    /// </summary>
    public partial class EntertamentWindow : Window
    {
        public EntertamentWindow()
        {

            InitializeComponent();

        }
        private void mapView_Loaded(object sender, RoutedEventArgs e)
        {
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            mapView.MapProvider = GMap.NET.MapProviders.OpenStreetMapProvider.Instance;
            mapView.MinZoom = 2;
            mapView.MaxZoom = 17;
            mapView.Zoom = 2;
            mapView.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
            mapView.CanDragMap = true;
            mapView.DragButton = MouseButton.Left;

            mapView.Position = new GMap.NET.PointLatLng(64.544313, 40.541711);

            mapView.ShowCenter = false;
            mapView.ShowTileGridLines = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ShowEntertament();
        }

        private void ShowEntertament()
        {
            Entertament entertament = DataContext as Entertament;
            PointLatLng markerPoint = new((double)entertament.Latitude, (double)entertament.Longitude);
            GMapMarker marker = new GMapMarker(markerPoint);

            var ellipse = new Ellipse()
            {
                Width = 20,
                Height = 20,
                Fill = Brushes.Red
            };

            marker.Shape = ellipse;

            mapView.Markers.Add(marker);

        }
    }
}

