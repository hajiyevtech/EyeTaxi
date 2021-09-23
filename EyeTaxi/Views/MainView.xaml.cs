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
using GMap.NET.MapProviders;

namespace EyeTaxi.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            GMapProviders.GoogleMap.ApiKey = "AIzaSyBp1BJjLc5VZbc4rloZtrikPZ5NbifPST0";
            GMaps.Instance.Mode = AccessMode.ServerAndCache;

            GMap.MapProvider = GMapProviders.GoogleMap;
            GMap.MinZoom = 5;
            GMap.DragButton = MouseButton.Left;
            GMap.CanDragMap = true;
            GMap.IgnoreMarkerOnMouseWheel = false;
            GMap.Zoom--;
            GMap.Zoom++;
        }
    }
}
