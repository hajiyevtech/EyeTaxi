using EyeTaxi.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EyeTaxiAdmin.ViewModel
{

    public class DriversAddViewModel
    {
    public RelayCommand CloseButtonClickCommand { get; set; }

        public DriversAddViewModel()
        {
            CloseButtonClickCommand = new RelayCommand(s =>
            {
                if (s is Window window)
                {
                    window.Close();
                }
            });
        }

    }
}
