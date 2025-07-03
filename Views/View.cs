using Library.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Views
{
    internal class View(List<string> menu)
    {
        private NotificationManager _notificationManager = new();
        private List<string> _menu = menu;
        public virtual void InitView()
        {
            RenderBorder();
        }
        /// <summary>
        /// Adds a notification with specified text and display colors.
        /// </summary>
        /// <remarks>This method stores the notification along with its associated font and background
        /// colors. The colors are intended for display purposes and should be chosen to ensure readability.</remarks>
        /// <param name="notification">The text of the notification to be added. Cannot be null or empty.</param>
        /// <param name="fontColor">The color of the text for the notification. Must be a valid <see cref="ConsoleColor"/> value.</param>
        /// <param name="backgroundColor">The background color for the notification. Must be a valid <see cref="ConsoleColor"/> value.</param>
        public void AddNotification(string notification, ConsoleColor fontColor, ConsoleColor backgroundColor)
        {
            _notificationManager.AddNotification(notification, fontColor, backgroundColor);
        }
        /// <summary>
        /// Adds a notification message with the specified font color to the notification list.
        /// </summary>
        /// <remarks>The notification is added with a default background color of <see
        /// cref="ConsoleColor.Black"/>.</remarks>
        /// <param name="notification">The notification message to add. Cannot be null or empty.</param>
        /// <param name="fontColor">The font color to use for displaying the notification.</param>
        public void AddNotification(string notification, ConsoleColor fontColor)
        {
            _notificationManager.AddNotification(notification, fontColor, ConsoleColor.Black);
        }
        /// <summary>
        /// Adds a notification to the collection with default font and background colors.
        /// </summary>
        /// <remarks>The notification is added with a default font color of <see
        /// cref="ConsoleColor.White"/>  and a default background color of <see cref="ConsoleColor.Black"/>.</remarks>
        /// <param name="notification">The notification message to add. Cannot be null or empty.</param>
        public void AddNotification(string notification)
        {
            _notificationManager.AddNotification(notification, ConsoleColor.White, ConsoleColor.Black);
        }
        protected virtual void RenderView()
        {
            for(int i = 0; i < _menu.Count; i++)
            {
                Console.SetCursorPosition(1, i);
                Console.Write(_menu[i]);
            }
        }
        /// <summary>
        /// Renders a border around the edges of the console window using box-drawing characters.
        /// </summary>
        /// <remarks>The border is drawn using Unicode box-drawing characters, including corners,
        /// horizontal lines,  and vertical lines. This method assumes the console window dimensions are accessible via 
        /// <see cref="Console.WindowWidth"/> and <see cref="Console.WindowHeight"/>.</remarks>
        protected void RenderBorder()
        {
            int width = Console.WindowWidth - 1;
            int height = Console.WindowHeight - 1;
            for(int x = 0; x < Console.WindowWidth; x++)
            {
                for(int y = 0; y < Console.WindowHeight; y++)
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
        }
    }
}
