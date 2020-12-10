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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace dotNet5781_03B_5943_5565
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// present list of buses with KM since treatment, license number
    /// state, timer (00:00 if there is not operation running) ,
    /// and 2 buttons for fueling and maintence.
    /// also there is a button to add new bus to the list.
    /// by double click any bus a new window will open and 
    /// will present all the data about the selected bus.
    /// </summary>
    public partial class MainWindow : Window
    {
        // random variable for the program and creating database for the listview in main window
        public static Random rand = new Random(DateTime.Now.Millisecond);
        static List<Bus> database = new List<Bus>();
        DispatcherTimer timer2; // timer to show time utill bus finishes an operation
        public List<Bus> Database // properties for database
        {
            get => database;
            set => database = value;
        }
        public void Initialization() // of data base
        {
            // function to create 10 random buses
            for (int i = 0; i < 10; i++)
            {
                DateTime temp1 = new DateTime(rand.Next(2000, 2021), rand.Next(1, 13), (rand.Next(1, 29))); // random dates
                DateTime temp2 = new DateTime(rand.Next(2018, 2021), rand.Next(1, 13), (rand.Next(1, 29)));
                Bus toAdd = new Bus(rand.Next(0, 99999999), temp1, rand.Next(1000, 10000), rand.Next(0, 1201), temp2, rand.Next(0, 20000)); // random bus
                database.Add(toAdd);
            }
            // three different buses to impliment require conditions
            database[0].LastTreatment = DateTime.Now; // just treated
            database[1].MileageSinceTreatment = 19990;  // close to treatment by 10 KM
            database[1].Mileage += database[1].MileageSinceTreatment;
            database[2].FuelKM = 1;        // close to fueling
            database.Sort(delegate (Bus c1, Bus c2) { return c1.MileageSinceTreatment.CompareTo(c2.MileageSinceTreatment); });
            database.Reverse();
        }
        public MainWindow()
        {
            //Initializations
            Initialization();
            InitializeComponent();
            lvBusses.ItemsSource = database;
            timer2 = new DispatcherTimer();
            timer2.Interval = TimeSpan.FromSeconds(1); // update every second 
            timer2.Tick += Timer2_Tick;
            timer2.Start();  // start dispatcher operattion 
        }

        private void addBusButton_Click(object sender, RoutedEventArgs e)
        {
            // open new window to add a new bus by license number
            AddBusWindow addBusWindow = new AddBusWindow(ref database);
            addBusWindow.ShowDialog();
            lvBusses.Items.Refresh();
        }

        private void bDrive_Click(object sender, RoutedEventArgs e)
        {
            // if bus availabe to drive open new window
            Bus v = (sender as Button).DataContext as Bus;
            if (v.State == State.Ready)
            {
                DrivingWindow drivingWindow = new DrivingWindow(ref v, App.Current.MainWindow as MainWindow);
                drivingWindow.ShowDialog(); // window to recieve KM for the drive
                lvBusses.Items.Refresh();
            }
            else // if bus is unavailable show the message
                MessageBox.Show("The selected bus is unavailable for the ride. Please choose a different one.",
    "Bus is unavailable",
    MessageBoxButton.OK,
    MessageBoxImage.Stop,
    MessageBoxResult.OK);
        }

        private void bFuel_Click(object sender, RoutedEventArgs e)
        {
            // fueling bus if possible
            Bus v = (sender as Button).DataContext as Bus;
            if (v.FuelKM >= 1200) // check if tank is full
                MessageBox.Show("This Bus's fuel tank is already full", "Bus is already fueled", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                if (v.State == State.Ready) // if possible to fuel
                {
                    v.changeState(State.Fueling); //changeState
                    v.FuelKM = 1200; // update field
                }
                else // show message
                    MessageBox.Show("The selected bus is unavailable to refuel, it is either driving or needs maintenance.",
        "Bus is unavailable",
        MessageBoxButton.OK,
        MessageBoxImage.Stop,
        MessageBoxResult.OK);
            }
        }

        private void lvBusses_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //to find the origin of the double click
            DependencyObject obj = (DependencyObject)e.OriginalSource; 

            //loop to find the origin, once the parent is lvbusses it stops
            while (obj != null && obj != lvBusses)
            {
                //if obj is a lvItem-- open the bus presentation window
                if (obj.GetType() == typeof(ListViewItem)) 
                {
                    Bus v = (sender as ListView).SelectedItem as Bus;
                    BusPresentationWindow newWindow = new BusPresentationWindow(v);
                    newWindow.ShowDialog();
                }
                //obj = it's parent, stops when we reach lvbusses
                obj = VisualTreeHelper.GetParent(obj);
            }
        }
        private void Timer2_Tick(object sender, EventArgs e)
        {
            // updates to do every second
            AllUpdates();
        }
        public void AllUpdates()
        {

            if (database.Count() != 0)
                foreach (Bus bus in database)
                {
                    bus.timeUntillReady(DateTime.Now); // update timer until ready
                    bus.updateState(DateTime.Now); // update state 
                }
            database.Sort(delegate (Bus c1, Bus c2) { return c1.MileageSinceTreatment.CompareTo(c2.MileageSinceTreatment); });
            database.Reverse(); //sort the busses
            lvBusses.Items.Refresh(); // refresh list to show changes
        }
        public void updateTime()
         {
            // update timer until ready for all buses
            foreach (Bus bus in database)
                 bus.timeUntillReady(DateTime.Now);
             
             lvBusses.Items.Refresh(); // refresh list to show changes
        }
         public void updateBuses()
         {
             if (database.Count() != 0)
                 foreach (Bus bus in database)
                     bus.updateState(DateTime.Now); //update state for all buses

             lvBusses.Items.Refresh(); // refresh list to show changes
        }

        
    }
}
