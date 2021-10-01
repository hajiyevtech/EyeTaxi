using Esri.ArcGISRuntime.Geometry;
using EyeTaxi.Command;
using EyeTaxi.Models;
using EyeTaxiAdmin.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EyeTaxiAdmin.ViewModel
{
    public class AdminPanelViewModel
    {
        public  RelayCommand AdminPanelViewFrameLoad { get; set; }
        public AdminPanelViewModel()
        {
            AdminPanelViewFrameLoad = new RelayCommand(s =>
            {
                var frame = s as Frame;

                var Content = new DriversListPage();

                var mp = new MapPoint(5571783.59037844, 4933881.61886646, SpatialReferences.WebMercator);

                var dr = new Driver("Meska", "Hajiyev", "0558448831", "E60", "BMW", "50-CX-810","Black",mp);
                
                DriverListPageModel.Current.Drivers.Add(dr);

                frame.Content =Content;
                
            });

        }
    }
}
