using System;
using System.Windows;
using System.Windows.Input;

namespace dotNet5781_03B_5943_5565
{
    /// <summary>
    /// Interaction logic for DrivingWindow.xaml
    /// </summary>
    public partial class DrivingWindow : Window
    {
        Bus v;
        MainWindow mainWindow;
        public static Random r = new Random(DateTime.Now.Millisecond);
        public DrivingWindow(ref Bus _v, MainWindow _mainWindow)
        {
            mainWindow = _mainWindow;
            v = _v;
            InitializeComponent();
            tbEnterDrive.Focus();
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            { 
                int distance = int.Parse(tbEnterDrive.Text);
                if (distance > v.FuelKM)
                {
                    MessageBox.Show("There isn't enough fuel in this bus for this distance.",
    "Not enough fuel",
    MessageBoxButton.OK,
    MessageBoxImage.Stop,
    MessageBoxResult.OK);
                }
                else if (distance + v.MileageSinceTreatment > 20000)
                {
                    MessageBox.Show("Bus will become dangerous if it takes this ride, it needs to go through maintenance.",
    "Bus needs maintenance",
    MessageBoxButton.OK,
    MessageBoxImage.Stop,
    MessageBoxResult.OK);
                }
                else
                {
                    v.addDistance(distance);
                    v.changeState(State.driving, distance);
                    mainWindow.Database.Sort(delegate (Bus c1, Bus c2) { return c1.MileageSinceTreatment.CompareTo(c2.MileageSinceTreatment); });
                    mainWindow.Database.Reverse();
                    mainWindow.updateBuses();
                    mainWindow.lvBusses.Items.Refresh();
                    this.Close();
                }
            }
        }
        


    }
}
