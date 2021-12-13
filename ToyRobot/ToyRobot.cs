using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot

{
    public class ToyRobot
    {
        public int x = 0;
        public int y = 0;
        readonly public int maxrow = 5;
        readonly public int maxcol = 5;
        readonly public int maxpara = 4;
        public bool placed = false;
        public string currentdirection = string.Empty;

        public string Place(int row, int col, string direction)

        {
          string returnvalue = string.Empty;

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
                    returnvalue = "Provided direction isn't in a valid format";
                    return returnvalue;

            }

            // Checking to see if provided x & y values are inside the grid.

            if (row >= 0 && row <= maxrow && col >= 0 && col <= maxcol)

            {
                x = row;
                y = col;
                placed = true;
                returnvalue = string.Format("Successfully placed robot at {0},{1} facing {2}", x, y, currentdirection);
            }
            else
            {
                returnvalue = "Provided X & Y values aren't inside a 6x6 grid"; 
            }

            return returnvalue;
        }

        public bool Move()

        {
            // Uses the current direction to determine if moves is out of bounds, otherwise robot is moved.
            switch (currentdirection)
            {
                case "NORTH":
                    if (y + 1 <= 5)
                    {
                        y = y + 1; ;
                        return true;
                    }
                    break;

                case "EAST":

                    if (x + 1 <= 5)
                    {
                        x = x + 1;
                        return true;
                    }
                    break;

                case "SOUTH":
                    if (y - 1 >= 0)
                    {
                        y = y - 1;
                        return true;
                    }
                    break;

                case "WEST":
                    if (x - 1 >= 0)
                    {
                        x = x - 1;
                        return true;
                    }
                    break;
            }

            return false;

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

        public string Report()
        {
            string output = string.Format("{0},{1},{2}", x, y, currentdirection);
            return output;
        }
        public bool PlaceErrors(string[] input)
        {
            return GetPlaceErrors(input).Any();
        }

        public IEnumerable<string> GetPlaceErrors(string[] input)
        {
            int numbercheck;

            if (placed)
            {
                if (!(input.Length == maxpara - 1))
                {
                    yield return "Incorrect format has been supplied.Format must be PLACE X,Y e.g. PLACE 2,3";
                }
                else
                {
                    if (!(int.TryParse(input[1], out numbercheck) && int.TryParse(input[2], out numbercheck)))
                    {
                        yield return "X/Y parameters provided weren't valid numbers.Format must be PLACE X,Y,DIRECTION e.g. PLACE 2,3,NORTH";
                    }
                }
            }
            else
            {
                if (!(input.Length == maxpara))
                {
                    yield return "Incorrect format has been supplied.Format must be PLACE X,Y,DIRECTION e.g. PLACE 2,3,NORTH";
                }
                else
                {
                    if (!(int.TryParse(input[1], out numbercheck) && int.TryParse(input[2], out numbercheck)))
                    {
                        yield return "X/Y parameters provided weren't valid numbers.Format must be PLACE X,Y,DIRECTION e.g. PLACE 2,3,NORTH";
                    }
                }
            }
            yield break;
        }

    }
}
