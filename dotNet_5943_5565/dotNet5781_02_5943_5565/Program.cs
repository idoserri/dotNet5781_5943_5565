using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

// bus collection database program

namespace dotNet5781_02_5943_5565
{
    class Program
    {
        static void Main(string[] args)
        {
            BusLineCollection database = new BusLineCollection();
            List<BusStationLine> stations = new List<BusStationLine>();
            for (int i = 0; i < 40; i++)  //initialize a list with 40 stations
                stations.Add(new BusStationLine(i));
            BusLine temp = new BusLine(stations, 0);
            for (int i = 0; i < 10; i++)//initialize the collection of busses with varying lists of stations
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
                        case "1": //case add
                            Console.WriteLine("Enter your choice: \n" +
                                "1 - Add a new bus line\n" +
                                "2 - Add a station to a line");
                            secondaryChoice = Console.ReadLine();
                            switch (secondaryChoice)
                            {
                                case "1": //case add line
                                    Console.WriteLine("Enter Bus Line:");
                                    int code = Int32.Parse(Console.ReadLine()); //read the bus line from the user
                                    database.AddBusLine(new BusLine(new List<BusStationLine>(), code)); //add it to the collection 
                                    break;
                                case "2": //case add stations
                                    Console.WriteLine("Enter the Line to add the station to:");
                                    code = Int32.Parse(Console.ReadLine()); //read the bus line
                                    BusLine bus = database.FindBusLine(new BusLine(new List<BusStationLine>(), code)); //find it in the database
                                    Console.WriteLine("Enter Bus Station Code:");
                                    code = Int32.Parse(Console.ReadLine());  //read the station code
                                    Console.WriteLine("Enter Bus Station Address: "); 
                                    string address = Console.ReadLine();    //read the station address
                                    stations.Add(new BusStationLine(code, address));  //add the station to the stations list
                                    bus.AddStation(database.Count, new BusStationLine(code, address));  //add the station to the busses database
                                    break;
                            }
                            break;
                        case "2": //case remove
                            Console.WriteLine("Enter your choice: \n" +
                                "1-Remove a bus line\n" +
                                "2-Remove a station from a line");
                            secondaryChoice = Console.ReadLine();
                            switch (secondaryChoice)
                            {
                                case "1":  //case remove line
                                    Console.WriteLine("Enter Bus Line to remove: \n");
                                    int code = Int32.Parse(Console.ReadLine());   
                                    database.RemoveBusLine(new BusLine(new List<BusStationLine>(), code)); //remove bus from database
                                    break;
                                case "2": //case remove station
                                    Console.WriteLine("Enter the Line to remove the station from:\n"); 
                                    code = Int32.Parse(Console.ReadLine()); 
                                    BusLine bus = database.FindBusLine(new BusLine(new List<BusStationLine>(), code)); //find the bus to remove the station from 
                                    Console.WriteLine("Enter Bus Station Code to Remove:\n");
                                    code = Int32.Parse(Console.ReadLine());
                                    bus.RemoveStation(code);    //remove station from bus line
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
                                case "1": //case search lines in station
                                    Console.WriteLine("Enter station code:\n");
                                    int code = Int32.Parse(Console.ReadLine());
                                    Console.Write($"Stations that go through station {code}: ");
                                    foreach (BusLine item in database)
                                    {
                                        foreach (BusStationLine station in item.Stations)
                                        {
                                            if (station.Code == code)//if the code matches- print the line
                                                Console.Write($"{item.Line}, ");
                                        }
                                    }
                                    Console.Write("\n");
                                    break;
                                case "2": // case shortest route
                                    Console.WriteLine("Enter first station code:\n");
                                    int code1 = Int32.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter second station code:\n");
                                    int code2 = Int32.Parse(Console.ReadLine());
                                    BusLineCollection times = new BusLineCollection(); //temporary bus collection for times
                                    foreach (BusLine item in database)
                                    {
                                        if (item.CheckStationExists(new BusStationLine(code1))
                                            && item.CheckStationExists(new BusStationLine(code2)))//if both stations exist in the line
                                        {
                                            BusLine tempBus = item.GetSubLine(item.FindStation(code1), item.FindStation(code2)); //just the route between the lines
                                            times.AddBusLine(item); //add to the temporary collections
                                        }
                                    }
                                    times.SortBusList();   //sort the list
                                    Console.WriteLine("Fastest Lines: ");
                                    foreach (BusLine item in times)
                                        Console.WriteLine($"Line {item.Line}: {item.GetTotalRideTime()} hours"); //print the times
                                    break;
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
                                    foreach (BusLine item in database) //print all the busses in the database
                                        Console.WriteLine(item.ToString()); 
                                    break;
                                case "2":
                                    foreach (BusStationLine station in stations) //print all the lines for each station
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
                            menuLoop = false; //so we can end the loop and exit the program
                            break;
                        default:
                            Console.WriteLine("please enter a number between 1-5");   // the case where the user entered a choice that's invalid
                            break;
                    }
                }
                catch (Exception msg)
                {
                    Console.WriteLine(msg.Message); //print exceptions
                }
            }
        }
    }
}
