using Library.Components;
using Library.Views;

namespace Library
{
    internal class Program
    {
        static void Main(string[] args)
        {
            View a = new(["a"]);
            a.InitView();
            NotificationManager manager = new();
            //manager.AddNotification("aaa");
            //manager.AddNotification("Bb");
            //manager.AddNotification("cc", ConsoleColor.Blue, ConsoleColor.Yellow);
            manager.DisplayNotification();
            Thread.Sleep(2000);
        }
    }
}
