using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_5943_5565
{
    class Program
    {
        static void Main(string[] args)
        {
            BusLineCollection database = new BusLineCollection();
            List<BusStationLine> tempStations = new List<BusStationLine>();
            for (int i = 0; i < 40; i++)
                tempStations.Add(new BusStationLine(i));
            BusLine temp = new BusLine(tempStations, 0);
            string choice, secondaryChoice;
            bool menuLoop = true;            //since we want the menu to loop until the user chooses to exit
            while (menuLoop)
            {
                Console.WriteLine(              //show the menu for the user
@"Enter your choice: 
1 - Adding Options
2 - Removing Options
3 - Searching Options
4 - Printing Options
5 - Exit");
                choice = Console.ReadLine();//read the user's choice in the menu
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Enter your choice: \n1-Add a new bus line\n2-Add a station to a line");
                        secondaryChoice = Console.ReadLine();
                        switch (secondaryChoice)
                        {
                            case "1":


                        }

                }
            }
        }
    }
}
