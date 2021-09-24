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
using GMap.NET;
using GMap.NET.MapProviders;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Mapping;

namespace EyeTaxi.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView
    {
        public MainView()
        {
            InitializeComponent();
            //MainMapView.SetViewpoint(new Viewpoint(40.409264, 49.867092, 100000));
            MainMapView.IsAttributionTextVisible = false;
            //MapPoint mapCenterPoint = new MapPoint(0, 0, SpatialReferences.Wgs84);
            //MainMapView.SetViewpoint(new Viewpoint(mapCenterPoint, 100000));
            //MainMapView.SetViewpoint(new Viewpoint(40.409264, 49.867092, 100000));
            //MainMapView.LocationDisplay.AutoPanMode = Esri.ArcGISRuntime.UI.LocationDisplayAutoPanMode.Recenter;

            MainMapView.LocationDisplay.IsEnabled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigateRoute navigateRoute = new NavigateRoute();
            Mapo.Children.Add(navigateRoute);
        }



        private void MainMapView_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point mousePoint = Mouse.GetPosition(this);
            MainMapView.ScreenToLocation(mousePoint);
            //MapPoint mapPoint = new MapPoint(mousePoint.X, mousePoint.Y);
            MessageBox.Show(MainMapView.ScreenToLocation(mousePoint).ToString());

        }
    }
}
