﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public class LineStation
    {
        public int LineID { get; set; }

        public int Station { get; set; }

        public int LineStationIndex { get; set; }

        public int PrevStation { get; set; }

        public int NextStation { get; set; }
    }
}
