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
    public partial class BusAdd : Window
    {
        IBL bl;
        public BusAdd(IBL _bl)
        {
            InitializeComponent();
            bl = _bl;
            Status_cb.ItemsSource = Enum.GetValues(typeof(BO.Status));
        }

        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            BO.Bus toAdd = new BO.Bus
            {
                LicenseNum = Int32.Parse(licenseNum_txtb.Text),
                FromDate = fromDate_dp.DisplayDate,
                Mileage = Double.Parse(mileage_txtb.Text),
                BusStatus = (BO.Status)Status_cb.SelectedItem,
                FuelRemain = Double.Parse(fuelRemain_txtb.Text)
            };
            bl.AddBus(toAdd);
            this.Close();
        }
    }
}
