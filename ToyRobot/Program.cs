using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ToyRobot
{
   public class Program
    {
        // Public variables for the x & y axis of the grid.

       public int x = 0;
       public int y = 0;
       public bool placed = false;
       public string currentdir = string.Empty;

        public static void Main(string[] args)
        {

            Program ToyRobot = new Program();

            // Console text on how to use and commands.

            Console.WriteLine("Telstra Purple Interview" +
                "1. This application allows you to move a Toy Robot inside a 6x6 grid." +
                Environment.NewLine +
                "2. First place the robot inside the grid using the command PLACE X,Y,DIRECTION:" +
                Environment.NewLine +
                "       - X = Row Integer 0-5 e.g. 3" +
                Environment.NewLine +
                "       - Y = Column Integer 0-5 e.g. 0" +
                   Environment.NewLine +
                "       - DIRECTION = Direction robot will face e.g. NORTH,SOUTH, EAST or WEST" +
                   Environment.NewLine +
                "3. Use the below commands to move the robot after it has been placed:" +
                   Environment.NewLine +
                "       - MOVE = Moves the robot one space in the direction it's facing" +
                   Environment.NewLine +
                "       - LEFT = Turn the robot 90 degrees to the LEFT" +
                   Environment.NewLine +
                "       - RIGHT = Turn the robot 90 degrees to the RIGHT" +
                   Environment.NewLine +
                "       - PLACE X/Y = Place the robot anwyhere in the grid whilst keeping the same direction" +
                   Environment.NewLine +
                "       - REPORT = Shows the current location and direction the robot is facing");

            // checking console input for recognised commands.

            do

            {
                string input;
                input = Console.ReadLine();

                // Splits the PLACE command into a string array for arguements.

                string[] inputsplit = input.Split(' ',',');

                // Command section. Will only accept other commands once the robot has been successfully placed.

                if (ToyRobot.placed == true)
                {
                    switch (inputsplit[0])
                    {
                        case "PLACE":
                        
                           ToyRobot.Place(Int32.Parse(inputsplit[1]), Int32.Parse(inputsplit[2]), ToyRobot.currentdir);
                            break;


                        case "MOVE":
                            ToyRobot.Move(ToyRobot.currentdir);
                            break;

                        case "LEFT":
                            ToyRobot.TurnLeft(ToyRobot.currentdir);
                            break;

                        case "RIGHT":
                            ToyRobot.TurnRight(ToyRobot.currentdir);
                            break;

                        case "REPORT":
                            ToyRobot.Report();
                            break;

                        default:
                            Console.WriteLine("Invalid command");
                            break;


                    }

                }

                else

                {

                    switch (inputsplit[0])
                    {
                        case "PLACE":
                   


                           ToyRobot.Place(Int32.Parse(inputsplit[1]), Int32.Parse(inputsplit[2]), inputsplit[3]);
                            break;


                        default:
                            Console.WriteLine("Pleace use the PLACE command to place the robot e.g. PLACE 2,3,SOUTH");
                            break;


                    }

                }

            } while (!Console.KeyAvailable);













        }

        public void Place(int row, int col, string direction)

        {
            // Ensures lower case inputs are accepted.

            direction = direction.ToUpper();


            // Sets the first direction when robot is placed.

            switch (direction)
            {
                case "NORTH":
                    currentdir = direction;
                    break;

                case "EAST":
                    currentdir = direction;
                    break;

                case "SOUTH":
                    currentdir = direction;
                    break;
                case "WEST":
                    currentdir = direction;
                    break;
                default:
                    Console.WriteLine("Provided direction isn't in a valid format");
                    break;


            }




            // Checking to see if provided x & y values are inside the grid.


            if (!(Enumerable.Range(0, 6).Contains(row) && (Enumerable.Range(0, 6).Contains(col))))
            {
                Console.WriteLine("Provided X & Y values aren't inside a 6x6 grid");


            }
            else
            {

                x = row;
                y = col;
                placed = true;


            }



        }

        public void Move(string direction)

        {
            

            // Uses the current direction to determine if moves is out of bounds, otherwise robot is moved.
            switch (direction)
            {
                case "NORTH":
                    if (y + 1 > 5)
                    {
                        Console.WriteLine("Can't move {0}!", direction);
                    }
                    else
                    {
                        y = y + 1; ;
                        Console.WriteLine("You moved {0}!", direction);
                    }
                    break;

                case "EAST":
                    currentdir = direction;
                    if (x + 1 > 5)
                    {
                        Console.WriteLine("Can't move {0}!", direction);
                    }
                    else
                    {
                        x = x + 1;
                        Console.WriteLine("You moved {0}!", direction);
                    }
                    break;


                case "SOUTH":
                    if (y - 1 < 0)
                    {
                        Console.WriteLine("Can't move {0}!", direction);

                    }
                    else
                    {
                        y = y - 1;
                        Console.WriteLine("You moved {0}!", direction);
                    }

                    break;
                case "WEST":
                    if (x - 1 < 0)
                    {
                        Console.WriteLine("Can't move {0}!", direction);
                    }
                    else
                    {
                        x = x - 1;
                        Console.WriteLine("You moved {0}!", direction);
                    }
                    break;


            }
           


        }

        public void TurnLeft(string direction)
        {
           

                switch (direction)
                {
                    case "NORTH":
                        currentdir = "WEST";
                        break;

                    case "EAST":
                        currentdir = "NORTH";
                        break;

                    case "SOUTH":
                        currentdir = "EAST";
                        break;
                    case "WEST":
                        currentdir = "SOUTH";
                        break;

                }


           
        }

        public void TurnRight(string direction)
        {

            
                switch (direction)
                {
                    case "NORTH":
                        currentdir = "EAST";
                        break;

                    case "EAST":
                        currentdir = "SOUTH";
                        break;

                    case "SOUTH":
                        currentdir = "WEST";
                        break;
                    case "WEST":
                        currentdir = "NORTH";
                        break;

                }

            

        }

        public void Report()

        {

                Console.WriteLine("{0},{1},{2}", x, y, currentdir);

        }







    }


}
