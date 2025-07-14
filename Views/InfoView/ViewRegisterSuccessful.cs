using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Views.SingleMenu
{
    internal class ViewRegisterSuccessful : ViewInfo
    {
        public ViewRegisterSuccessful()
        {
            _header = [
                " __        ___ _                        _ ",
                " \\ \\      / (_) |_ __ _ _ __ ___  _   _| |",
                "  \\ \\ /\\ / /| | __/ _` | '_ ` _ \\| | | | |",
                "   \\ V  V / | | || (_| | | | | | | |_| |_|",
                "    \\_/\\_/  |_|\\__\\__,_|_| |_| |_|\\__, (_)",
                "                                  |___/   "
                ];
                
        }
        public override void InitInfo()
        {
            Console.Clear();
            RenderHeader();
            _notifcationManager.AddNotification("Konto zostało pomyślnie!", ConsoleColor.Green, ConsoleColor.Black);
            _notifcationManager.AddNotification("Zostaniesz przeniesiony do strony logowania!", ConsoleColor.Yellow, ConsoleColor.Black);
            _notifcationManager.DisplayNotification();
            _renderManager.RenderBorder();
            WaitForAction();
        }
    }
}
