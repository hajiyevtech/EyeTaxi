using Esri.ArcGISRuntime.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeTaxi.Models
{
    public class Driver
    {
        public Driver(string name, string surname, string phone,
            string carModel, string carVendor, string carNumber,
            string carColor, MapPoint location)
        {
            Name = name;
            Surname = surname;
            Phone = phone;
            CarModel = carModel;
            CarVendor = carVendor;
            CarNumber = carNumber;
            CarColor = carColor;
            Location = location;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string CarModel { get; set; }
        public string CarVendor { get; set; }
        public string CarNumber { get; set; }
        public string CarColor { get; set; }
        public MapPoint Location { get; set; }

        public double Balance { get; set; }
        public double Rating { get; set; }
        public int CountTravel { get; set; }
        public double TotalRating { get; set; }
    }
}
