using Library.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Views.SingleMenu
{
    internal class ViewError : ViewInfo
    {
        public ViewError()
        {
            _header =
                [
                "  _____                     ",
                " | ____|_ __ _ __ ___  _ __ ",
                " |  _| | '__| '__/ _ \\| '__|",
                " | |___| |  | | | (_) | |   ",
                " |_____|_|  |_|  \\___/|_|   ",
                "                            "
                ];
        }
        public override void InitInfo()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            RenderHeader();
            Console.ResetColor();
            _renderManager.RenderBorder();
            WaitForAction();
            Environment.Exit(0);
        }
        public void ErrorConnection()
        {
            Console.Clear();
            _notifcationManager.AddNotification("Nie można połączyć się z bazą danych!", ConsoleColor.Red, ConsoleColor.Black);
            _notifcationManager.AddNotification("Spróbuj ponownie póżniej.", ConsoleColor.Yellow, ConsoleColor.Black);
            _notifcationManager.AddNotification("Kliknij ENTER aby wyjść z aplikacji.", ConsoleColor.Yellow);
            _notifcationManager.DisplayNotification();
        }
        public void ErrorView()
        {
            Console.Clear();
            _notifcationManager.AddNotification("Podany widok nie istnieje!", ConsoleColor.Red, ConsoleColor.Black);
            _notifcationManager.AddNotification("Spróbuj ponownie póżniej.", ConsoleColor.Yellow, ConsoleColor.Black);
            _notifcationManager.AddNotification("Kliknij ENTER aby wyjść z aplikacji.", ConsoleColor.Yellow);
            _notifcationManager.DisplayNotification();
        }
    }
}
