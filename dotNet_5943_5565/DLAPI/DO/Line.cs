﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{

    public class Line
    {
        public int ID { get; set; }
        
        public int LineNum { get; set; }

        public Areas Area { get; set; }

        public int FirstStation { get; set; }

        public int LastStation { get; set; }

    }
}
