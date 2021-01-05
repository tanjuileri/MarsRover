using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Linq;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                WriteConsole("Please write the upper-right coordinates of the plateau and Press 'Enter'");
                WriteConsole("Sample: 5 5");
                var upperRightCoordinates = Console.ReadLine();

                while (!Regex.Match(upperRightCoordinates, @"\d+\s\d+").Success)
                {
                    WriteConsole("Please write the correct format => X Y");
                    WriteConsole("Sample: 10 10");
                    upperRightCoordinates = Console.ReadLine();
                }

                var coordinates = upperRightCoordinates.Split(" ");
                var upperRightCornerX = Convert.ToInt32(coordinates[0]);
                var upperRightCornerY = Convert.ToInt32(coordinates[1]);
                var c = true;

                while (c)
                {
                    WriteConsole("Now, Please enter the Rover position and direction");
                    WriteConsole("Sample: 1 2 N");
                    var roverPosition = Console.ReadLine();

                    while (!Regex.Match(roverPosition, @"\d+\s\d+\s\w").Success)
                    {
                        WriteConsole("Please write the correct format => X Y D");
                        WriteConsole("Sample: 10 10 N");
                        roverPosition = Console.ReadLine().ToUpperInvariant();
                    }

                    var rover = new Rover(roverPosition, upperRightCornerX, upperRightCornerY);

                    WriteConsole("Now, Please enter the Rover's move orders");
                    WriteConsole("Sample: LMLMLMLMM");
                    var orderList = new char[] { 'L', 'M', 'R' };
                    var moveOrders = Console.ReadLine();

                    while (!Regex.Match(moveOrders, @"\w+").Success || moveOrders.ToCharArray().Where(c => !orderList.Contains(c)).ToArray().Length > 0)
                    {
                        WriteConsole("Please write the correct format => LRM");
                        WriteConsole("Sample: LMLMLMLMM");
                        moveOrders = Console.ReadLine().ToUpperInvariant();
                    }

                    rover.Move(moveOrders);

                    WriteConsole(string.Format("Rover's new position and Direction : {0}", rover.LastPosition));
                    var yOrN = string.Empty;


                    while (yOrN != "Y" && yOrN != "N")
                    {
                        WriteConsole("Do you want to move your next rover? Y/N");
                        yOrN = Console.ReadLine().ToUpperInvariant();
                    }

                    c = yOrN == "Y";
                }
            }
            catch (Exception e)
            {
                WriteConsole(e.Message);
            }
        }

        public static void WriteConsole(string text)
        {
            foreach (var item in text)
            {
                Console.Write(item);
                Thread.Sleep(50);
            }

            Console.WriteLine("");
        }
    }
}
