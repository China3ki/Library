using FormController;
using FormController.Components.Forms;
using Library.Components;
using Library.Interfaces;
using Library.Users;
using Library.Views.InfoView;
using Library.Views.SingleMenu;
using MySql.Data.MySqlClient;
using Mysqlx;
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
        /// <summary>
        /// Completes the login process by validating the user's credentials and initializing the user's session.
        /// </summary>
        /// <remarks>This method retrieves the user's nickname and password from the form, validates them
        /// against the database,  and sets the user's type (e.g., User or Admin) based on the retrieved data. If the
        /// login is successful,  it initializes the login success view. If an error occurs during the process, an error
        /// view is displayed,  and the exception is rethrown.</remarks>
        /// <exception cref="Exception">Thrown if an error occurs during the database operation or if the login process fails.</exception>
        private void CompleteLogin()
        {
            string nickname = _form.GetDataFromField(0);
            string password = _form.GetDataFromField(1);
            IncrementLoginCount();
            try
            {
                using(MySqlConnection connection = new(_sqlConnectionString))
                {
                    connection.Open();
                    MySqlCommand command = new("SELECT user_nickname, type, user_login_count FROM users INNER JOIN userType ON user_type = type_id WHERE user_nickname = @nickname AND user_password = @password", connection);
                    command.Parameters.AddWithValue("nickname", nickname);
                    command.Parameters.AddWithValue("password", password);
                    MySqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        User.Nickname = data.GetString("user_nickname");
                        User.LoginCount = data.GetInt32("user_login_count");
                        if (data.GetString("type") == "User") User.UserType = UserTypeList.User;
                        else User.UserType = UserTypeList.Admin;
                    }
                    connection.Close();
                }
            } catch(Exception message)
            {
                Debug.WriteLine(message);
                ViewError error = new();
                error.ErrorConnection();
            }
            ViewLoginSuccesful loginSuccessful = new();
            loginSuccessful.InitInfo();
        }
        /// <summary>
        /// Increments the login count for the user identified by their nickname.
        /// </summary>
        /// <remarks>This method retrieves the user's nickname from the form data and updates the login
        /// count in the database. If an error occurs during the database operation, an exception is thrown with the
        /// error details.</remarks>
        /// <exception cref="Exception">Thrown if an error occurs while updating the login count in the database.</exception>
        private void IncrementLoginCount()
        {
            string nickname = _form.GetDataFromField(0);
            try
            {
                using (MySqlConnection connection = new(_sqlConnectionString))
                {
                    connection.Open();
                    MySqlCommand command = new("UPDATE users SET user_login_count = user_login_count + 1 WHERE user_nickname = @nickname", connection);
                    command.Parameters.AddWithValue("nickname", nickname);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            } catch
            {
                ViewError error = new();
                error.ErrorConnection();
            }
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
            else return true;
        }
        public ViewsList NextView()
        {
            switch(_action)
            {
                case FieldType.Submit:
                    return ViewsList.MainMenuUser;
                case FieldType.Cancel:
                    return ViewsList.Start;
                default:
                    ViewError error = new();
                    error.ErrorView();
                    throw new Exception("View does not exist.");
            }
        }
    }
}
