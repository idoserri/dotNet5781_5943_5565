using System;
using System.Windows;
using System.Windows.Input;

namespace dotNet5781_03B_5943_5565
{
    /// <summary>
    /// Interaction logic for DrivingWindow.xaml
    /// this window will open when the user wants
    /// to take a bus to drive.
    /// this window can open just for bus with "ready" state.
    /// </summary>
    public partial class DrivingWindow : Window
    {
        // objects to use 
        Bus v; 
        MainWindow mainWindow;
        public static Random r = new Random(DateTime.Now.Millisecond);
        public DrivingWindow(ref Bus _v, MainWindow _mainWindow)
        {
            // saving parameters to class
            // and Initializes window
            mainWindow = _mainWindow;
            v = _v;
            InitializeComponent();
            tbEnterDrive.Focus();
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            // if user press ENTER go to function to handle 
            // the KM to drive and updates
            if (e.Key == Key.Enter) 
                btnDrive_Click(sender, e);
        }

        private void btnDrive_Click(object sender, RoutedEventArgs e)
        {

            int distance = int.Parse(tbEnterDrive.Text); // casting value 
            if (distance > v.FuelKM) // if there isnt enough fuel to take the drive
            {
                // screen a message
                MessageBox.Show("There isn't enough fuel in this bus for this distance.",
"Not enough fuel",
MessageBoxButton.OK,
MessageBoxImage.Stop,
MessageBoxResult.OK);
            }
            else if (distance + v.MileageSinceTreatment >= 20000)
            {
                // if the bus will become dangerous if it takes this ride 
                // more then 20000 KM without treatment, screen a message
                MessageBox.Show("Bus will become dangerous if it takes this ride, it needs to go through maintenance.",
"Bus needs maintenance",
MessageBoxButton.OK,
MessageBoxImage.Stop,
MessageBoxResult.OK);
            }
            else
            {
                // if bus is able to take the ride 
                // update fields 
                v.addDistance(distance);
                v.changeState(State.Driving, distance);
                // to present data clearly we sorted by Mileage Since Treatment
                mainWindow.Database.Sort(
                    delegate (Bus c1, Bus c2)
                { return c1.MileageSinceTreatment.CompareTo(c2.MileageSinceTreatment); });
                mainWindow.Database.Reverse();
                mainWindow.updateBuses();
                mainWindow.lvBusses.Items.Refresh();
                this.Close(); // closing window and back to main window
            }
        }
    }
    
}
