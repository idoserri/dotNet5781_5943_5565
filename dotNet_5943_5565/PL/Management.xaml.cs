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

        private void Lines_btn_Click(object sender, RoutedEventArgs e)
        {
            Lines_lv.ItemsSource = bl.GetAllLines().ToList();
            Busses_lv.Visibility = Visibility.Hidden;
            Stations_lv.Visibility = Visibility.Hidden;
            Lines_lv.Visibility = Visibility.Visible;
        }

        private void Busses_btn_Click(object sender, RoutedEventArgs e)
        {
            Busses_lv.ItemsSource = bl.GetAllBusses().ToList();
            Lines_lv.Visibility = Visibility.Hidden;
            Stations_lv.Visibility = Visibility.Hidden;
            Busses_lv.Visibility = Visibility.Visible;
        }

        private void Stations_btn_Click(object sender, RoutedEventArgs e)
        {
            Stations_lv.ItemsSource = bl.GetAllStations().ToList();
            Lines_lv.Visibility = Visibility.Hidden;
            Busses_lv.Visibility = Visibility.Hidden;
            Stations_lv.Visibility = Visibility.Visible;
        }

       

       // add !!!!!

        private void addBusButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void addLineButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void addStationButton_Click(object sender, RoutedEventArgs e)
        {

        }

        // updates !!!!
        private void bUpdateBus_Click(object sender, RoutedEventArgs e)
        {
            //some
        }

        private void bUpdateLine_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bUpdateStation_Click(object sender, RoutedEventArgs e)
        {

        }

        // deletes
        private void bDeleteBus_Click(object sender, RoutedEventArgs e)
        {
            //something
        }

        private void bDeleteStation_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bDeleteLine_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
