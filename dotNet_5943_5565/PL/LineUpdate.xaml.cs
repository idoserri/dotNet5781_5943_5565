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
        public LineUpdate(BO.Line _Line, IBL _bl)
        {
            InitializeComponent();
            bl = _bl;
            ToUpdate = _Line;
            areas_cb.ItemsSource = Enum.GetValues(typeof(BO.Areas));
            areas_cb.SelectedValue = ToUpdate.Area;
            stations_lv.ItemsSource = bl.GetAllStations();
            lastStation_cb.ItemsSource = from station in bl.GetAllStations()
                                         select station.Name;
            lastStation_cb.SelectedValue = bl.GetAllStations().ToList()
                .Find(station => station.Code == ToUpdate.LastStation).Name;
        }



        private void Update_btn_Click(object sender, RoutedEventArgs e)
        {
            ToUpdate.Area = (BO.Areas)areas_cb.SelectedItem;
            bl.UpdateLine(ToUpdate);
            this.Close();
        }
    }
}
