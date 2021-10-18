﻿using System;
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

namespace EyeTaxiAdmin.Views
{
    /// <summary>
    /// Interaction logic for AdminPanelView.xaml
    /// </summary>
    public partial class AdminPanelView : Window
    {
        public AdminPanelView()
        {
            InitializeComponent();
        }
        private void window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed) return;
            DragMove();
        }

    }
}
