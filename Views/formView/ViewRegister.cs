using FormController;
using Library.Components;
using Library.Interfaces;
using Library.Views.SingleMenu;
using MySql.Data.MySqlClient;

namespace Library.Views.formView
{
    internal class ViewRegister : View, IView
    {
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
        /// <summary>
        /// Handles the form initialization, user interaction, and validation process.
        /// </summary>
        /// <remarks>This method initializes the form, processes user input to determine the selected
        /// action,  and validates the form data. If the user selects the cancel action, the method exits early. The
        /// method continues to reinitialize and validate the form until the validation succeeds.</remarks>
        private void HandleForm()
        {
            InitForm();
            do
            {
                _form.RunForm();
                _action = _form.GetActionFromField();
                if (_action == FieldType.Cancel) return;
            } while (!HandleValidation());
        }
        /// <summary>
        /// Initializes the form by adding predefined fields for user input and actions.
        /// </summary>
        /// <remarks>This method configures the form with fields for entering a username, password, 
        /// confirming the password, toggling password visibility, and submitting or canceling the form. Each field is
        /// added with a specific type and position within the form layout.</remarks>
        private void InitForm()
        {
            _form.AddField("Nazwa użytkownika:",FieldType.Text, 2,1);
            _form.AddField("Hasło:", FieldType.Password, 2, 2);
            _form.AddField("Potwierdż hasło:", FieldType.Password, 2, 3);
            _form.AddField("Zobacz/ukryj hasła", FieldType.ShowPassword, 2, 4);
            _form.AddField("Zatwierdź", FieldType.Submit, 2, 5);
            _form.AddField("Anuluj", FieldType.Cancel, 2, 6);
            _form.RenderForm();
        }
        /// <summary>
        /// Validates user input for account creation, including nickname uniqueness, password requirements,  and
        /// completeness of input fields.
        /// </summary>
        /// <remarks>This method performs a series of validation checks on the provided user input. If any
        /// validation  fails, appropriate notifications are displayed to the user, and the method returns <see
        /// langword="false"/>.  If all validations pass, the user data is saved to the database, and the method returns
        /// <see langword="true"/>.</remarks>
        /// <returns><see langword="true"/> if all validation checks pass and the user data is successfully saved to the
        /// database;  otherwise, <see langword="false"/>.</returns>
        private bool HandleValidation()
        {
            string nickname = _form.GetDataFromField(0);
            string password = _form.GetDataFromField(1);
            string passwordRepeat = _form.GetDataFromField(2);
            bool nicknameExist = ValidationManager.CheckNicknameExist(nickname);
            bool arePasswordsEqual = ValidationManager.CheckPasswordIsEqual(password, passwordRepeat);
            bool passwordValidation = ValidationManager.PasswordValidation(password);
            bool inputValidation = ValidationManager.CheckDataInInputExist(nickname, password, passwordRepeat);
            if (!nicknameExist || !arePasswordsEqual || !passwordValidation || !inputValidation)
            {
                _notificationManager.ClearNotification();
                if (!inputValidation) AddNotification("Uzupełnij wszystkie dane!", ConsoleColor.Red);
                if (!nicknameExist) AddNotification("Konto o takiej nazwie użytkownika już istnieje!", ConsoleColor.Red);
                if (!arePasswordsEqual) AddNotification("Hasła nie są takie same!", ConsoleColor.Red);
                if (!passwordValidation) AddNotification("Hasło nie spełnia wymagań!", ConsoleColor.Red);
                _notificationManager.DisplayNotification();
                return false;
            }
            else
            {
                SaveDataInTheDatabase(nickname, password);
                return true;
            }
        }
        /// <summary>
        /// Saves a new user record in the database with the specified nickname and password.
        /// </summary>
        /// <remarks>This method inserts a new user with a default user type of 2 into the "users" table
        /// in the database. Ensure that the database connection string and table schema are correctly configured before
        /// calling this method.</remarks>
        /// <param name="nickname">The nickname of the user to be saved. Cannot be null or empty.</param>
        /// <param name="password">The password of the user to be saved. Cannot be null or empty.</param>
        /// <exception cref="Exception">Thrown if an error occurs while attempting to save the data to the database.</exception>
        private void SaveDataInTheDatabase(string nickname, string password)
        {
            try
            {
                using (MySqlConnection connection = new("server=localhost;uid=root;database=library"))
                {
                    connection.Open();
                    MySqlCommand command = new("INSERT INTO users (user_type, user_nickname, user_password) VALUES (2, @nickname, @password)", connection);
                    command.Parameters.AddWithValue("nickname", nickname);
                    command.Parameters.AddWithValue("password", password);
                    command.ExecuteNonQuery();
                }
            }
            catch(Exception message)
            {
                ViewError error = new();
                error.InitInfo();
                throw new Exception(message.Message);
            }
            finally
            {
                ViewRegisterSuccessful success = new();
                success.InitInfo();
            }
        }
        public ViewsList NextView()
        {
            switch(_action)
            {
                case FieldType.Submit:
                    return ViewsList.Login;
                case FieldType.Cancel:
                    return ViewsList.Start;
                default:
                    throw new NotImplementedException("A");
            }
        }
    }
}
