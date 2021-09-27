using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EyeTaxi.Views
{
    /// <summary>
    /// Interaction logic for RegistrationView.xaml
    /// </summary>
    public partial class RegistrationView : Window
    {
        public RegistrationView View { get; set; }
        public RegistrationView()
        {
            InitializeComponent();
        }

        private void LogBtn_Click(object sender, RoutedEventArgs e)
        {
            RegView.Visibility = Visibility.Collapsed;
            LoginView.Visibility = Visibility.Visible;

        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            RegView.Visibility = Visibility.Visible;
            LoginView.Visibility = Visibility.Collapsed;
        }
    }
}
