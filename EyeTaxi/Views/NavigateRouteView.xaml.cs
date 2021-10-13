using EyeTaxi.ViewModels;
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
using Esri.ArcGISRuntime.Symbology;

namespace EyeTaxi.Views
{
    /// <summary>
    /// Interaction logic for NavigateRouteView.xaml
    /// </summary>
    public partial class NavigateRouteView : Window
    {
        public static bool IsNagivateStart { get; set; } = true;
        public NavigateRouteView()
        {
            InitializeComponent();
            var uri = new Uri($@"C:\Users\{Environment.UserName}\source\repos\EyeTaxi\EyeTaxi\Assets\cab.png");
            var converted = uri.AbsoluteUri;
            PictureMarkerSymbol CabSymbol = new PictureMarkerSymbol(new Uri(converted));
            MyMapView.LocationDisplay.CourseSymbol = CabSymbol;
            CabSymbol.Width = 65;
            CabSymbol.Height = 65;
            MyMapView.LocationDisplay.IsEnabled = true;

            //NavigateRouteViewModel.CommandCreatedObject.PointTwo = mapPoint;
            //NavigateRouteViewModel.CommandCreatedObject.View = this;
            //new MapPoint(5549147.485435362, 4921203.933289913, SpatialReferences.WebMercator);
            //NavigateRouteViewModel.CommandCreatedObject._secondPoint = new MapPoint(5549603.62447322, 4924224.8532453, SpatialReferences.WebMercator);

        }
        private void MyMapView_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (IsNagivateStart)
            {
                Point mousePoint = Mouse.GetPosition(this);

                NavigateRouteViewModel.MyMapView.GraphicsOverlays.Clear();

                NavigateRouteViewModel.CommandCreatedObject.PointTwo = MyMapView.ScreenToLocation(mousePoint);
                NavigateRouteViewModel.CommandCreatedObject.Initialize();
            }
        }
    }
}
