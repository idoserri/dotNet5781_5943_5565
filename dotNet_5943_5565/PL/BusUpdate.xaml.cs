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
    public partial class BusUpdate : Window
    {
        IBL bl;
        BO.Bus toUpdate;
        public BusUpdate(BO.Bus _bus, IBL _bl)
        {
            InitializeComponent();
            bl = _bl;
            toUpdate = _bus;
            licenseNum_txtb.Text = toUpdate.LicenseNum.ToString();
            mileage_txtb.Text = toUpdate.Mileage.ToString();
            fuelRemain_txtb.Text = toUpdate.FuelRemain.ToString();
            Status_cb.ItemsSource = Enum.GetValues(typeof(BO.Status));
            Status_cb.SelectedValue = toUpdate.BusStatus;
            fromDate_dp.DisplayDate = toUpdate.FromDate;
        }

        private void update_btn_Click(object sender, RoutedEventArgs e)
        {
            toUpdate.FromDate = fromDate_dp.DisplayDate;
            toUpdate.FuelRemain = Double.Parse(fuelRemain_txtb.Text);
            toUpdate.LicenseNum = Int32.Parse(licenseNum_txtb.Text);
            toUpdate.BusStatus = (BO.Status)Status_cb.SelectedItem;
            toUpdate.Mileage = Double.Parse(mileage_txtb.Text);
            bl.UpdateBus(toUpdate);
            this.Close();
        }
    }
}
