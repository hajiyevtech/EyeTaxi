using EyeTaxi.Command;
using EyeTaxi.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EyeTaxi.ViewModels
{
    public class MainViewModel
    {
        public RelayCommand NavigateCommand { get; set; }
        public RelayCommand LeftButtonCommand { get; set; }
        public RelayCommand GetMapGridCommand { get; set; }
        public Grid Mapo { get; set; }
        public MainViewModel()
        {

            GetMapGridCommand = new RelayCommand(s =>
            {
                Mapo = s as Grid;
            }, e => { return true; });

            NavigateCommand = new RelayCommand(a =>
            {
                NavigateRoute navigateRoute = new NavigateRoute();
                Mapo.Children.Add(navigateRoute);
            }, p => true);

            LeftButtonCommand = new RelayCommand(s => {
                MessageBox.Show("salam Mestan");
            }, e => { return true; });

        }
    }
}
