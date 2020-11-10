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
            for (int i = 0; i < 10; i++)
            {
                //so there's at least 10 stations with more than 1 bus and every station has a line
                BusLine bus = temp.GetSubLine(temp.Stations[i * 4], temp.Stations[temp.Stations.Count-i]); 
                bus.Line = i;
                database.AddBusLine(bus);
            }
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
                try
                {
                    switch (choice)
                    {
                        case "1":
                            Console.WriteLine("Enter your choice: \n1-Add a new bus line\n2-Add a station to a line\n");
                            secondaryChoice = Console.ReadLine();
                            switch (secondaryChoice)
                            {
                                case "1":
                                    Console.WriteLine("Enter Bus Line:\n");
                                    int code = Console.Read();
                                    database.AddBusLine(new BusLine(new List<BusStationLine>(), code));
                                    break;
                                case "2":
                                    Console.WriteLine("Enter the Line to add the station to:\n");
                                    code = Console.Read();
                                    BusLine bus = database.FindBusLine(new BusLine(new List<BusStationLine>(), code));
                                    database.RemoveBusLine(bus);
                                    Console.WriteLine("Enter Bus Station Code:\n");
                                    code = Console.Read();
                                    Console.WriteLine("Enter Bus Station Address\n");
                                    string address = Console.ReadLine();
                                    Console.WriteLine("Enter Bus Station Index\n");
                                    int index = Console.Read();
                                    bus.AddStation(index, new BusStationLine(code, address));
                                    database.AddBusLine(bus);
                                    break;
                            }
                            break;
                        case "2":
                            Console.WriteLine("Enter your choice: \n1-Remove a bus line\n2-Remove a station from a line\n");
                            secondaryChoice = Console.ReadLine();
                            switch (secondaryChoice)
                            {
                                case "1":
                                    Console.WriteLine("Enter Bus Line to remove: \n");
                                    int code = Console.Read();
                                    database.RemoveBusLine(new BusLine(new List<BusStationLine>(), code));
                                    break;
                                case "2":
                                    Console.WriteLine("Enter the Line to remove the station from:\n");
                                    code = Console.Read();
                                    BusLine bus = database.FindBusLine(new BusLine(new List<BusStationLine>(), code));
                                    database.RemoveBusLine(bus);
                                    Console.WriteLine("Enter Bus Station Code to Remove:\n");
                                    code = Console.Read();
                                    bus.RemoveStation(code);
                                    database.AddBusLine(bus);
                                    break;
                            }
                            break;
                        case "3":
                            Console.WriteLine("Enter your choice: \n" +
                                "1-Search for all the lines that go through a certain station\n" +
                                "2-Search for the shortest route between 2 stations\n");
                            secondaryChoice = Console.ReadLine();
                            switch (secondaryChoice)
                            {
                                case "1":
                                    Console.WriteLine("Enter station code:\n");
                                    int code = Console.Read();
                                    Console.Write($"Stations that go through station {code}:");
                                    foreach (BusLine item in database)
                                    {
                                        foreach (BusStationLine station in item.Stations)
                                        {
                                            if(station.Code == code)
                                                Console.Write($"{item.Line}, ");
                                        }
                                    }
                                    break;
                                    

                            }
                    }
                }
                catch
                {

                }
            }
        }
    }
}
