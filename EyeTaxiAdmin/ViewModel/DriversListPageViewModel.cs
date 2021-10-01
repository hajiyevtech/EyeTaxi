using EyeTaxi.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esri.ArcGISRuntime.Geometry;

namespace EyeTaxiAdmin.ViewModel
{
    public class DriversListPageViewModel
    {
        public ObservableCollection<Driver> Drivers { get; set; }
        public DriversListPageViewModel()
        {
            Drivers = new ObservableCollection<Driver>();

            MapPoint mapPoint= new MapPoint();

            Driver D1= new Driver("Name","Surname","E60","BMW","50-CX-810","Black",);


            Drivers.Add(null);




        }

    }
}
