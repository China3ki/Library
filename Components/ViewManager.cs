using Library.Views;
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
                    intro.InitIntro();
                    return ViewsList.Start;
                case ViewsList.Start:
                    ViewStart start = new();
                    start.InitView();
                    return start.NextView();
                case ViewsList.Login:
                    ViewLogin login = new();
                    login.InitView();
                    return login.NextView();
                case ViewsList.Register:
                    ViewRegister register = new();
                    register.InitView();
                    return register.NextView();
                default:
                    throw new NotImplementedException("a");
            }
        }
    }
}
