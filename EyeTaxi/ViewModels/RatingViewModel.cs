using EyeTaxi.Command;
using EyeTaxi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EyeTaxi.ViewModels
{
    public class RatingViewModel:Window
    {
        public RelayCommand DoneButtonCommand { get; set; }
        static public Driver SelectedDriver { get; set; }


        public int RatingValue
        {
            get { return (int)GetValue(RatingValueProperty); }
            set { SetValue(RatingValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RatingValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RatingValueProperty =
            DependencyProperty.Register("RatingValue", typeof(int), typeof(RatingViewModel));


        public RatingViewModel()
        {
            DoneButtonCommand = new RelayCommand(s =>
            {
                SelectedDriver.TotalRating = SelectedDriver.TotalRating + RatingValue;
                SelectedDriver.Rating = SelectedDriver.TotalRating / SelectedDriver.CountTravel;
                if (s is Window window)
                {
                    window.Close();
                }
            });
        }

    }
}
