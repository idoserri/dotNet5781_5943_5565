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
        private BusLine currentDisplayBusLine;
        BusLineCollection database = new BusLineCollection();

        private void cbBusLines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowBusLine((cbBusLines.SelectedValue as BusLine).Line);
        }
        private void ShowBusLine(int index)
        {
            currentDisplayBusLine = database[index];
            UpGrid.DataContext = currentDisplayBusLine;
            lbBusLineStations.DataContext = currentDisplayBusLine.Stations;
        }
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

            
            cbBusLines.ItemsSource = database;
            cbBusLines.DisplayMemberPath = " line ";
            cbBusLines.SelectedIndex = 0;
            ShowBusLine(1);
            

        }

       

    }
}
