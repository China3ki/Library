using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Components
{
    internal class PositionManager
    {
        public int Position = 1;
        public int MaxPosition;
        public ConsoleKey ChangePosition()
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            switch(key)
            {
                case ConsoleKey.UpArrow:
                    Position = Position == 1 ? 1 : Position -= 1;
                    break;
                case ConsoleKey.DownArrow:
                    Position = Position == MaxPosition - 1 ? MaxPosition - 1 : Position += 1;
                    break;
            }
            return key;
        }
    }
}
