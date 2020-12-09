using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using System.Threading;
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
    /// this window presents the bus data and allowed 
    /// you to fuel and treat the selected bus 
    /// </summary>
    public partial class BusPresentationWindow : Window
    {
        Bus v; // object to present
        public BusPresentationWindow(Bus _v)
        {
            v = _v; // initilize object to present
            InitializeComponent();
            // updating lebels to present data
            liscenceNum.Content +=  v.LicenseNumber.ToString();
            lastTreatment.Content += v.LastTreatment.ToString().Substring(0,10);
            startDate.Content += v.StartDate.ToString().Substring(0,10);
            mileage.Content += v.Mileage.ToString();
            mileageSince.Content += v.MileageSinceTreatment.ToString();
            FuelKM.Content += v.FuelKM.ToString();
            State.Content += v.State.ToString();
           
        }

        // buttons settings

        private void Fuel_btn_Click(object sender, RoutedEventArgs e)
        {
            if (v.State == dotNet5781_03B_5943_5565.State.Treatment)
                MessageBox.Show("The selected bus is under treatment. Please wait until completion.",
"Bus is currently under treatment",
MessageBoxButton.OK,
MessageBoxImage.Stop,
MessageBoxResult.OK);
            else if(v.State == dotNet5781_03B_5943_5565.State.Driving)
                MessageBox.Show("The selected bus is currently driving. Please wait until completion of trip.",
"Bus is currently driving",
MessageBoxButton.OK,
MessageBoxImage.Stop,
MessageBoxResult.OK);
            else // if state is ready start fueling 
            {
                // update fields
                v.FuelKM = 1200;
                v.changeState(dotNet5781_03B_5943_5565.State.Fueling);
                FuelKM.Content = " FuelKM:         12000 ";
                State.Content = " state:            fueling ";
                InitializeComponent();
                State.Content += ",  just fueled";
            }
        }

        private void Repair_btn_Click(object sender, RoutedEventArgs e)
        {
            if (v.State == dotNet5781_03B_5943_5565.State.Fueling)
                MessageBox.Show("The selected bus is currently fueling. Please wait until completion.",
"Bus is currently fueling",
MessageBoxButton.OK,
MessageBoxImage.Stop,
MessageBoxResult.OK);
            else if (v.State == dotNet5781_03B_5943_5565.State.Driving)
                MessageBox.Show("The selected bus is currently driving. Please wait until completion of trip.",
"Bus is currently driving",
MessageBoxButton.OK,
MessageBoxImage.Stop,
MessageBoxResult.OK);
            else // if state is ready start treatment 
            {
                // update fields
                v.LastTreatment = DateTime.Now;
                v.MileageSinceTreatment = 0;
                v.changeState(dotNet5781_03B_5943_5565.State.Treatment);
                lastTreatment.Content = "Last treatment date:     " + v.LastTreatment.ToString().Substring(0, 10);
                mileageSince.Content = "Mileage since last treatment:  " + v.MileageSinceTreatment.ToString();
                InitializeComponent();
                State.Content += " , just repaired";
            }
        }
    }
}
