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
using System.Windows.Shapes;
using BLAPI;
namespace PL
{
    /// <summary>
    /// Interaction logic for Management.xaml
    /// </summary>
    public partial class Management : Window
    {
        IBL bl;
        public Management(IBL _bl)
        {
            InitializeComponent();
            bl = _bl;
        }

        void RefreshAndShowListView(string type)
        {
            switch (type)
            {
                
                case "lines":
                    Lines_lv.ItemsSource = from line in bl.GetAllLines().ToList()                                           
                                           orderby line.LastStationName
                                           select line;
                    Busses_lv.Visibility = Visibility.Hidden;
                    Stations_lv.Visibility = Visibility.Hidden;
                    Lines_lv.Visibility = Visibility.Visible;
                    Lines_lv.Items.Refresh();
                    break;
                case "stations":
                    Stations_lv.ItemsSource = from station in bl.GetAllStations().ToList()
                                              orderby station.Name
                                              select station;
                    Lines_lv.Visibility = Visibility.Hidden;
                    Busses_lv.Visibility = Visibility.Hidden;
                    Stations_lv.Visibility = Visibility.Visible;
                    Stations_lv.Items.Refresh();
                    break;
                case "busses":
                    Busses_lv.ItemsSource = from bus in bl.GetAllBusses().ToList()
                                            orderby bus.LicenseNum
                                            select bus;
                    Lines_lv.Visibility = Visibility.Hidden;
                    Stations_lv.Visibility = Visibility.Hidden;
                    Busses_lv.Visibility = Visibility.Visible;
                    Busses_lv.Items.Refresh();
                    break;
                default:
                    break;
            }
        }

        private void Lines_btn_Click(object sender, RoutedEventArgs e)
        {
            RefreshAndShowListView("lines");
        }

        private void Busses_btn_Click(object sender, RoutedEventArgs e)
        {
            RefreshAndShowListView("busses");
        }

        private void Stations_btn_Click(object sender, RoutedEventArgs e)
        {
            RefreshAndShowListView("stations");
        }


       // add !!!!!

        private void addBusButton_Click(object sender, RoutedEventArgs e)
        {
            BO.Bus b = (sender as Button).DataContext as BO.Bus;
            BusAdd busAdd = new BusAdd(bl);
            busAdd.ShowDialog();
            RefreshAndShowListView("busses");
        }

        private void addLineButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void addStationButton_Click(object sender, RoutedEventArgs e)
        {
            BO.Station s = (sender as Button).DataContext as BO.Station;
            StationAdd toAdd = new StationAdd(bl);
            toAdd.ShowDialog();
            RefreshAndShowListView("stations");

        }

        // updates !!!!
        private void bUpdateBus_Click(object sender, RoutedEventArgs e)
        {
            BO.Bus b = (sender as Button).DataContext as BO.Bus;
            BusUpdate busUpdate = new BusUpdate(b, bl);
            busUpdate.ShowDialog();
            RefreshAndShowListView("busses");
        }

        private void bUpdateLine_Click(object sender, RoutedEventArgs e)
        {
            BO.Line line = (sender as Button).DataContext as BO.Line;
            LineUpdate lineUpdate = new LineUpdate(line, bl);
            lineUpdate.ShowDialog();
            RefreshAndShowListView("lines");

        }

        private void bUpdateStation_Click(object sender, RoutedEventArgs e)
        {
            BO.Station b = (sender as Button).DataContext as BO.Station;
            StationUpdate busUpdate = new StationUpdate(b, bl);
            busUpdate.ShowDialog();
            RefreshAndShowListView("stations");

        }

        // deletes
        private void bDeleteBus_Click(object sender, RoutedEventArgs e)
        {
            BO.Bus b = (sender as Button).DataContext as BO.Bus;
            bl.DeleteBus(b.LicenseNum);
            RefreshAndShowListView("busses");
        }

        private void bDeleteStation_Click(object sender, RoutedEventArgs e)
        {
            BO.Station StationTo = (sender as Button).DataContext as BO.Station;
            bl.DeleteStation(StationTo.Code);
            RefreshAndShowListView("stations");
        }

        private void bDeleteLine_Click(object sender, RoutedEventArgs e)
        {
            BO.Line line = (sender as Button).DataContext as BO.Line;
            bl.DeleteLine(line.ID);
            RefreshAndShowListView("lines");
        }
    }
}
