﻿using System;
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
    /// 
    public partial class Simulation : Window
    {
        IBL bl;
        TimeSpan time;
        DispatcherTimer timer = new DispatcherTimer();
        int mult = 1;
        public Simulation(IBL _bl)
        {
            InitializeComponent();
            bl = _bl;
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            stations_lv.ItemsSource = bl.GetAllStations();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            DateTime interval = DateTime.Now.AddHours(time.Hours)
    .AddMinutes(time.Minutes).AddSeconds(time.Seconds + mult);

            time = interval - DateTime.Now;
            time_lbl.Content = time.ToString().Substring(0, 8);
            if (stations_lv.SelectedValue != null)
                bl.UpdateTimeToArrive(stations_lv.SelectedValue as BO.Station, time);
            lineTiming_lv.Items.Refresh();
        }

        private void startSim_btn_Click(object sender, RoutedEventArgs e)
        {
            // TimeSpan t = new TimeSpan(int.Parse(hours_txtb.Text), int.Parse(minutes_txtb.Text), int.Parse(seconds_txtb.Text));
            //  bl.StartSimulation(t,int.Parse(speed_txtb.Text), applyChanges);

            timer.Start();
            startSim_btn.IsEnabled = false;
            apply_btn.IsEnabled = false;
            applyTime_btn.IsEnabled = false;
            hours_txtb.IsEnabled = false;
            minutes_txtb.IsEnabled = false;
            seconds_txtb.IsEnabled = false;
            speed_txtb.IsEnabled = false;
            stopSim_btn.IsEnabled = true;
            stations_lv.IsEnabled = true;
            select_lbl.IsEnabled = true;
        }
        //  private void applyChanges(TimeSpan time) { }

        private void applyTime_btn_Click(object sender, RoutedEventArgs e)
        {
            if (hours_txtb.Text.Length < 1 || minutes_txtb.Text.Length < 1 || seconds_txtb.Text.Length < 1 )
                MessageBox.Show("Wrong Time input, please fill all fields (hours, minutes, seconds) \ntry again! ", "ERROR"
                    , MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            else
            {
                DateTime interval = new DateTime();
                try
                {
                     interval = DateTime.Now.AddHours(Double.Parse(hours_txtb.Text))
                   .AddMinutes(Double.Parse(minutes_txtb.Text)).AddSeconds(Double.Parse(seconds_txtb.Text));
                }
               catch(Exception)
                {
                    MessageBox.Show("Wrong Time input, please fill all fields (hours, minutes, seconds) \ntry again! ", "ERROR"
                    , MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                    return; 
                }
                time = interval - DateTime.Now;
                hours_txtb.Clear();
                minutes_txtb.Clear();
                seconds_txtb.Clear();
                time_lbl.Content = time.ToString().Substring(0, 8);
                startSim_btn.IsEnabled = true;
            }
        }

        private void apply_btn_Click(object sender, RoutedEventArgs e)
        {
            if (speed_txtb.Text.Length < 1 || int.Parse(speed_txtb.Text) < 0)
                MessageBox.Show("Wrong speed input, \ntry again! ", "ERROR"
                    , MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            else
            {
                mult = int.Parse(speed_txtb.Text);
                speed_txtb.Clear();
            }
        }

        private void stopSim_btn_Click(object sender, RoutedEventArgs e)
        {
           // bl.StopSimulator();

            timer.Stop();
            apply_btn.IsEnabled = true;
            applyTime_btn.IsEnabled = true;
            hours_txtb.IsEnabled = true;
            minutes_txtb.IsEnabled = true;
            seconds_txtb.IsEnabled = true;
            speed_txtb.IsEnabled = true;
            stopSim_btn.IsEnabled = false;
            stations_lv.IsEnabled = false;
            select_lbl.IsEnabled = false;
            lineTiming_lv.IsEnabled = false;
            lines_lbl.Content = "";

        }

        private void stations_lv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BO.Station station = stations_lv.SelectedItem as BO.Station;
            lineTiming_lv.ItemsSource = bl.GetAllLinesInStation(station);
            lineTiming_lv.IsEnabled = true;
            lines_lbl.Content = "Incoming Lines For Station\n" + station.Name;
        }
    }
}
