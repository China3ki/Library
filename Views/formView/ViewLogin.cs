using FormController;
using FormController.Components.Forms;
using Library.Components;
using Library.Interfaces;
using Library.Views.InfoView;
using Library.Views.SingleMenu;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Views.formView
{
    internal class ViewLogin : ViewForm, IView
    {
        public override void InitView()
        {
            _renderManager.AddMenuOptions(" == Logowanie == ", ConsoleColor.Cyan, ConsoleColor.Black);
            _notificationManager.AddNotification("Wpisz dane do logowania.", ConsoleColor.Yellow);
            _renderManager.InitMenu();
            _notificationManager.DisplayNotification();
            HandleForm();
            Console.Clear();
        }
        protected override void HandleForm()
        {
            InitForm();
            do
            {
                _form.RunForm();
                _action = _form.GetActionFromField();
                if (_action == FieldType.Cancel) return;
            } while (!HandleValidation());
            CompleteLogin();

        }
        private void CompleteLogin()
        {
            ViewLoginSuccesful loginSuccessful = new();
            loginSuccessful.InitInfo();
        }
        protected override void InitForm()
        {
            _form.AddField("Nazwa użytkownika:", FieldType.Text, 2, 1);
            _form.AddField("Hasło:", FieldType.Password, 2 ,2);
            _form.AddField("Pokaż hasło", FieldType.ShowPassword, 2, 3);
            _form.AddField("Zatwierdź", FieldType.Submit, 2, 4);
            _form.AddField("Wróć", FieldType.Cancel, 2, 5);
            _form.RenderForm();
        }
        protected override bool HandleValidation()
        {
            string nickname = _form.GetDataFromField(0);
            string password = _form.GetDataFromField(1);
            bool inputValidation = ValidationManager.CheckDataInInputExist(nickname, password);
            bool dataValidation = ValidationManager.CheckData(nickname, password);
            if (!inputValidation || !dataValidation)
            {
                _notificationManager.ClearNotification();
                if (!inputValidation)
                {
                    _notificationManager.AddNotification("Uzupełnij wszystkie dane!", ConsoleColor.Yellow);
                    return false;
                }
                if (!dataValidation)
                {
                    _notificationManager.AddNotification("Nazwa użytkownika lub hasło jest nieprawidłowe", ConsoleColor.Red);
                    _notificationManager.DisplayNotification();
                    return false;
                }
                return false;
            }
            else return true;
        }
        public ViewsList NextView()
        {
            switch(_action)
            {
                case FieldType.Submit:
                    throw new Exception("a");
                case FieldType.Cancel:
                    return ViewsList.Start;
                default:
                    ViewError error = new();
                    error.ErrorView();
                    error.ErrorView();
                    throw new Exception("View does not exist.");
            }
        }
    }
}
