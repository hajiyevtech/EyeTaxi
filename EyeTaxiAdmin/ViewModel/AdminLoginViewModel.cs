using EyeTaxi.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EyeTaxiAdmin.ViewModel
{
    public class AdminLoginViewModel
    {
        public RelayCommand CloseButtonClickCommand { get; set; }
        public AdminLoginViewModel()
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
