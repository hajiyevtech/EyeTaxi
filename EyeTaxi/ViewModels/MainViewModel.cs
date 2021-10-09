using Esri.ArcGISRuntime.Geometry;
using EyeTaxi.Command;
using EyeTaxi.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace EyeTaxi.ViewModels
{
    public  class MainViewModel
    {
        public RelayCommand NavigateCommand { get; set; }
        public RelayCommand LeftButtonCommand { get; set; }
        public RelayCommand GetMapGridCommand { get; set; }
        public RelayCommand GetMapGridFrameCommand { get; set; }
        public Grid Mapo { get; set; }
        public Frame Frame { get; set; }
        public MainViewModel()
        {





            GetMapGridCommand = new RelayCommand(s =>
            {
                Mapo = s as Grid;
            }, e => { return true; });


            GetMapGridFrameCommand = new RelayCommand(s =>
            {
                Frame = s as Frame;
            }, e => { return true; });

            NavigateCommand = new RelayCommand(a =>
            {
                NavigateRouteView navigateRoute = new NavigateRouteView();



                //Burdan pramoy Kordinatlari vere bilirik!!Gorursen Mestan Dagidiram buralari
                //NavigateRouteViewModel.CommandCreatedObject._firstPoint;
                //NavigateRouteViewModel.CommandCreatedObject._secondPoint;

                //Mapo.Children.Add(navigateRoute);
                Frame.Content = navigateRoute;
            }, p => true);



        }
    }
}
