using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet_00_5943_5565
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Welcome5943();
            Welcome5565();
            Console.ReadKey();
        }

        static partial void Welcome5565();
        private static void Welcome5943()
        {
            Console.WriteLine(" Enter your name: ");
            string x = Console.ReadLine();
            Console.WriteLine(x + ", welcome to my first console application");
        }
    }
}
