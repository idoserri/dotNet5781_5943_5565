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
    /// add some station to list in database
    /// </summary>
    public partial class StationAdd : Window
    {
        IBL bl;
        public StationAdd(IBL _bl)
        {
            InitializeComponent();
            bl = _bl;
            areas_cb.ItemsSource = Enum.GetValues(typeof(BO.Areas));
            code_txtb.Text = (bl.GetAllStations().Count() + 1).ToString();
        }

        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            if (name_txtb.Text.Length < 1)
                MessageBox.Show("Wrong Name of station \ntry again!", "ERROR",
                    MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);

            else if (latitude_txtb.Text.Length < 1 || longitude_txtb.Text.Length < 1 ||
                Double.Parse(latitude_txtb.Text) < 31 || Double.Parse(latitude_txtb.Text) > 33.3
                || Double.Parse(longitude_txtb.Text) < 34.3 || Double.Parse(longitude_txtb.Text) > 35.5)
                MessageBox.Show("Wrong Cordinates of stations (check if it's out of bounds) \ntry again!", "ERROR",
                   MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);

            else
            {
                BO.Station toAdd = new BO.Station
                {
                    Code = Int32.Parse(code_txtb.Text),
                    Name = name_txtb.Text,
                    Latitude = Double.Parse(latitude_txtb.Text),
                    Longitude = Double.Parse(longitude_txtb.Text),
                    Area = (BO.Areas)(areas_cb.SelectedItem),
                };
                bl.AddStation(toAdd);
                this.Close();
            }
        }
    }
}
