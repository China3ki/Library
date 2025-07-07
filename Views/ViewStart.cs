using Library.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Views
{
    internal class ViewStart : View, IView
    {
        public override void InitView()
        {
            AddMenuOptions(" == Start == ", ConsoleColor.Cyan);
            AddMenuOptions("Logowanie");
            AddMenuOptions("Rejestracja");
            AddMenuOptions("Zobacz dostępne pozycje", ConsoleColor.Yellow);
            AddMenuOptions("Wyjdź", ConsoleColor.Red);
            AddNotification("Witaj w bibliotece!");
            AddNotification("Wybierz jedną z opcji aby kontynuować!", ConsoleColor.Yellow);
            _notificationManager.DisplayNotification();
            base.InitView();
        }
        public ViewsList NextView()
        {   
            switch(_positionManager.Position)
            {
                case 1:
                    return ViewsList.Login;
                case 2:
                    return ViewsList.Register;
                case 3:
                    return ViewsList.Intro;
                case 4:
                    return ViewsList.Exit;
                default:
                    throw new NotImplementedException("That menu does not exist!");
            }
        }
    }
}
