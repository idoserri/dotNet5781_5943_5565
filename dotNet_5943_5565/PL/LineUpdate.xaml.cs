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
            stations_lv.ItemsSource = from station in bl.GetAllStations()
                                      where ToUpdate.ListOfStations.ToList().Find(s => s.Code == station.Code) == null
                                      select station;
            
            lastStation_cb.ItemsSource = from station in bl.GetAllStations()
                                         select station.Name;
            lastStation_cb.SelectedValue = bl.GetAllStations().ToList()
                .Find(station => station.Code == ToUpdate.LastStation).Name;
            id_txtb.Text = ToUpdate.ID.ToString();
            lineNum_txtb.Text = ToUpdate.LineNum.ToString();
            listLineStations_lv.ItemsSource = from station in ToUpdate.ListOfStations
                                              select station;
            stationsOnLine_lv.ItemsSource = from station in ToUpdate.ListOfStations
                                            select station;
        }



        private void Update_btn_Click(object sender, RoutedEventArgs e)
        {
            ToUpdate.Area = (BO.Areas)areas_cb.SelectedItem;
            ToUpdate.LastStation = (from station in bl.GetAllStations().ToList()
                                    let name = lastStation_cb.SelectedValue as string
                                    where station.Name == name
                                    select station.Code).First();
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
        }

        private void DeleteStationFromLine_btn_Click(object sender, RoutedEventArgs e)
        {
            //add bl function to delete from listofstations
        }
    }
}
