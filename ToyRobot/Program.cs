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
        public static void Main(string[] args)
        {
            ToyRobot toyrobot = new ToyRobot();

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

                string[] inputSplit = input.Split(' ', ',');

                // Converts all characters in string array to upper case.

                inputSplit = Array.ConvertAll(inputSplit, x => x.ToUpper());

                // Command section. Will only accept other commands once the robot has been successfully placed.

                if (toyrobot.Placed)
                {
                    switch (inputSplit[0])
                    {
                        case "PLACE":

                            if (toyrobot.PlaceErrors(inputSplit))
                            {
                                foreach (string error in toyrobot.GetPlaceErrors(inputSplit))
                                {
                                    Console.WriteLine(error);
                                }
                            }
                            else
                            {
                                string output = toyrobot.Place(Int32.Parse(inputSplit[1]), Int32.Parse(inputSplit[2]), toyrobot.CurrentDirection);
                                Console.WriteLine(output);
                            }
                            break;

                        case "MOVE":
                            bool result = false;
                            result = toyrobot.Move();

                            if (result)
                            {
                                Console.WriteLine("You moved {0} to {1},{2}", toyrobot.CurrentDirection, toyrobot.x, toyrobot.y);
                            }
                            else
                            {
                                Console.WriteLine("You can't move {0}!", toyrobot.CurrentDirection);
                            }
                            break;

                        case "LEFT":

                            toyrobot.TurnLeft();
                            Console.WriteLine("You're now facing {0}!", toyrobot.CurrentDirection);
                            break;

                        case "RIGHT":
                            toyrobot.TurnRight();
                            Console.WriteLine("You're now facing {0}!", toyrobot.CurrentDirection);
                            break;

                        case "REPORT":
                            Console.WriteLine(toyrobot.Report());
                            break;

                        default:
                            Console.WriteLine("Invalid command");
                            break;
                    }
                }
                else
                {
                    switch (inputSplit[0])
                    {
                        case "PLACE":
                            if (toyrobot.PlaceErrors(inputSplit))
                            {
                                foreach (string error in toyrobot.GetPlaceErrors(inputSplit))
                                {
                                    Console.WriteLine(error);
                                }
                            }
                            else
                            {
                                string output = toyrobot.Place(Int32.Parse(inputSplit[1]), Int32.Parse(inputSplit[2]), inputSplit[3]);
                                Console.WriteLine(output);
                            }
                            break;

                        default:
                            Console.WriteLine("Pleace use the PLACE command to place the robot e.g. PLACE 2,3,SOUTH");
                            break;
                    }
                }
            } while (!Console.KeyAvailable);
        }
    }
}
