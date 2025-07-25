﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Components
{
    internal class NotificationManager
    {
        private List<string> _notifications = [];
        private List<ConsoleColor> _notificationsFontColor = [];
        private List<ConsoleColor> _notificationsBackgroundColor = [];
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
            _notifications.Add(notification);
            _notificationsFontColor.Add(fontColor);
            _notificationsBackgroundColor.Add(backgroundColor);
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
            _notifications.Add(notification);
            _notificationsFontColor.Add(fontColor);
            _notificationsBackgroundColor.Add(ConsoleColor.Black);
        }
        /// <summary>
        /// Adds a notification to the collection with default font and background colors.
        /// </summary>
        /// <remarks>The notification is added with a default font color of <see
        /// cref="ConsoleColor.White"/>  and a default background color of <see cref="ConsoleColor.Black"/>.</remarks>
        /// <param name="notification">The notification message to add. Cannot be null or empty.</param>
        public void AddNotification(string notification)
        {
            _notifications.Add(notification);
            _notificationsFontColor.Add(ConsoleColor.White);
            _notificationsBackgroundColor.Add(ConsoleColor.Black);
        }
        /// <summary>
        /// Clears all notifications from the console display and removes them from the internal notification list.
        /// </summary>
        /// <remarks>This method erases the notification area at the bottom of the console window and
        /// resets the internal collection of notifications. The cleared area includes a border on the left and right
        /// edges.</remarks>
        public void ClearNotification()
        {
            for (int x = 0; x < Console.WindowWidth; x++)
            {
                for (int y = 0; y < _notifications.Count + 1; y++)
                {
                    Console.SetCursorPosition(x, Console.WindowHeight - 2 - _notifications.Count + y);
                    if (x == 0 || x == Console.WindowWidth - 1) Console.Write('║');
                    else Console.Write(' ');
                }
            }
            _notifications.Clear();
        }
        /// <summary>
        /// Displays all notifications in the console with their respective foreground and background colors.
        /// </summary>
        /// <remarks>This method renders notifications at the bottom of the console window, with each
        /// notification styled  according to its associated font and background colors. After displaying the
        /// notifications, a frame  is rendered around them for visual emphasis.</remarks>
        /// <exception cref="InvalidOperationException">Thrown if the notifications list is empty.</exception>
        public void DisplayNotification()
        {
            if (_notifications.Count == 0) throw new InvalidOperationException("Notifications list cannot be empty!");
            for(int i = 0; i < _notifications.Count; i++)
            {
                Console.ForegroundColor = _notificationsFontColor[i];
                Console.BackgroundColor = _notificationsBackgroundColor[i];
                Console.SetCursorPosition(2, Console.WindowHeight - 1 - _notifications.Count + i);
                Console.Write(_notifications[i]);
                Console.ResetColor();
            }
            RenderNotificationFrame();
        }
        /// <summary>
        /// Renders a notification frame at the bottom of the console window.
        /// </summary>
        /// <remarks>The frame is drawn as a horizontal line with special characters at the edges. It is
        /// positioned two rows above the bottom of the console window, adjusted by the number of
        /// notifications.</remarks>
        private void RenderNotificationFrame()
        {
            for(int x = 0; x < Console.WindowWidth; x++)
            {
                Console.SetCursorPosition(x, Console.WindowHeight - 2 - _notifications.Count);
                if (x == 0) Console.Write('╠');
                else if (x == Console.WindowWidth - 1) Console.Write('╣');
                else Console.Write('═');
            }
        }
    }
}
