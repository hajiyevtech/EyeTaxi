﻿using System;
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

    public partial class NavigateRoute : UserControl
    {
        // Variables for tracking the navigation route.

        public NavigateRoute(MapPoint mapPoint)
        {
            InitializeComponent();
            NavigateRouteViewModel.CommandCreatedObject._firstPoint = mapPoint;
                //new MapPoint(5549147.485435362, 4921203.933289913, SpatialReferences.WebMercator);
            //NavigateRouteViewModel.CommandCreatedObject._secondPoint = new MapPoint(5549603.62447322, 4924224.8532453, SpatialReferences.WebMercator);

        }

        private void MyMapView_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point mousePoint = Mouse.GetPosition(this);

            NavigateRouteViewModel.CommandCreatedObject._firstPoint = MyMapView.ScreenToLocation(mousePoint);
            NavigateRouteViewModel.CommandCreatedObject.Initialize();
        }
    }
}
