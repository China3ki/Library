using Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Views
{
    internal class ViewStart(List<string> menu) : View(menu), IView
    {
        public ViewsList NextView()
        {
            
            return ViewsList.Login;
        }
    }
}
