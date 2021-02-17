using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
   public class LineTiming
    {
        public int LineID { get; set; }

        public int LineNum { get; set; }

        public TimeSpan StartAt { get; set; }

        public string LastStation { get; set; }

        public int Arrival { get; set; }
    }
}
