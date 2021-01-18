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
    /// Interaction logic for AddLineTrip.xaml
    /// </summary>
    public partial class AddLineTrip : Window
    {
        IBL bl;
        BO.LineTrip = new BO.LineTrip();
        public AddLineTrip(int lineID)
        {
            InitializeComponent();
            id_txtb.Text = lineID.ToString();
        }

        private void AddLineTrip_btn(object sender, RoutedEventArgs e)
        {
            TimeSpan start_At, freq, finish_At;
           if(TimeSpan.TryParse(start_txtb.Text , out start_At) == false)
            {
                MessageBox.Show("Wrong time format, Try again", "ERROR", 
                    MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                return;
            }

            if (TimeSpan.TryParse(finish_txtb.Text, out finish_At) == false)
            {
                MessageBox.Show("Wrong time format, Try again", "ERROR",
                    MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                return;
            }

            if (TimeSpan.TryParse(frequency_txt.Text, out freq) == false)
            {
                MessageBox.Show("Wrong time format, Try again", "ERROR",
                    MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                return;
            }

            





        }
    }
}
