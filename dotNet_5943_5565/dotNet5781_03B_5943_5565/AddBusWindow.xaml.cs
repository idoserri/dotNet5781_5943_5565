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
        List<Bus> database;
        public AddBusWindow(ref List<Bus> _database)
        {
            database = _database;
            InitializeComponent();
        }


        private void enterBusButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime temp = DateTime.Now;
            int lnum = Int32.Parse(enterLiscenceTextBox.Text);
            Bus addedBus = new Bus(lnum, temp, 0, 1200, temp, 0, State.ready);
            database.Add(addedBus);
            this.Close();
        }
    }
}
