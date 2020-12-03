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
    /// Interaction logic for DrivingWindow.xaml
    /// </summary>
    public partial class DrivingWindow : Window
    {
        Bus v;
        public static Random r = new Random(DateTime.Now.Millisecond);
        public DrivingWindow(ref Bus _v)
        {
            v = _v;
            InitializeComponent();
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                int speed = r.Next(20, 51);
                int kmToDrive = Int32.Parse(tbEnterDrive.Text);
                double time = (double)kmToDrive / (double)speed;
                v.State = State.driving;
                this.Close();
            }
        }
    }
}
