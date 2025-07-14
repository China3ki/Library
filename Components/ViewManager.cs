using Library.Views;
using Library.Views.formView;
using Library.Views.SingleMenu;
using Library.Views.UserView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Components
{
    internal class ViewManager
    {
        public ViewsList ChangeView(ViewsList nextView)
        {
            switch(nextView)
            {
                case ViewsList.Intro:
                    ViewIntro intro = new();
                    intro.InitInfo();
                    return ViewsList.Start;
                case ViewsList.Start:
                    ViewStart start = new();
                    start.InitView();
                    return start.NextView();
                case ViewsList.Register:
                    ViewRegister register = new();
                    register.InitView();
                    return register.NextView();
                case ViewsList.Login:
                    ViewLogin login = new();
                    login.InitView();
                    return login.NextView();
                case ViewsList.MainMenuUser:
                    ViewMainUser viewMainUser = new();
                    viewMainUser.InitView();
                    return viewMainUser.NextView();
                default:
                    throw new NotImplementedException("a");
            }
        }
    }
}
