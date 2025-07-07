using Library.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class Library
    {
        private bool _run = false;
        private ViewsList _currentView = ViewsList.Intro;
        public void RunApp()
        {
            ViewManager viewManager = new();
            _run = true;
            do
            {
                _currentView = viewManager.ChangeView(_currentView);
            } while (_run);
        }
    }
}
