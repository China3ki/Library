using Library.Interfaces;
using Library.Users;
using Library.Views.SingleMenu;
using Mysqlx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Views.UserView
{
    internal class ViewMainUser : View, IView
    {
        public override void InitView()
        {
            AddMenuOptions(" == Menu główne == ");
            AddMenuOptions("Zobacz książki");
            AddMenuOptions("Edytuj swoje dane!");
            AddMenuOptions("Wyloguj się");
            AddMenuOptions("Wyjdź");
            AddNotification($"Witaj {User.Nickname}!");
            AddNotification($"Zalogowałeś się już: {User.LoginCount}", ConsoleColor.Yellow);
            _notificationManager.DisplayNotification();
            base.InitView();
        }
        public ViewsList NextView()
        {
            switch(_positionManager.Position)
            {
                case 1:
                    return ViewsList.Categories;
                case 2:
                    return ViewsList.UserData;
                default:
                    ViewError error = new();
                    error.ErrorConnection();
                    throw new Exception("View does not exist.");
            }
        }
    }
}
