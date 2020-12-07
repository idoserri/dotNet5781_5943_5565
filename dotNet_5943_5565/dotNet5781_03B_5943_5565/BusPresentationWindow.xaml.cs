using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace dotNet5781_03B_5943_5565
{
    /// <summary>
    /// Interaction logic for BusPresentationWindow.xaml
    /// </summary>
    public partial class BusPresentationWindow : Window
    {
        public BusPresentationWindow(Bus v)
        {
            InitializeComponent();
            liscenceNum.Content +=  v.LicenseNumber.ToString();
            lastTreatment.Content += v.LastTreatment.ToString().Substring(0,8);
            startDate.Content += v.StartDate.ToString().Substring(0, 8);
            mileage.Content += v.Mileage.ToString();
            mileageSince.Content += v.MileageSinceTreatment.ToString();
            FuelKM.Content += v.FuelKM.ToString();
            State.Content += v.State.ToString();
           
        }

        private void Fuel_btn_Click(object sender, RoutedEventArgs e)
        {
        
            // fuel treat
        }

        private void Repair_btn_Click(object sender, RoutedEventArgs e)
        {
            // regular treat
        }
    }
}
