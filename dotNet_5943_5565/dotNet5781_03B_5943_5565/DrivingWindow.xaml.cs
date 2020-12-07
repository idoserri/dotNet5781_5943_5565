using System;
using System.Windows;
using System.Windows.Input;

namespace dotNet5781_03B_5943_5565
{
    /// <summary>
    /// Interaction logic for DrivingWindow.xaml
    /// </summary>
    public partial class DrivingWindow : Window
    {
        Bus v;
        MainWindow mainWindow;
        public static Random r = new Random(DateTime.Now.Millisecond);
        public DrivingWindow(Bus _v, MainWindow _mainWindow)
        {
            mainWindow = _mainWindow;
            v = _v;
            InitializeComponent();
            tbEnterDrive.Focus();
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && v.State == State.ready)
            {
                int distance = int.Parse(tbEnterDrive.Text);
                v.addDistance(distance);
                v.State = State.driving;
                v.changeState(State.driving, distance);
              //  mainWindow.Database.Sort(delegate (Bus c1, Bus c2) { return c1.MileageSinceTreatment.CompareTo(c2.MileageSinceTreatment); });
              //  mainWindow.Database.Reverse();
                //mainWindow.updateBuses();
                mainWindow.lvBusses.Items.Refresh();
                this.Close();
            }
        }
        private static void drive(double time)
        {


        }


    }
}
