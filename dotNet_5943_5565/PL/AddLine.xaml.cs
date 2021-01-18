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
    public partial class AddLine : Window
    {
        IBL bl;
        BO.Line toAdd = new BO.Line();
        BO.Station stationAdded;
        BO.LineStation firstStation = new BO.LineStation(), lastStation = new BO.LineStation();
        int count = 0;
        public AddLine(BO.Line _Line, IBL _bl)
        {
            InitializeComponent();
            bl = _bl;
            toAdd.ID = bl.GetAllLines().Count() + 1;
            id_txtb.Text = toAdd.ID.ToString();
            stations_lv.ItemsSource = bl.GetAllStations();
            areas_cb.ItemsSource = Enum.GetValues(typeof(BO.Areas));
        }
        private void AddStationToLine_btn_Click(object sender, RoutedEventArgs e)
        {
            stationAdded = (sender as Button).DataContext as BO.Station;
            if (count == 0)
            {
                listStations_lbl.Content = "Select Last Station: ";
                firstStation = new BO.LineStation
                {
                    LineID = toAdd.ID,
                    Station = stationAdded.Code,
                    PrevStation = 0,
                    NextStation = 0,
                    LineStationIndex = 0
                };
                count++;
            }
            else
            {
                lastStation = new BO.LineStation
                {
                    LineID = toAdd.ID,
                    Station = stationAdded.Code,
                    PrevStation = firstStation.Station,
                    NextStation = 0,
                    LineStationIndex = 1
                };
                firstStation.NextStation = lastStation.Station;
                stations_lv.IsEnabled = false;
                count++;
            }

        }
        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            if (count != 2)
                MessageBox.Show("Please select first and last stations.");
            else
            {
                toAdd.Area = (BO.Areas)areas_cb.SelectedValue;
                toAdd.LastStation = lastStation.Station;
                toAdd.LineNum = Int32.Parse(lineNum_txtb.Text);
                bl.AddLine(toAdd, firstStation, lastStation);
                this.Close();
            }
        }
    }
}
