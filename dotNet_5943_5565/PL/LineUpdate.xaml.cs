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
        BO.Line ToUpdate;
        BO.Station ToAdd;
        public LineUpdate(BO.Line _Line, IBL _bl)
        {
            InitializeComponent();
            bl = _bl;
            ToUpdate = _Line;
            areas_cb.ItemsSource = Enum.GetValues(typeof(BO.Areas));
            areas_cb.SelectedValue = ToUpdate.Area;
            stations_lv.ItemsSource = bl.GetAllStationsNotInLine(ToUpdate);
            id_txtb.Text = ToUpdate.ID.ToString();
            lineNum_txtb.Text = ToUpdate.LineNum.ToString();
            listLineStations_lv.ItemsSource = bl.GetAllStationsInLine(ToUpdate);
            stationsOnLine_lv.ItemsSource = bl.GetAllStationsInLine(ToUpdate);
            Distance_lbl.Content += bl.CalcTotalLineDistance(ToUpdate).ToString("#.000") + " KM";
            Time_lbl.Content += bl.CalcTotalLineTime(ToUpdate);
        }



        private void Update_btn_Click(object sender, RoutedEventArgs e)
        {
            ToUpdate.Area = (BO.Areas)areas_cb.SelectedItem;
            ToUpdate.LineNum = Int32.Parse(lineNum_txtb.Text);
            bl.UpdateLine(ToUpdate);
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
            //add bl function to insert with line stationToAddAfter and toAdd
            bl.AddStationToLine(ToUpdate, ToAdd, addAfter);
            stationsOnLine_lv.ItemsSource = bl.GetAllStationsInLine(ToUpdate);
            listLineStations_lv.ItemsSource = bl.GetAllStationsInLine(ToUpdate);
            stations_lv.ItemsSource = bl.GetAllStationsNotInLine(ToUpdate);
            listLineStations_lv.Items.Refresh();
            stationsOnLine_lv.Items.Refresh();
            stations_lv.Items.Refresh();
            Distance_lbl.Content = "Total Distance: " + bl.CalcTotalLineDistance(ToUpdate).ToString("#.000") + " KM";
            Time_lbl.Content = "Total Time: " + bl.CalcTotalLineTime(ToUpdate);
            where_lbl.Visibility = Visibility.Hidden;
            listLineStations_lv.Visibility = Visibility.Hidden;
            listStations_lbl.Visibility = Visibility.Visible;
            stations_lv.Visibility = Visibility.Visible;
        }

        private void DeleteStationFromLine_btn_Click(object sender, RoutedEventArgs e)
        {
            BO.Station toDel = (sender as Button).DataContext as BO.Station;
            //messagebox "Are you sure????"
            bl.DeleteStationFromLine(ToUpdate,toDel.Code);
            stationsOnLine_lv.ItemsSource = bl.GetAllStationsInLine(ToUpdate);
            listLineStations_lv.ItemsSource = bl.GetAllStationsInLine(ToUpdate);
            stations_lv.ItemsSource = bl.GetAllStationsNotInLine(ToUpdate);
            listLineStations_lv.Items.Refresh();
            stationsOnLine_lv.Items.Refresh();
            stations_lv.Items.Refresh();
            Distance_lbl.Content = "Total Distance: " + bl.CalcTotalLineDistance(ToUpdate).ToString("#.000") + " KM";
            where_lbl.Visibility = Visibility.Hidden;
            listLineStations_lv.Visibility = Visibility.Hidden;
            listStations_lbl.Visibility = Visibility.Visible;
            stations_lv.Visibility = Visibility.Visible;
        }
    }
}
