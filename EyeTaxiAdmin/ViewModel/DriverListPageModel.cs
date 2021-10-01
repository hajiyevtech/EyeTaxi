using EyeTaxi.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeTaxiAdmin.ViewModel
{
    public class DriverListPageModel
    {
        public ObservableCollection<Driver> Drivers { get; set; }

        public DriverListPageModel()
        {

        }
    }
}
