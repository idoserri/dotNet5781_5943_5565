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
        }

        private void add_btn_Click(object sender, RoutedEventArgs e)
        {

            BO.Station toAdd = new BO.Station
            {
                Code = Int32.Parse(code_txtb.Text),
                Name = name_txtb.Text,
                Latitude = Int32.Parse(latitude_txtb.Text),
                Longitude = Int32.Parse(longitude_txtb.Text),
                Area = (BO.Areas)(areas_cb.SelectedItem),
                
                 //need list of lines !!!!!
            };
            bl.AddStation(toAdd);
            this.Close();
        }
    }
}
