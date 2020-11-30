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
        List<Bus> database = new List<Bus>();
        public static List<Bus> Initialization()
        {
            List<Bus> collection = new List<Bus>();
            // function to create 10 random buses
            for (int i = 0; i < 10; i++)
            {
                DateTime temp1 = new DateTime(rand.Next(2000, 2021), rand.Next(1, 13), (rand.Next(1, 31))); // random dates
                DateTime temp2 = new DateTime(rand.Next(2000, 2021), rand.Next(1, 13), (rand.Next(1, 31)));
                Bus toAdd = new Bus(rand.Next(0, 99999999), temp1, rand.Next(1000, 10000), rand.Next(0, 1201), temp2,rand.Next(0,20000)); // random bus
                collection.Add(toAdd);
            }
            // three different buses to impliment require conditions
            collection[0].LastTreatment = DateTime.Now; // just treated
            collection[1].MileageSinceTreatment = 19990;  // close to treatment by 10 KM
            collection[2].FuelKM = 1;        // close to fueling

            return collection;
        }
        public MainWindow()
        {
            database = Initialization();
            busListBox.DataContext =  database;

            InitializeComponent();
        }

        private void addBusButton_Click(object sender, RoutedEventArgs e)
        {
            //show new window for adding a bus
        }

       
    }
}
