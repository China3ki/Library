using Library.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Views
{
    internal class View()
    {
        protected PositionManager _positionManager = new();
        protected NotificationManager _notificationManager = new();
        protected RenderManager _renderManager = new();
        public virtual void InitView()
        {
            if (_renderManager.Menu.Count == 0) throw new InvalidOperationException("Menu list cannot be empty!");
            _positionManager.MaxPosition = _renderManager.Menu.Count;
            _renderManager.InitMenu();
            HandleMenuNavigation();
            Console.Clear();
        }
        public void AddMenuOptions(string name, ConsoleColor fontColor, ConsoleColor backgroundColor)
        {
            _renderManager.AddMenuOptions(name, fontColor, backgroundColor);
        }
        public void AddMenuOptions(string name, ConsoleColor fontColor)
        {
            _renderManager.AddMenuOptions(name, fontColor, ConsoleColor.Black);
        }
        public void AddMenuOptions(string name)
        {
            _renderManager.AddMenuOptions(name, ConsoleColor.White, ConsoleColor.Black);
        }
        /// <summary>
        /// Adds a notification with specified text and display colors.
        /// </summary>
        /// <remarks>This method stores the notification along with its associated font and background
        /// colors. The colors are intended for display purposes and should be chosen to ensure readability.</remarks>
        /// <param name="notification">The text of the notification to be added. Cannot be null or empty.</param>
        /// <param name="fontColor">The color of the text for the notification. Must be a valid <see cref="ConsoleColor"/> value.</param>
        /// <param name="backgroundColor">The background color for the notification. Must be a valid <see cref="ConsoleColor"/> value.</param>
        protected void AddNotification(string notification, ConsoleColor fontColor, ConsoleColor backgroundColor)
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
        protected void AddNotification(string notification, ConsoleColor fontColor)
        {
            _notificationManager.AddNotification(notification, fontColor, ConsoleColor.Black);
        }
        /// <summary>
        /// Adds a notification to the collection with default font and background colors.
        /// </summary>
        /// <remarks>The notification is added with a default font color of <see
        /// cref="ConsoleColor.White"/>  and a default background color of <see cref="ConsoleColor.Black"/>.</remarks>
        /// <param name="notification">The notification message to add. Cannot be null or empty.</param>
        protected void AddNotification(string notification)
        {
            _notificationManager.AddNotification(notification, ConsoleColor.White, ConsoleColor.Black);
        }
        protected int HandleMenuNavigation()
        {
            ConsoleKey key;
            int position;
            do
            {
                key = _positionManager.ChangePosition();
                position = _positionManager.Position;
                if (key == ConsoleKey.UpArrow)
                {
                    _renderManager.ChangeColorOfMenu(position, position + 1);
                }
                else if (key == ConsoleKey.DownArrow)
                {
                     _renderManager.ChangeColorOfMenu(position, position - 1);
                }
            } while (key != ConsoleKey.Enter);
            return position;
        } 
    }
}
