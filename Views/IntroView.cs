using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Views
{
    internal class IntroView
    {
        private List<string> _logo = [
            "  _     _ _                          ", 
            " | |   (_) |__  _ __ __ _ _ __ _   _ ",
            " | |   | | '_ \\| '__/ _` | '__| | | |",
            " | |___| | |_) | | | (_| | |  | |_| |",
            " |_____|_|_.__/|_|  \\__,_|_|   \\__, |",
            "                               |___/ "
        ];
        public void InitIntro()
        {
            RenderIntro();
            LoadingIntro();
            Thread.Sleep(2000);
        }
        private void RenderIntro()
        {
            for(int i = 0; i < _logo.Count; i++)
            {
                Console.SetCursorPosition(GetCenterOfWidth(_logo[i].Length), GetCenterOfHeight(i));
                Console.Write(_logo[i]);
            }
        }
        private void LoadingIntro()
        {
            int count = 0;
            for(int x = 0; x <= 27 ; x++)
            {
                for(int y = 0; y < 3; y++)
                {
                    Console.SetCursorPosition(GetCenterOfWidth(0) + x - 14, GetCenterOfHeight(8) - 1 + y);
                    if (x == 0 && y == 0) Console.Write('╔');
                    else if (x == 27 && y == 0) Console.Write('╗');
                    else if (x == 0 && y == 2) Console.Write('╚');
                    else if (x == 27 && y == 2) Console.Write('╝');
                    else if ((x == 0 || x == 27) && y == 1) Console.Write('║');
                    else if(y == 0 || y == 2) Console.Write('═');
                }
            }
            for(int i = 0; i <= 50; i += 2)
            {
                Console.SetCursorPosition(GetCenterOfWidth(0) + count - 13, GetCenterOfHeight(8));
                Console.Write("█");
                Console.SetCursorPosition(GetCenterOfWidth(4), GetCenterOfHeight(9));
                Console.Write($"{i * 2}%");
                Thread.Sleep(200);
                count++;
            }
        }
        private int GetCenterOfWidth(int lineLength)
        {
            return (Console.WindowWidth - lineLength) / 2;
        }
        private int GetCenterOfHeight(int lineIndex)
        {
            return Console.WindowHeight / 2 - _logo.Count / 2 + lineIndex ;
        }
    }
}
