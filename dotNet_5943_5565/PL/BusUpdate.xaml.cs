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
            liscenceNum_lbl.Content += toUpdate.LicenseNum.ToString();
        }
    }
}
