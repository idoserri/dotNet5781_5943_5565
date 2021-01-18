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
    /// Interaction logic for BusUpdate.xaml
    /// </summary>
    public partial class LineUpdate : Window
    {
        IBL bl;
        BO.Line toUpdate;
        BO.Station ToAdd;
        public LineUpdate(BO.Line _Line, IBL _bl)
        {
            InitializeComponent();
            bl = _bl;
            toUpdate = _Line;
            areas_cb.ItemsSource = Enum.GetValues(typeof(BO.Areas));
            LineTrips_lv.ItemsSource = bl.GetLineTrips(toUpdate);
            areas_cb.SelectedValue = toUpdate.Area;
            stations_lv.ItemsSource = bl.GetAllStationsNotInLine(toUpdate);
            id_txtb.Text = toUpdate.ID.ToString();
            lineNum_txtb.Text = toUpdate.LineNum.ToString();
            listLineStations_lv.ItemsSource = bl.GetAllStationsInLine(toUpdate);
            stationsOnLine_lv.ItemsSource = bl.GetAllStationsInLine(toUpdate);
            Distance_lbl.Content += bl.CalcTotalLineDistance(toUpdate).ToString("#.000") + " KM";
            Time_lbl.Content += bl.CalcTotalLineTime(toUpdate);
        }



        private void Update_btn_Click(object sender, RoutedEventArgs e)
        {
            toUpdate.Area = (BO.Areas)areas_cb.SelectedItem;
            toUpdate.LineNum = Int32.Parse(lineNum_txtb.Text);
            bl.UpdateLine(toUpdate);
            this.Close();
        }

        private void AddStationToLine_btn_Click(object sender, RoutedEventArgs e)
        {
            ToAdd = (sender as Button).DataContext as BO.Station;
            where_lbl.Visibility = Visibility.Visible;
            listLineStations_lv.Visibility = Visibility.Visible;
            listStations_lbl.Visibility = Visibility.Hidden;
            stations_lv.Visibility = Visibility.Hidden;
        }

        private void AddStationAfter_btn_Click(object sender, RoutedEventArgs e)
        {
            BO.Station addAfter = (sender as Button).DataContext as BO.Station;
            bl.AddStationToLine(toUpdate, ToAdd.Code, addAfter.Code);
            stationsOnLine_lv.ItemsSource = bl.GetAllStationsInLine(toUpdate);
            listLineStations_lv.ItemsSource = bl.GetAllStationsInLine(toUpdate);
            stations_lv.ItemsSource = bl.GetAllStationsNotInLine(toUpdate);
            listLineStations_lv.Items.Refresh();
            stationsOnLine_lv.Items.Refresh();
            stations_lv.Items.Refresh();
            Distance_lbl.Content = "Total Distance: " + bl.CalcTotalLineDistance(toUpdate).ToString("#.000") + " KM";
            Time_lbl.Content = "Total Time: " + bl.CalcTotalLineTime(toUpdate);
            where_lbl.Visibility = Visibility.Hidden;
            listLineStations_lv.Visibility = Visibility.Hidden;
            listStations_lbl.Visibility = Visibility.Visible;
            stations_lv.Visibility = Visibility.Visible;
        }

        private void DeleteStationFromLine_btn_Click(object sender, RoutedEventArgs e)
        {
            BO.Station toDel = (sender as Button).DataContext as BO.Station;
            //messagebox "Are you sure????"
            bl.DeleteStationFromLine(toUpdate,toDel.Code);
            stationsOnLine_lv.ItemsSource = bl.GetAllStationsInLine(toUpdate);
            listLineStations_lv.ItemsSource = bl.GetAllStationsInLine(toUpdate);
            stations_lv.ItemsSource = bl.GetAllStationsNotInLine(toUpdate);
            listLineStations_lv.Items.Refresh();
            stationsOnLine_lv.Items.Refresh();
            stations_lv.Items.Refresh();
            Distance_lbl.Content = "Total Distance: " + bl.CalcTotalLineDistance(toUpdate).ToString("#.000") + " KM";
            where_lbl.Visibility = Visibility.Hidden;
            listLineStations_lv.Visibility = Visibility.Hidden;
            listStations_lbl.Visibility = Visibility.Visible;
            stations_lv.Visibility = Visibility.Visible;
        }

        private void addLineTrip_btn_Click(object sender, RoutedEventArgs e)
        {
            AddLineTrip addLT = new AddLineTrip(toUpdate.ID);
            addLT.ShowDialog();
        }

        private void DeleteLineTrip_btn_Click(object sender, RoutedEventArgs e)
        {
            BO.LineTrip toDel = (sender as Button).DataContext as BO.LineTrip;
            bl.DeleteLineTrip(toDel);
            LineTrips_lv.ItemsSource = bl.GetLineTrips(toUpdate);
            LineTrips_lv.Items.Refresh();
        }
    }
}
