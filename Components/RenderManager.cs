using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Components
{
    internal class RenderManager
    {
        public List<string> Menu = [];
        private List<ConsoleColor> _fontColorList = [];
        private List<ConsoleColor> _backgroundColorList = [];
        public void InitMenu()
        {
            RenderBorder();
            RenderMenu();
        }
        public void AddMenuOptions(string name, ConsoleColor fontColor, ConsoleColor backgroundColor)
        {
             Menu.Add(name);
            _fontColorList.Add(fontColor);
            _backgroundColorList.Add(backgroundColor);
        }
        /// <summary>
        /// Renders a border around the edges of the console window using box-drawing characters.
        /// </summary>
        /// <remarks>The border is drawn using Unicode box-drawing characters, including corners,
        /// horizontal lines,  and vertical lines. This method assumes the console window dimensions are accessible via 
        /// <see cref="Console.WindowWidth"/> and <see cref="Console.WindowHeight"/>.</remarks>
        public void RenderBorder()
        {
            int width = Console.WindowWidth - 1;
            int height = Console.WindowHeight - 1;
            string headerLogo = "| Library |";
            for (int x = 0; x < Console.WindowWidth; x++)
            {
                for (int y = 0; y < Console.WindowHeight; y++)
                {
                    Console.SetCursorPosition(x, y);
                    if (x == 0 && y == 0) Console.Write('╔');
                    else if (x == 0 && y == height) Console.Write('╚');
                    else if (x == width && y == 0) Console.Write('╗');
                    else if (x == width && y == height) Console.Write('╝');
                    else if ((x > 0 && x < width) && (y == 0 || y == height)) Console.Write('═');
                    else if ((x == 0 || x == width) && (y > 0 && y < height)) Console.Write('║');
                }
            }
            Console.SetCursorPosition(width / 2 - headerLogo.Length, 0);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write(headerLogo);
            Console.ResetColor();
        }
        private void RenderMenu()
        {
            for (int i = 0; i < Menu.Count; i++)
            {
                Console.SetCursorPosition(2, i);
                if (i == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.ForegroundColor = _fontColorList[i];
                    Console.BackgroundColor = _backgroundColorList[i];
                }
                Console.Write(Menu[i]);
                Console.ResetColor();
            }
        }
        public void ChangeColorOfMenu(int position, int prevPosition)
        {
            Console.SetCursorPosition(2, prevPosition);
            Console.ForegroundColor = _fontColorList[prevPosition];
            Console.BackgroundColor = _backgroundColorList[prevPosition];
            Console.Write(Menu[prevPosition]);
            Console.SetCursorPosition(2, position);
            Console.ForegroundColor = ConsoleColor.Green ;
            Console.BackgroundColor = _backgroundColorList[position];
            Console.Write(Menu[position]);
            Console.ResetColor();
        }
    }
}
