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
        readonly public int maxrow = 5;
        readonly public int maxcol = 5;
        readonly public int maxpara = 4;
        public bool Placed { get; set; } = false;
        public string CurrentDirection { get; set; } = string.Empty;

        public string Place(int row, int col, string direction)
        {
            // Sets the first direction when robot is placed

            switch (direction)
            {
                case "NORTH":
                    CurrentDirection = direction;
                    break;

                case "EAST":
                    CurrentDirection = direction;
                    break;

                case "SOUTH":
                    CurrentDirection = direction;
                    break;
                case "WEST":
                    CurrentDirection = direction;
                    break;

                default:
                    return "Provided direction isn't in a valid format";
            }

            // Checking to see if provided x & y values are inside the grid.

            if (row >= 0 && row <= maxrow && col >= 0 && col <= maxcol)
            {
                x = row;
                y = col;
                Placed = true;
                return string.Format("Successfully placed robot at {0},{1} facing {2}", x, y, CurrentDirection);
            }
            else
            {
                return "Provided X & Y values aren't inside a 6x6 grid"; 
            }
        }

        public bool Move()
        {
            // Uses the current direction to determine if moves is out of bounds, otherwise robot is moved.
            switch (CurrentDirection)
            {
                case "NORTH":
                    if (y + 1 <= 5)
                    {
                        y = y + 1;
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
            switch (CurrentDirection)
            {
                case "NORTH":
                    CurrentDirection = "WEST";
                    break;

                case "EAST":
                    CurrentDirection = "NORTH";
                    break;

                case "SOUTH":
                    CurrentDirection = "EAST";
                    break;

                case "WEST":
                    CurrentDirection = "SOUTH";
                    break;
            }
        }

        public void TurnRight()
        {
            switch (CurrentDirection)
            {
                case "NORTH":
                    CurrentDirection = "EAST";
                    break;

                case "EAST":
                    CurrentDirection = "SOUTH";
                    break;

                case "SOUTH":
                    CurrentDirection = "WEST";
                    break;
                case "WEST":
                    CurrentDirection = "NORTH";
                    break;
            }
        }

        public string Report()
        {
            return string.Format("{0},{1},{2}", x, y, CurrentDirection);
        }

        public bool PlaceErrors(string[] input)
        {
            return GetPlaceErrors(input).Any();
        }

        public IEnumerable<string> GetPlaceErrors(string[] input)
        {
            int numbercheck;
            if (Placed)
            {
                if (!(input.Length == maxpara - 1))
                {
                    yield return "Incorrect format has been supplied.Format must be PLACE X,Y e.g. PLACE 2,3";
                }
                else if (!(int.TryParse(input[1], out numbercheck) && int.TryParse(input[2], out numbercheck)))
                {
                    yield return "X/Y parameters provided weren't valid numbers.Format must be PLACE X,Y,DIRECTION e.g. PLACE 2,3";
                }
            }
            else
            {
                if (!(input.Length == maxpara))
                {
                    yield return "Incorrect format has been supplied.Format must be PLACE X,Y,DIRECTION e.g. PLACE 2,3,NORTH";
                }
                else if (!(int.TryParse(input[1], out numbercheck) && int.TryParse(input[2], out numbercheck)))
                {
                        yield return "X/Y parameters provided weren't valid numbers.Format must be PLACE X,Y,DIRECTION e.g. PLACE 2,3,NORTH";
                }
            }
            yield break;
        }
    }
}
