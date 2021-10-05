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
using System.Windows;
using System.Windows.Controls;

namespace EyeTaxiAdmin.ViewModel
{
    public class AdminPanelViewModel
    {
        public RelayCommand AdminPanelViewFrameLoad { get; set; }

        public RelayCommand CloseButtonClickCommand { get; set; }
        public AdminPanelViewModel()
        {

            CloseButtonClickCommand = new RelayCommand(s =>
            {
                if (s is Window window)
                {
                    window.Close();
                }
            });

            AdminPanelViewFrameLoad = new RelayCommand(s =>
            {
                var frame = s as Frame;

                var Content = new DriversListPage();

               

                frame.Content = Content;

            });

        }
    }
}
