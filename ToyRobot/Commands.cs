using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot

{
    public class ToyRobot
    {
        public int x { get; set; } = 0;
        public int y { get; set; } = 0;

        public int maxrow { get; set; } = 5;

        public int maxcol { get; set; } = 5;
        public bool placed { get; set; } = false; 
        
        public string currentdirection = string.Empty;





        public void Place(int row, int col, string direction)

        {

            // Ensures lower case inputs are accepted.

            direction = direction.ToUpper();


            // Sets the first direction when robot is placed.

            switch (direction)
            {
                case "NORTH":
                    currentdirection = direction;
                    break;

                case "EAST":
                    currentdirection = direction;
                    break;

                case "SOUTH":
                    currentdirection = direction;
                    break;
                case "WEST":
                    currentdirection = direction;
                    break;
                default:
                    Console.WriteLine("Provided direction isn't in a valid format");
                    break;


            }




            // Checking to see if provided x & y values are inside the grid.

            Console.WriteLine(row);
            Console.WriteLine(maxrow);
            if (row >= 0 && row < maxrow && col >= 0 && col < maxcol)

            {
                x = row;
                y = col;
                placed = true;

               


            }
            else
            {

                Console.WriteLine("Provided X & Y values aren't inside a 6x6 grid");

            }



        }

        public void Move()

        {


            // Uses the current direction to determine if moves is out of bounds, otherwise robot is moved.
            switch (currentdirection)
            {
                case "NORTH":
                    if (y + 1 > 5)
                    {
                        Console.WriteLine("Can't move {0}!", currentdirection);
                    }
                    else
                    {
                        y = y + 1; ;
                        Console.WriteLine("You moved {0}!", currentdirection);
                    }
                    break;

                case "EAST":

                    if (x + 1 > 5)
                    {
                        Console.WriteLine("Can't move {0}!", currentdirection);
                    }
                    else
                    {
                        x = x + 1;
                        Console.WriteLine("You moved {0}!", currentdirection);
                    }
                    break;


                case "SOUTH":
                    if (y - 1 < 0)
                    {
                        Console.WriteLine("Can't move {0}!", currentdirection);

                    }
                    else
                    {
                        y = y - 1;
                        Console.WriteLine("You moved {0}!", currentdirection);
                    }

                    break;
                case "WEST":
                    if (x - 1 < 0)
                    {
                        Console.WriteLine("Can't move {0}!", currentdirection);
                    }
                    else
                    {
                        x = x - 1;
                        Console.WriteLine("You moved {0}!", currentdirection);
                    }
                    break;


            }



        }

        public void TurnLeft()
        {


            switch (currentdirection)
            {
                case "NORTH":
                    currentdirection = "WEST";
                    break;

                case "EAST":
                    currentdirection = "NORTH";
                    break;

                case "SOUTH":
                    currentdirection = "EAST";
                    break;
                case "WEST":
                    currentdirection = "SOUTH";
                    break;

            }



        }

        public void TurnRight()
        {


            switch (currentdirection)
            {
                case "NORTH":
                    currentdirection = "EAST";
                    break;

                case "EAST":
                    currentdirection = "SOUTH";
                    break;

                case "SOUTH":
                    currentdirection = "WEST";
                    break;
                case "WEST":
                    currentdirection = "NORTH";
                    break;

            }



        }

        public void Report()

        {



        }
    }
}
