using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Location;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Navigation;
using Esri.ArcGISRuntime.Symbology;
using Esri.ArcGISRuntime.Tasks.NetworkAnalysis;
using Esri.ArcGISRuntime.UI;
using Color = System.Drawing.Color;
using System.Speech.Synthesis;
using Esri.ArcGISRuntime.Portal;
using EyeTaxi.ViewModels;
using System.Windows.Input;

namespace EyeTaxi.Views
{
    /// <summary>
    /// Interaction logic for NavigateRoute.xaml
    /// </summary>

    public partial class NavigateRouteView : Page
    {
        // Variables for tracking the navigation route.
        public static bool IsNagivateStart { get; set; } = true;
        public NavigateRouteView()
        {
            InitializeComponent();
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