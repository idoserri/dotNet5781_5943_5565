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
    /// Interaction logic for Management.xaml
    /// </summary>
    public partial class Management : Window
    {
        IBL bl;
        public Management(IBL _bl)
        {

            bl = _bl;
            Lines_lv.ItemsSource = bl.GetAllLines();
            InitializeComponent();
        }

        private void Lines_btn_Click(object sender, RoutedEventArgs e)
        {
            Lines_lv.Visibility = Visibility.Visible;

        }
    }
}
