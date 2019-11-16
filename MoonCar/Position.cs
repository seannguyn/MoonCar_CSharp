using System;
using System.Collections.Generic;


namespace MoonCar
{
    public class Position
    {
        private static int _xLimit;
        private static int _yLimit;

        public int currentX { get; set; }
        public int currentY { get; set; }
        public string orientation { get; set; }

        public string movement { get; set; }

        // check if the position is on the board
        public static bool CheckPosition(int x, int y)
        {
            return (x <= _xLimit && x >= 0 && y >= 0 && y <= _yLimit);
        }

        // Place the bot in a valid position
        // Using static factory method instead of a constructor for flexibility
        public Position (int xLimit, int yLimit, string movement)
        {
            
            this.currentX = 0;
            this.currentY = 0;
            this.orientation = Constant.NORTH;
            this.movement = movement;

            _xLimit = xLimit;
            _yLimit = yLimit;
        }

        public Position(int xPosition, int yPosition, string orientation, int xLimit, int yLimit, string movement)
        {
            _xLimit = xLimit;
            _yLimit = yLimit;

            if (CheckPosition(xPosition, yPosition))
            {
                this.currentX = xPosition;
                this.currentY = yPosition;
                this.orientation = orientation;
            } else
            {
                this.currentX = 0;
                this.currentY = 0;
                this.orientation = Constant.NORTH;
            }

            this.movement = movement;
        }

        public string execute()
        {
            char[] commands = this.movement.ToCharArray();
            foreach(char command in commands)
            {
                try
                {
                    this.GetType().GetMethod(command.ToString()).Invoke(this, new object[] { });
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Method "+ command + " does not exist");
                    throw ex;
                }
            }
            return report();
        }

        public void L()
        {
            switch (orientation)
            {
                case Constant.NORTH:
                    this.orientation = Constant.WEST;
                    break;
                case Constant.SOUTH:
                    this.orientation = Constant.EAST;
                    break;
                case Constant.EAST:
                    this.orientation = Constant.NORTH;
                    break;
                case Constant.WEST:
                    this.orientation = Constant.SOUTH;
                    break;
            }
        }

        public void R()
        {
            switch (orientation)
            {
                case Constant.NORTH:
                    this.orientation = Constant.EAST;
                    break;
                case Constant.SOUTH:
                    this.orientation = Constant.WEST;
                    break;
                case Constant.EAST:
                    this.orientation = Constant.SOUTH;
                    break;
                case Constant.WEST:
                    this.orientation = Constant.NORTH;
                    break;
            }
        }

        public void M()
        {
            int newY;
            int newX;
            switch (orientation)
            {
                case Constant.NORTH:
                    newX = currentX;
                    newY = currentY + 1;
                    if (CheckPosition(newX, newY))
                    {
                        currentX = newX;
                        currentY = newY;
                    }
                    break;
                case Constant.SOUTH:
                    newX = currentX;
                    newY = currentY - 1;
                    if (CheckPosition(newX, newY))
                    {
                        currentX = newX;
                        currentY = newY;
                    }
                    break;
                case Constant.EAST:
                    newX = currentX + 1;
                    newY = currentY;
                    if (CheckPosition(newX, newY))
                    {
                        currentX = newX;
                        currentY = newY;
                    }
                    break;
                case Constant.WEST:
                    newX = currentX - 1;
                    newY = currentY;
                    if (CheckPosition(newX, newY))
                    {
                        currentX = newX;
                        currentY = newY;
                    }
                    break;
            }
        }

        public string report()
        {
            string currentPosition = string.Format($"{currentX} {currentY} {orientation}");

            Console.WriteLine();
            Console.WriteLine(currentPosition);
            return currentPosition;
        }
    }
}
