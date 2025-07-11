using FormController;
using FormController.Components.Forms;
using Library.Interfaces;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Views.formView
{
    internal class ViewLogin : View, IView
    {
        private Form _form = new();

        public override void InitView()
        {
            _renderManager.InitMenu();
            AddMenuOptions(" == Logowanie == ", ConsoleColor.Cyan);
            AddNotification("Wpisz dane do logowania.", ConsoleColor.Yellow);
            _notificationManager.DisplayNotification();            
        }
        private void HandleForm()
        {
            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;
            } while (key != ConsoleKey.Enter);
        }
        private void InitForm()
        {
            _form.AddField("Nazwa użytkownika:", FieldType.Text, 2, 1);
            _form.AddField("Hasło:", FieldType.Password);
            _form.AddField("Pokaż hasło", FieldType.ShowPassword);
            _form.AddField("Zatwierdź", FieldType.Submit);
            _form.AddField("Wróć", FieldType.Cancel);
        }
        public ViewsList NextView()
        {
            return ViewsList.Exit;
        }
    }
}
