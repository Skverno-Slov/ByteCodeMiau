﻿using DataBaseLibrary.DataBase;
using DataBaseLibrary.Models;
using DataBaseLibrary.Repositories;
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
using System.Windows.Shapes;
using static GMap.NET.Entity.OpenStreetMapRouteEntity;

namespace KnowYourHome.Windows
{
    /// <summary>
    /// Логика взаимодействия для RouteWindow.xaml
    /// </summary>
    public partial class RouteWindow : Window
    {
        private IEnumerable<DataBaseLibrary.Models.Route> routes;
        private List<Entertament> entertaments = new();
        public RouteWindow()
        {

            InitializeComponent();

        }
        private void mapView_Loaded(object sender, RoutedEventArgs e)
        {
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            mapView.MapProvider = GMap.NET.MapProviders.OpenStreetMapProvider.Instance;
            mapView.MinZoom = 2;
            mapView.MaxZoom = 17;
            mapView.Zoom = 10;
            mapView.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
            mapView.CanDragMap = true;
            mapView.DragButton = MouseButton.Left;

            mapView.Position = new GMap.NET.PointLatLng(64.544313, 40.541711);

            mapView.ShowCenter = false;
            mapView.ShowTileGridLines = false;
        }

        private void LoadData(Entertament route)
        {
            try
            {
                string connectionString = "Data Source=DataBase.db;";
                IDbConnectionFactory factory = new SqliteFactory(connectionString);

                RouteRepository repository = new(factory);

                var routes = repository.GetAllEntertamentsInRoute(route.EntertamentId);
                this.routes = routes;
            }
            catch
            {
                MessageBox.Show("Ошибка подключения");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var route = DataContext as Entertament;
            LoadData(route);
            LoadEntertaments();
            ShowRoute();
            for (int i = 0; i < entertaments.Count(); i++)
            {
                PlacesTextBlock.Text = PlacesTextBlock.Text + ($"{i+1}. {entertaments[i].EntertamentName}\n");
            }
        }
        private void LoadEntertaments()
        {
            foreach (var item in routes)
            {
                string connectionString = "Data Source=DataBase.db;";
                IDbConnectionFactory factory = new SqliteFactory(connectionString);

                EntertamentRepository repository = new(factory);

                var entertament = repository.GetById(item.EntertamentId);
                entertaments.Add(entertament);
            }
        }
        private void ShowRoute()
        {
            PointLatLng markerPoint1;
            PointLatLng markerPoint2;
            GMapMarker marker1;
            GMapMarker marker2;
            Entertament entertament1;
            Entertament entertament2;
            for (int i = 0; i < entertaments.Count(); i++)
            {
                entertament1 = entertaments[i];
                markerPoint1 = new PointLatLng((double)entertament1.Latitude,(double)entertament1.Longitude);
                marker1 = new GMapMarker(markerPoint1);
                var ellipse = new Ellipse()
                {
                    Width = 20,
                    Height = 20,
                    Fill = Brushes.Red
                };
                var canvas = new Canvas();

                var id = new TextBlock()
                { 
                Text = (i+1).ToString(),
                };
                Canvas.SetLeft(id, 5);
                Canvas.SetTop(id, 5);

                canvas.Children.Add(ellipse);
                canvas.Children.Add(id);

                marker1.Shape = canvas;

                mapView.Markers.Add(marker1);

            }

            mapView.UpdateLayout();

            for (int i = 0; i < entertaments.Count()-1; i++)
            {
                entertament1 = entertaments[i];
                markerPoint1 = new PointLatLng((double)entertament1.Latitude, (double)entertament1.Longitude);

                entertament2 = entertaments[i+1];
                markerPoint2 = new PointLatLng((double)entertament2.Latitude, (double)entertament2.Longitude);

                var route = OpenStreetMapProvider.Instance.GetRoute(markerPoint1, markerPoint2, false, true, 3);
                var r = new GMapRoute(route.Points);

                mapView.Markers.Add(r);
            }
        }
    }
}
