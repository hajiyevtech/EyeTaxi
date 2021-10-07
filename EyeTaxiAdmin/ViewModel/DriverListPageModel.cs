﻿using EyeTaxi.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esri.ArcGISRuntime.Geometry;
using System.Windows;
using EyeTaxi.Command;
using System.Windows.Controls;

namespace EyeTaxiAdmin.ViewModel
{
    public class DriverListPageModel
    {
        public ObservableCollection<Driver> Drivers { get; set; }
        public static DriverListPageModel Current { get; set; }
        public RelayCommand DeleteBtnClickCommand { get; set; }
        public RelayCommand LoadCommand { get; set; }
        public ListView DriverListView { get; set; }
        public DriverListPageModel()
        {
            Drivers = new ObservableCollection<Driver>();

            var mp = new MapPoint(5571783.59037844, 4933881.61886646, SpatialReferences.WebMercator);

            var dr = new Driver("Meska", "Hajiyev", "0558448831", "E60", "BMW", "50-CX-810", "Black", new Point(mp.X,mp.Y));

            Drivers.Add(dr);
            Drivers.Add(dr);

            Current = this;

            LoadCommand = new RelayCommand(s =>
            {
                DriverListView = s as ListView;
            });

            DeleteBtnClickCommand = new RelayCommand(s =>
            {
                if (DriverListView.SelectedItems.Count>0)
                {
                    while (DriverListView.SelectedItems.Count>0)
                    {
                       Drivers.Remove(DriverListView.SelectedItems[0] as Driver);
                    }
                }

            });
        }
    }
}
