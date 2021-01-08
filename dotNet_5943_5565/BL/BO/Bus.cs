using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Bus
    {
        public int LicenseNum { get; set; }

        public DateTime FromDate { get; set; }

        public double Mileage { get; set; }

        public double FuelRemain { get; set; }

        public Status BusStatus { get; set; }

        public string LiscenseNumString
        {
            get
            {
                if (this.FromDate.Year >= 2018)
                {
                    int[] arr = new int[8];
                    int num = this.LicenseNum;
                    for (int i = 7; i >= 0; i--)
                    {
                        arr[i] = num % 10;
                        num /= 10;
                    }
                    return String.Format("{0}{1}{2}-{3}{4}-{5}{6}{7}",
                        arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], arr[6], arr[7]);
                }
                else
                {
                    int[] arr = new int[7];
                    int num = this.LicenseNum;
                    for (int i = 6; i >= 0; i--)
                    {
                        arr[i] = num % 10;
                        num /= 10;
                    }
                    return String.Format("{0}{1}-{2}{3}{4}-{5}{6}",
                        arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], arr[6]);
                }
            }
        }
    }
}
