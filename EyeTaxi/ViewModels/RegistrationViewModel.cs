using EyeTaxi.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EyeTaxi.ViewModels
{
    public class RegistrationViewModel : INotifyPropertyChanged
    {
        public RelayCommand LogBtnClickCommand { get; set; }
        public RelayCommand RegBtnClickCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyRaised([CallerMemberName] string propertyname = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        private Visibility logViewVisibility= Visibility.Collapsed;

        public Visibility LogViewVisibility
        {
            get { return logViewVisibility; }
            set { logViewVisibility = value; OnPropertyRaised(); }
        }

        private Visibility regViewVisibility=Visibility.Visible;

        public Visibility RegViewVisibility
        {
            get { return regViewVisibility; }
            set { regViewVisibility = value; OnPropertyRaised(); }
        }

        public RegistrationViewModel()
        {
            LogBtnClickCommand = new RelayCommand(s =>
            {
                RegViewVisibility = Visibility.Collapsed;
                LogViewVisibility = Visibility.Visible;
            });
            RegBtnClickCommand = new RelayCommand(s =>
            {
                RegViewVisibility = Visibility.Visible;
                LogViewVisibility = Visibility.Collapsed;
            });

        }
    }
}
