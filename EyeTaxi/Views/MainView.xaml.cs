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
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Mapping;
using EyeTaxi.ViewModels;

namespace EyeTaxi.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView
    {
        public static MapPoint MainViewMapPoint { get; set; }

        public MainView()
        {
            InitializeComponent();
            //MainMapView.LocationDisplay.IsEnabled = true;
        }

        private void MainMapView_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Point mousePoint = Mouse.GetPosition(this);
            //MapPoint mapPoint = new MapPoint(mousePoint.X, mousePoint.Y);
            //MainViewMapPoint = MainMapView.ScreenToLocation(mousePoint);
        }
    }
}
