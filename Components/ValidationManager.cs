using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Library.Views.SingleMenu;
using MySql.Data.MySqlClient;
namespace Library.Components
{
    internal class ValidationManager
    {    
        static private string _sqlConnectionString = "server=localhost;uid=root;database=library";
        static public bool CheckDataInInputExist(string nickname, string password, string passwordRepeat)
        {
            return nickname.Length != 0 && password.Length != 0 && passwordRepeat.Length != 0;
        }
        static public bool CheckDataInInputExist(string nickname, string password)
        {
            return nickname.Length != 0 && password.Length != 0;
        }
        static public bool CheckData(string nickname, string password)
        {
            try
            {
                using (MySqlConnection connection = new(_sqlConnectionString))
                {
                    connection.Open();
                    MySqlCommand command = new("Select COUNT(user_password) FROM users WHERE user_password = @password AND user_nickname = @nickname", connection);
                    command.Parameters.AddWithValue("nickname", nickname);
                    command.Parameters.AddWithValue("password", password);
                    int passwordDb = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return passwordDb != 0;
                }
            }
            catch(Exception message)
            {
                DisplayError();
                throw new Exception(message.Message);
            }
        }
        static public bool CheckNicknameExist(string nickname)
        {
            try
            {
                using(MySqlConnection connection = new(_sqlConnectionString))
                {
                    connection.Open();
                    MySqlCommand command = new("Select COUNT(user_nickname) FROM users WHERE user_nickname = @nickname", connection);
                    command.Parameters.AddWithValue("nickname", nickname);
                    int nicknameDb = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return nicknameDb == 0;
                }
            }
            catch(Exception message)
            {
                DisplayError();
                throw new Exception(message.Message);
            }
        }
        static public bool CheckPasswordIsEqual(string password, string passwordRepeat)
        {
            return password == passwordRepeat;
        }
        static public bool PasswordValidation(string password)
        {
            string specialCharacterPattern = @"[^\\p{L}\\p{N}\\s]";
            return password.Length > 8 && Regex.IsMatch(password, specialCharacterPattern) && Regex.IsMatch(password, @"\d");
        }
        static public void DisplayError()
        {
            ViewError error = new();
            error.InitInfo();
        }
    }
}
