using Library.Components;
using Library.Views;
using MySql.Data.MySqlClient;
namespace Library
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Library app = new();
            app.RunApp();
        }
    }
}
