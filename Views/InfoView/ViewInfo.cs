using Library.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Views.SingleMenu
{
    abstract internal class ViewInfo
    {
        protected List<string> _header = [];
        protected RenderManager _renderManager = new();
        protected NotificationManager _notifcationManager = new();
        abstract public void InitInfo();
        /// <summary>
        /// Renders the introductory logo to the console.
        /// </summary>
        /// <remarks>This method positions each line of the logo at the center of the console window. It
        /// assumes that the logo is stored as a collection of strings, where each string represents a line of the
        /// logo.</remarks>
        protected void RenderHeader()
        {
            for(int i = 0; i < _header.Count; i++)
            {
                Console.SetCursorPosition(GetCenterOfWidth(_header[i].Length), GetCenterOfHeight(i));
                Console.Write(_header[i]);
            }
        }
        /// <summary>
        /// Displays a loading animation in the console, including a progress bar and percentage indicator.
        /// </summary>
        /// <remarks>This method creates a visual loading sequence by drawing a progress bar and updating
        /// the percentage displayed in the console. The animation is rendered using console cursor positioning and
        /// includes decorative borders around the progress bar.</remarks>
        protected void Loading()
        {
            int count = 0;
            for(int x = 0; x <= 27 ; x++)
            {
                for(int y = 0; y < 3; y++)
                {
                    Console.SetCursorPosition(GetCenterOfWidth(0) + x - 14, GetCenterOfHeight(8) - 1 + y);
                    if (x == 0 && y == 0) Console.Write('╔');
                    else if (x == 27 && y == 0) Console.Write('╗');
                    else if (x == 0 && y == 2) Console.Write('╚');
                    else if (x == 27 && y == 2) Console.Write('╝');
                    else if ((x == 0 || x == 27) && y == 1) Console.Write('║');
                    else if(y == 0 || y == 2) Console.Write('═');
                }
            }
            for(int i = 0; i <= 50; i += 2)
            {
                Console.SetCursorPosition(GetCenterOfWidth(0) + count - 13, GetCenterOfHeight(8));
                Console.Write("█");
                Console.SetCursorPosition(GetCenterOfWidth(4), GetCenterOfHeight(9));
                Console.Write($"{i * 2}%");
                Thread.Sleep(75);
                count++;
            }
        }
        protected void WaitForAction()
        {
            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;
            } while (key != ConsoleKey.Enter);
        }
        /// <summary>
        /// Calculates the horizontal position needed to center a line of text within the console window.
        /// </summary>
        /// <param name="lineLength">The length of the text line to be centered, in characters. Must be less than or equal to the console window
        /// width.</param>
        /// <returns>The zero-based column index at which the text line should start to be horizontally centered.</returns>
        private int GetCenterOfWidth(int lineLength)
        {
            return (Console.WindowWidth - lineLength) / 2;
        }
        /// <summary>
        /// Calculates the vertical position of a line within the center of the console window height.
        /// </summary>
        /// <param name="lineIndex">The index of the line within the logo, where 0 represents the first line.</param>
        /// <returns>The vertical position of the specified line, relative to the center of the console window height.</returns>
        protected int GetCenterOfHeight(int lineIndex)
        {
            return Console.WindowHeight / 2 - _header.Count / 2 + lineIndex ;
        }
    }
}
