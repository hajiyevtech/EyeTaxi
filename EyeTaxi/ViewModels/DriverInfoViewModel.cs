using EyeTaxi.Command;
using EyeTaxi.Models;
using EyeTaxi.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EyeTaxi.ViewModels
{
    public class DriverInfoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyRaised([CallerMemberName] string propertyname = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
        public RelayCommand ViewLoadCommand { get; set; }
        public RelayCommand AcceptCommand { get; set; }
        public RelayCommand RejectCommand { get; set; }

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

        private string priceText;

        public string PriceText
        {
            get { return priceText; }
            set { priceText = value; OnPropertyRaised(); }
        }

        static public Driver MyDriver { get; set; }
        public DriverInfoViewModel()
        {


            AcceptCommand = new RelayCommand(s =>
            {
                DriverInfo.IsAccept = true;
                if (s is Window window)
                    window.Close();
            });
            RejectCommand = new RelayCommand(s =>
            {
                DriverInfo.IsAccept = false;
                if (s is Window window)
                    window.Close();
            });

            ViewLoadCommand = new RelayCommand(s =>
            {
                NameText = MyDriver.Name;
                SurnameText = MyDriver.Surname;
                PhoneText = MyDriver.Phone;

                CarVendorText = MyDriver.CarVendor;
                CarModelText = MyDriver.CarModel;
                CarPlateText = MyDriver.CarNumber;

                CarColor = MyDriver.CarColor;

                PriceText = DriverInfo.RoutePriceText;
            });

        }
    }
}
