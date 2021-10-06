using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Symbology;
using Esri.ArcGISRuntime.UI;
using Esri.ArcGISRuntime.UI.Controls;
using EyeTaxi.Command;
using EyeTaxi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using Color = System.Drawing.Color;

namespace EyeTaxiAdmin.ViewModel
{

    public class DriversAddViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyRaised([CallerMemberName] string propertyname = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
        public RelayCommand CloseButtonClickCommand { get; set; }
        public RelayCommand AddButtonClickCommand { get; set; }
        public RelayCommand MapRightClickCommand { get; set; }
        public RelayCommand MapLoadedCommand { get; set; }


        private string nameText;

        public string NameText
        {
            get { return nameText; }
            set { nameText = value; OnPropertyRaised(); }
        }

        private string surnameText;

        public string SurnameText
        {
            get { return surnameText; }
            set { surnameText = value; OnPropertyRaised(); }
        }
        private string phoneText;

        public string PhoneText
        {
            get { return phoneText; }
            set { phoneText = value; OnPropertyRaised(); }
        }

        private string carVendorText;

        public string CarVendorText
        {
            get { return carVendorText; }
            set { carVendorText = value; OnPropertyRaised(); }
        }

        private string carModelText;

        public string CarModelText
        {
            get { return carModelText; }
            set { carModelText = value; OnPropertyRaised(); }
        }
        private string carColor;

        public string CarColor
        {
            get { return carColor; }
            set { carColor = value; OnPropertyRaised(); }
        }


        private string carPlateText;

        public string CarPlateText
        {
            get { return carPlateText; }
            set { carPlateText = value; OnPropertyRaised(); }
        }
        public static Point TaxiPoint { get; set; } = new Point(-1, -1);
        public MapView MyMap { get; set; }
        public ObservableCollection<Driver> Drivers { get; set; }
            //= JsonConvert.DeserializeObject<ObservableCollection<Driver>>(File.ReadAllText($@"C:\Users\{Environment.UserName}\source\repos\EyeTaxi\EyeTaxi\Json Files\Drivers.json"));

        public DriversAddViewModel()
        {
            CloseButtonClickCommand = new RelayCommand(s =>
            {
                if (s is Window window)
                {
                    window.Close();
                }
            });

            MapLoadedCommand = new RelayCommand(s =>
            {
                MyMap = s as MapView;
            });
            MapRightClickCommand = new RelayCommand(s =>
            {

                if (TaxiPoint == new Point(-1, -1))
                    MyMap.GraphicsOverlays.Clear();
                SimpleMarkerSymbol stopSymbol = new SimpleMarkerSymbol(SimpleMarkerSymbolStyle.Diamond, Color.OrangeRed, 20);

                MyMap.GraphicsOverlays.Add(new GraphicsOverlay());

                MyMap.GraphicsOverlays[0].Graphics.Add(new Graphic(MyMap.ScreenToLocation(TaxiPoint), stopSymbol));
            });

            AddButtonClickCommand = new RelayCommand(s =>
            {
                if (!string.IsNullOrWhiteSpace(NameText))
                    if (!string.IsNullOrWhiteSpace(SurnameText))
                        if (!string.IsNullOrWhiteSpace(PhoneText))
                            if (!string.IsNullOrWhiteSpace(CarVendorText))
                                if (!string.IsNullOrWhiteSpace(CarModelText))
                                    if (!string.IsNullOrWhiteSpace(CarPlateText))
                                    {
                                        //if (TaxiPoint != new Point(-1, -1))
                                        {
                                            MapPoint PointTwo = new MapPoint(5571783.59037844, 4933881.61886646, SpatialReferences.WebMercator);


                                            var NewDriver = new Driver(NameText, SurnameText, PhoneText, CarModelText, CarVendorText, CarPlateText, CarColor, PointTwo);


                                            Drivers.Add(NewDriver);
                                            //Json Serialize
                                            var TextJson = JsonConvert.SerializeObject(Drivers, Formatting.Indented, new JsonSerializerSettings { FloatFormatHandling = FloatFormatHandling.DefaultValue, });
                                            File.WriteAllText($@"C:\Users\{Environment.UserName}\source\repos\EyeTaxi\EyeTaxi\Json Files\Drivers.json", TextJson);

                                        }
                                        //else
                                        {
                                            //throw handy control global warning right click the map select location
                                        }
                                    }
            });
        }

    }
}
