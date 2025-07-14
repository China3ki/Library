using Library.Views.SingleMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Views.InfoView
{
    internal class ViewLoginSuccesful : ViewInfo
    {
        public ViewLoginSuccesful()
        {
            _header =
                [
                " __        ___ _                          ____                                 _      ",
                " \\ \\      / (_) |_ __ _ _ __ ___  _   _  |  _ \\ ___  _ __   _____      ___ __ (_) ___ ",
                "  \\ \\ /\\ / /| | __/ _` | '_ ` _ \\| | | | | |_) / _ \\| '_ \\ / _ \\ \\ /\\ / / '_ \\| |/ _ \\",
                "   \\ V  V / | | || (_| | | | | | | |_| | |  __/ (_) | | | | (_) \\ V  V /| | | | |  __/",
                "    \\_/\\_/  |_|\\__\\__,_|_| |_| |_|\\__, | |_|   \\___/|_| |_|\\___/ \\_/\\_/ |_| |_|_|\\___|",
                "                                  |___/                                               "
                ];
        }
        public override void InitInfo()
        {
            Console.Clear();
            _renderManager.RenderBorder();
            _notifcationManager.AddNotification("Witaj ponownie!", ConsoleColor.White);
            _notifcationManager.AddNotification("Kliknij ENTER aby przejść dalej.", ConsoleColor.Yellow);
            _notifcationManager.DisplayNotification();
            RenderHeader();
            WaitForAction();
        }
    }
}
