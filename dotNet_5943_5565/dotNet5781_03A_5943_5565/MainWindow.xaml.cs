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
using System.Windows.Navigation;
using System.Windows.Shapes;
using dotNet5781_02_5943_5565;

namespace dotNet5781_03A_5943_5565
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        BusLineCollection database = new BusLineCollection();
     
        public MainWindow()
        {
            Random r = new Random();
            for (int j = 1; j <= 10; j++)
            {
                List<BusStationLine> stations = new List<BusStationLine>();
                for (int i = 0; i < r.Next(2, 10); i++)  //initialize a list with 2-10 stations
                    stations.Add(new BusStationLine(i));

                database.AddBusLine(new BusLine(stations, j)); //adding line
            }

            InitializeComponent();

            // stuck in here
            cbBusLines.ItemsSource = database;
            cbBusLines.DisplayMemberPath = " BusLineNum ";
            cbBusLines.SelectedIndex = 0;
            //ShowBusLine(……….);
            /*
            cbHostList.ItemsSource = database;
            cbHostList.DisplayMemberPath = " BusLineNum ";
            cbHostList.SelectedIndex = 0;
            ShowBusLine(……….)*/

        }
    }
}
