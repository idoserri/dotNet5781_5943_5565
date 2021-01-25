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
using System.Windows.Threading;
using BLAPI;
namespace PL
{
    /// <summary>
    /// Interaction logic for Simulation.xaml
    /// </summary>
    public partial class Simulation : Window
    {
        IBL bl;
        TimeSpan time;
        DispatcherTimer timer = new DispatcherTimer();
        int mult = 0;
        public Simulation(IBL _bl)
        {
            InitializeComponent();
            bl = _bl;
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
        }
        void timer_Tick(object sender, EventArgs e)
        {
            DateTime interval = DateTime.Now.AddHours(time.Hours)
    .AddMinutes(time.Minutes).AddSeconds(time.Seconds + mult);
            time = interval - DateTime.Now;
            time_lbl.Content = time.ToString().Substring(0, 8);
        }

        private void startSim_btn_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
            startSim_btn.IsEnabled = false;
            apply_btn.IsEnabled = false;
            applyTime_btn.IsEnabled = false;
            hours_txtb.IsEnabled = false;
            minutes_txtb.IsEnabled = false;
            seconds_txtb.IsEnabled = false;
            speed_txtb.IsEnabled = false;
            stopSim_btn.IsEnabled = true;
        }

        private void applyTime_btn_Click(object sender, RoutedEventArgs e)
        {
            DateTime interval = DateTime.Now.AddHours(Double.Parse(hours_txtb.Text))
                .AddMinutes(Double.Parse(minutes_txtb.Text)).AddSeconds(Double.Parse(seconds_txtb.Text));
            time = interval - DateTime.Now;
            hours_txtb.Clear();
            minutes_txtb.Clear();
            seconds_txtb.Clear();
            time_lbl.Content = time.ToString().Substring(0,8);
        }

        private void apply_btn_Click(object sender, RoutedEventArgs e)
        {
            mult = int.Parse(speed_txtb.Text);
            speed_txtb.Clear();
        }

        private void stopSim_btn_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            startSim_btn.IsEnabled = true;
            apply_btn.IsEnabled = true;
            applyTime_btn.IsEnabled = true;
            hours_txtb.IsEnabled = true;
            minutes_txtb.IsEnabled = true;
            seconds_txtb.IsEnabled = true;
            speed_txtb.IsEnabled = true;
            stopSim_btn.IsEnabled = false;
        }
    }
}
