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

namespace dotNet5781_03B_5943_5565
{
    /// <summary>
    /// Interaction logic for AddBusWindow.xaml
    /// </summary>
    public partial class AddBusWindow : Window
    {
        List<Bus> database = new List<Bus>();
        public AddBusWindow(List<Bus> _database)
        {
            database = _database;
            InitializeComponent();
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            Bus addedBus = new Bus();
            if(e.Key == Key.Enter)
            {
                addedBus.LicenseNumber = Int32.Parse(enterLiscenceTextBox.Text);
            }
            database.Add(addedBus);
            
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            Bus addedBus = new Bus();
            if (e.Key == Key.Enter)
            {
                addedBus.LicenseNumber = Int32.Parse(enterLiscenceTextBox.Text);
            }
            database.Add(addedBus);
        }
    }
}
