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
    public partial class StationUpdate : Window
    {
        IBL bl;
        BO.Station ToUpdate;
        public StationUpdate(BO.Station _Station, IBL _bl)
        {
            InitializeComponent();
            bl = _bl;
            ToUpdate = _Station;
            areas_cb.ItemsSource = Enum.GetValues(typeof(BO.Areas));
            code_txtb.Text = ToUpdate.Code.ToString();
            name_txtb.Text = ToUpdate.Name.ToString();
            latitude_txtb.Text = ToUpdate.Latitude.ToString();
            longitude_txtb.Text = ToUpdate.Longitude.ToString();
            areas_cb.ItemsSource = Enum.GetValues(typeof(BO.Areas));
            areas_cb.SelectedValue = ToUpdate.Area;
            LinesIn_lv.ItemsSource = bl.GetAllLinesInStation(ToUpdate);


        }



        private void Update_btn_Click(object sender, RoutedEventArgs e)
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
                ToUpdate.Code = Int32.Parse(code_txtb.Text);
                ToUpdate.Name = name_txtb.Text;
                ToUpdate.Area = (BO.Areas)areas_cb.SelectedItem;
                ToUpdate.Latitude = Double.Parse(latitude_txtb.Text);
                ToUpdate.Longitude = Double.Parse(longitude_txtb.Text);
                //ToUpdate.ListOfLines = lines_lbl.DataContext as List;
                bl.UpdateStation(ToUpdate);
                this.Close();

            }
        }
    }
}
