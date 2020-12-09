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
using System.Text.RegularExpressions;
namespace dotNet5781_03B_5943_5565
{
    /// <summary>
    /// Interaction logic for AddBusWindow.xaml
    /// this window will open when the user wants to 
    /// add a bus to the list and will creat a new
    /// bus.
    /// all the user had to do is to enter 
    /// liscense number.
    /// </summary>
    public partial class AddBusWindow : Window
    {
        List<Bus> database;
        public AddBusWindow(ref List<Bus> _database)
        { 
            // taking the database by reference so changes will be saved
            database = _database;
            InitializeComponent();
        }


        private void enterBusButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime temp = DateTime.Now;
            int lnum;
            Int32.TryParse(enterLiscenceTextBox.Text, out lnum); // casting liscence number
            if (lnum > 99999999) // checking range of input (screen a message if wrong)
                MessageBox.Show("The liscence number that was entered was out of range",
    "Liscence number is invalid",   
    MessageBoxButton.OK,
    MessageBoxImage.Stop,
    MessageBoxResult.OK);
            else
            {
                // creating new bus with liscence number that was entered
                Bus addedBus = new Bus(lnum, temp, 0, 1200, temp, 0, State.Ready);
                database.Add(addedBus); // adding to database
                this.Close();  // closing current window 
            }
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            // user also can end input with ENTER
            if (e.Key == Key.Enter)
                enterBusButton_Click(sender, e);
        }
    }
}
