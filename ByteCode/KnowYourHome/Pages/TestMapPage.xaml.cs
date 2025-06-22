using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KnowYourHome.Pages
{
    /// <summary>
    /// Логика взаимодействия для TestMapPage.xaml
    /// </summary>
    public partial class TestMapPage : Page
    {
        public TestMapPage(Frame frame)
        {
            InitializeComponent();
            DataContext = new RoutesViewModel(frame.FindName("MainFrame") as Frame);
        }

        private void mapView_Loaded(object sender, RoutedEventArgs e)
        {
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            // choose your provider here
            mapView.MapProvider = GMap.NET.MapProviders.OpenStreetMapProvider.Instance;
            mapView.MinZoom = 2;
            mapView.MaxZoom = 17;
            // whole world zoom
            mapView.Zoom = 2;
            // lets the map use the mousewheel to zoom
            mapView.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
            // lets the user drag the map
            mapView.CanDragMap = true;
            // lets the user drag the map with the left mouse button
            mapView.DragButton = MouseButton.Left;

            mapView.Position = new GMap.NET.PointLatLng(64.544313, 40.541711);

            mapView.ShowCenter = false;
            mapView.ShowTileGridLines = false;
            var marker1point = new PointLatLng(64.555682, 40.531578);
            var marker2point = new PointLatLng(64.552825, 40.537837);
            GMapMarker marker1 = new GMapMarker(marker1point);
            GMapMarker marker2 = new GMapMarker(marker2point);
            marker1.Shape = new Ellipse()
            {
                Width = 10,
                Height = 10,
                Fill = Brushes.Red
            };
            marker2.Shape = new Ellipse()
            {
                Width = 10,
                Height = 10,
                Fill = Brushes.Blue
            };

            mapView.Markers.Add(marker1);
            mapView.Markers.Add(marker2);
            mapView.UpdateLayout();

            var route = OpenStreetMapProvider.Instance.GetRoute(marker1point,marker2point,false,true,3);
            var r = new GMapRoute(route.Points);

            mapView.Markers.Add(r);
        }

    }
}