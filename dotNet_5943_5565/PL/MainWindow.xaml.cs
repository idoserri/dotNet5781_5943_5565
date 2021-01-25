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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BLAPI;
namespace PL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IBL bl = BLFactory.GetBL("1");
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Open_management_window(object sender, RoutedEventArgs e)
        {
            Management ToOpen = new Management(bl);
            ToOpen.ShowDialog();
        }

        private void Open_passenger_window(object sender, RoutedEventArgs e)
        {
            Simulation ToOpen = new Simulation(bl);
            ToOpen.ShowDialog();
        }
    }
}
