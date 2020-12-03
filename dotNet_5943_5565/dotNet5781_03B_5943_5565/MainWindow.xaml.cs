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
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Random rand = new Random(DateTime.Now.Millisecond);
        static List<Bus> database = new List<Bus>();
        DispatcherTimer timer2;
        public List<Bus> Database
        {
            get => database; set => database = value;
        }
        public void Initialization()
        {
            // function to create 10 random buses
            for (int i = 0; i < 10; i++)
            {
                DateTime temp1 = new DateTime(rand.Next(2000, 2021), rand.Next(1, 13), (rand.Next(1, 29))); // random dates
                DateTime temp2 = new DateTime(rand.Next(2019, 2021), rand.Next(1, 13), (rand.Next(1, 29)));
                Bus toAdd = new Bus(rand.Next(0, 99999999), temp1, rand.Next(1000, 10000), rand.Next(0, 1201), temp2, rand.Next(0, 20000)); // random bus
                database.Add(toAdd);
            }
            // three different buses to impliment require conditions
            database[0].LastTreatment = DateTime.Now; // just treated
            database[1].MileageSinceTreatment = 19990;  // close to treatment by 10 KM
            database[1].Mileage += database[1].MileageSinceTreatment;
            database[2].FuelKM = 1;        // close to fueling
        }
        public MainWindow()
        {
            Initialization();
            InitializeComponent();
            lvBusses.ItemsSource = database;
            timer2 = new DispatcherTimer();
            timer2.Interval = TimeSpan.FromSeconds(3);
            timer2.Tick += Timer2_Tick;
            timer2.Start();
        }

        private void addBusButton_Click(object sender, RoutedEventArgs e)
        {
            AddBusWindow addBusWindow = new AddBusWindow(ref database);
            addBusWindow.ShowDialog();
            lvBusses.Items.Refresh();
        }

        private void bDrive_Click(object sender, RoutedEventArgs e)
        {
            Bus v = (sender as Button).DataContext as Bus;
            if (v.State == State.ready)
            {
                DrivingWindow drivingWindow = new DrivingWindow( v,  App.Current.MainWindow as MainWindow);
                drivingWindow.ShowDialog();
                lvBusses.Items.Refresh();
            }
        }

        private void bFuel_Click(object sender, RoutedEventArgs e)
        {
            Bus v = (sender as Button).DataContext as Bus;
            if (v.State == State.ready)
            {
                v.State = State.fueling;
            }
        }

        private void lvBusses_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DependencyObject obj = (DependencyObject)e.OriginalSource;

            while (obj != null && obj != lvBusses)
            {
                if (obj.GetType() == typeof(ListViewItem))
                {
                    Bus v = (sender as ListView).SelectedItem as Bus;
                    BusPresentationWindow newWindow = new BusPresentationWindow( v);
                    newWindow.ShowDialog();
                }
                obj = VisualTreeHelper.GetParent(obj);
            }
        }
        private void Timer2_Tick(object sender, EventArgs e)
        {
            updateTime();
            lvBusses.Items.Refresh();
            updateBuses();
            lvBusses.Items.Refresh();
        }
        public void updateTime()
        {
            foreach (Bus bus in database)
            {
                bus.timeUntillReady(DateTime.Now);
            }
            lvBusses.Items.Refresh();
        }
        public void updateBuses()
        {
            if (database.Count() != 0)
                foreach (Bus bus in database)
                {
                    bus.updateState(DateTime.Now);
                }
            lvBusses.Items.Refresh();
        }

    }
}
