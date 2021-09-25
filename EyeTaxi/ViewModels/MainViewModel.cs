using EyeTaxi.Command;
using EyeTaxi.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EyeTaxi.ViewModels
{
    public class MainViewModel
    {
        public RelayCommand NavigateCommand { get; set; }
        public Grid Mapo { get; set; }
        public MainViewModel()
        {

            NavigateCommand = new RelayCommand(a =>
            {
                NavigateRoute navigateRoute = new NavigateRoute();
                Mapo.Children.Add(navigateRoute);
            }, p => true);
        }
    }
}
