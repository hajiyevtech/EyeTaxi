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
    public class DriverListPageModel
    {
        public ObservableCollection<Driver> Drivers { get; set; }

        public DriverListPageModel()
        {
            Drivers= new ObservableCollection<Driver>();
            var mp = new MapPoint(5571783.59037844, 4933881.61886646, SpatialReferences.WebMercator);

            var dr = new Driver("name", "Surname", "0558448831", "E60", "BMW", "50-CX-810", "Black", mp);

            Drivers.Add(dr);
        }
    }
}
