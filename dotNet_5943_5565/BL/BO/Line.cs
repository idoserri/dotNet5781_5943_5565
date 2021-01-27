using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Line
    {
        public int ID { get; set; }

        public int LineNum { get; set; }

        public int LastStation { get; set; }

        public Areas Area { get; set; }

        public string LastStationName { get; set; }

        public string TimeToArrive { get; set; }

        public IEnumerable<LineStation> ListOfLineStations { get; set; }
    }
}
