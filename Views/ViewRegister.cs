using FormController;
using Library.Components;
using Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Views
{
    internal class ViewRegister : View, IView
    {
        private ValidationManager _validationManager = new();
        private Form _form = new();
        private FieldType _action;
        public override void InitView()
        {
            AddMenuOptions(" == Rejestracja == ", ConsoleColor.Cyan);
            AddNotification("Uzupełnij pola aby się zarejestrować.");
            AddNotification("- Hasło musi mieć co najmniej 8 znaków, znak specjalny oraz liczbę.", ConsoleColor.Yellow);
            _renderManager.InitMenu();
            _notificationManager.DisplayNotification();
            HandleForm();
            Console.Clear();
        }
        private void HandleForm()
        {
            InitForm();
            do
            {
                _form.InitForm();         
                _action = _form.GetActionFromField();
                if (_action == FieldType.Cancel) return;
            } while (!HandleValidation());
        }
        private void InitForm()
        {
            _form.AddField("Nazwa użytkownika:",FieldType.Text, 2,1);
            _form.AddField("Hasło:", FieldType.Password, 2, 2);
            _form.AddField("Potwierdż hasło:", FieldType.Password, 2, 3);
            _form.AddField("Zobacz/ukryj hasła", FieldType.ShowPassword, 2, 4);
            _form.AddField("Zatwierdź", FieldType.Submit, 2, 5);
            _form.AddField("Anuluj", FieldType.Cancel, 2, 6);
        }
        private bool HandleValidation()
        {
            string nickname = _form.GetDataFromField(0);
            string password = _form.GetDataFromField(1);
            string passwordRepeat = _form.GetDataFromField(2);
            bool nicknameExist = _validationManager.CheckNicknameExist(nickname);
            bool arePasswordsEqual = _validationManager.CheckPasswordIsEqual(password, passwordRepeat);
            bool passwordValidation = _validationManager.PasswordValidation(password);
            bool inputValidation = _validationManager.CheckDataInInputExist(nickname, password, passwordRepeat);
            if (!nicknameExist || !arePasswordsEqual || !passwordValidation || !inputValidation)
            {
                _notificationManager.ClearNotification();
                if (!inputValidation) AddNotification("Uzupełnij wszystkie dane!", ConsoleColor.Red);
                if (!nicknameExist) AddNotification("Konto o takiej nazwie użytkownika już istnieje!", ConsoleColor.Red);
                if (!arePasswordsEqual) AddNotification("Hasła nie są takie same!", ConsoleColor.Red);
                if (!passwordValidation) AddNotification("Hasło nie spełnia wymagań!", ConsoleColor.Red);
                _notificationManager.DisplayNotification();
                Debug.WriteLine("G");
                return false;
            }
            else return true;
        }
        public ViewsList NextView()
        {
            switch(_action)
            {
                case FieldType.Submit:
                    throw new NotImplementedException("A");
                case FieldType.Cancel:
                    return ViewsList.Start;
                default:
                    throw new NotImplementedException("A");
            }
        }
    }
}
