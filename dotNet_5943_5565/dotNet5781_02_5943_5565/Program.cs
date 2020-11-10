using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_5943_5565
{
    class Program
    {
        static void Main(string[] args)
        {
            BusLineCollection database = new BusLineCollection();
            List<BusStationLine> stations = new List<BusStationLine>();
            for (int i = 0; i < 40; i++)
                stations.Add(new BusStationLine(i));
            BusLine temp = new BusLine(stations, 0);
            for (int i = 0; i < 10; i++)
            {
                //so there's at least 10 stations with more than 1 bus and every station has a line
                BusLine bus = temp.GetSubLine(temp.Stations[i * 4], temp.Stations[temp.Stations.Count-i-1]); 
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
                            Console.WriteLine("Enter your choice: \n" +
                                "1 - Add a new bus line\n" +
                                "2 - Add a station to a line\n");
                            secondaryChoice = Console.ReadLine();
                            switch (secondaryChoice)
                            {
                                case "1":
                                    Console.WriteLine("Enter Bus Line:");
                                    int code = Int32.Parse(Console.ReadLine());
                                    database.AddBusLine(new BusLine(new List<BusStationLine>(), code));
                                    break;
                                case "2":
                                    Console.WriteLine("Enter the Line to add the station to:");
                                    code = Int32.Parse(Console.ReadLine());
                                    BusLine bus = database.FindBusLine(new BusLine(new List<BusStationLine>(), code));
                                    database.RemoveBusLine(bus);
                                    Console.WriteLine("Enter Bus Station Code:");
                                    code = Int32.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter Bus Station Address: ");
                                    string address = Console.ReadLine();
                                    stations.Add(new BusStationLine(code, address));
                                    Console.WriteLine($"Enter Bus Station Index: (Highest index right now: {database.Count-1} ");
                                    int index = Int32.Parse(Console.ReadLine());
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
                                    int code = Int32.Parse(Console.ReadLine());
                                    database.RemoveBusLine(new BusLine(new List<BusStationLine>(), code));
                                    break;
                                case "2":
                                    Console.WriteLine("Enter the Line to remove the station from:\n");
                                    code = Int32.Parse(Console.ReadLine()); 
                                    BusLine bus = database.FindBusLine(new BusLine(new List<BusStationLine>(), code));
                                    database.RemoveBusLine(bus);
                                    Console.WriteLine("Enter Bus Station Code to Remove:\n");
                                    code = Int32.Parse(Console.ReadLine());
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
                                            if (station.Code == code)
                                                Console.Write($"{item.Line}, ");
                                        }
                                    }
                                    break;
                                case "2":
                                    Console.WriteLine("Enter first station code:\n");
                                    int code1 = Console.Read();
                                    Console.WriteLine("Enter second station code:\n");
                                    int code2 = Console.Read();
                                    BusLineCollection times = new BusLineCollection();
                                    foreach (BusLine item in database)
                                    {
                                        if (item.CheckStationExists(new BusStationLine(code1))
                                            && item.CheckStationExists(new BusStationLine(code2)))
                                        {
                                            BusLine tempBus = item.GetSubLine(item.FindStation(code1), item.FindStation(code2));
                                            times.AddBusLine(item);
                                        }
                                    }
                                    times.SortBusList();
                                    Console.WriteLine("Fastest Lines: ");
                                    foreach (BusLine item in times)
                                        Console.WriteLine($"Line {item.Line}: {item.GetTotalRideTime()} hours");
                                    break;
                                    /*List<TimeSpan> times = new List<TimeSpan>();
                                    foreach (BusLine item in database)
                                    {
                                        TimeSpan t = new TimeSpan(0);
                                        bool count = false;
                                        foreach (BusStationLine station in item.Stations)
                                        {
                                            if (count)
                                                t += station.TimeFromLastStation;
                                            if (station.Code == code1)
                                                count = true;
                                            if (station.Code == code2)
                                                count = false;
        
                                        }
                                        times.Add(t);
                                    }
                                    times.Sort();
                                    Console.WriteLine(times);

                                            break;*/
                            }
                            break;
                        case "4":
                            Console.WriteLine("Enter your choice: \n" +
                                "1-Print all of the lines in the database\n" +
                                "2-Print all of the stations and the lines that go through them\n");
                            secondaryChoice = Console.ReadLine();
                            switch (secondaryChoice)
                            {
                                case "1":
                                    foreach (BusLine item in database)
                                        Console.WriteLine(item.ToString());
                                    break;
                                case "2":
                                    foreach (BusStationLine station in stations)
                                    {
                                        Console.Write($"{station.ToString()}, Lines: ");
                                        foreach (BusLine bus in database)
                                            if (bus.CheckStationExists(station))
                                                Console.Write($"{bus.Line}, ");
                                        Console.Write("\n");
                                    }
                                    break;
                            }
                            break;
                        case "5":
                            menuLoop = false;
                            break;
                        default:
                            Console.WriteLine("please enter a number between 1-5");   // the case where the user entered a choice that's invalid
                            break;
                    }
                }
                catch (Exception msg)
                {
                    Console.WriteLine(msg.Message);
                }
            }
        }
    }
}
