﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Station
    {
        public int Code { get; set; }

        public string Name { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public Areas Area { get; set; }

        public IEnumerable<Line> ListOfLines { get; set; }

        public IEnumerable<LineTiming> LineTimings { get; set; }
    }
}
