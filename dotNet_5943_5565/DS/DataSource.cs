using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;

namespace DS
{
    public static class DataSource
    {
        public static List<Bus> listBusses;
        public static List<Station> listStations;
        public static List<Line> listLines;
        public static List<LineStation> listLineStations;
        public static List<AdjacentStations> listAdjacentStations;
            
        static DataSource()
        {
            InitialLists();
        }
        static void InitialLists()
        {
            //initial the lists with randoms
        }
    }
}
