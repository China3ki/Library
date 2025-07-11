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
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            RenderHeader();
            Console.ResetColor();
            _notifcationManager.AddNotification("Nie można połączyć się z bazą danych!", ConsoleColor.Red, ConsoleColor.Black);
            _notifcationManager.AddNotification("Spróbuj ponownie póżniej.", ConsoleColor.Yellow, ConsoleColor.Black);
            _notifcationManager.DisplayNotification();
            _renderManager.RenderBorder();
            WaitForAction();
            Environment.Exit(0);
        }
    }
}
