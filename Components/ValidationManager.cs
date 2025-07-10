using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace Library.Components
{
    internal class ValidationManager
    {    
        private string _sqlStringConnection = "server=localhost;uid=root;database=library";
        public bool CheckDataInInputExist(string nickname, string password, string passwordRepeat)
        {
            return nickname.Length != 0 && password.Length != 0 && passwordRepeat.Length != 0;
        }
        public bool CheckThePassword(string nickname, string password)
        {
            try
            {
                using (MySqlConnection connection = new(_sqlStringConnection))
                {
                    connection.Open();
                    MySqlCommand command = new("Select COUNT(user_password) FROM users WHERE user_password = @password AND user_nickname = @nickname", connection);
                    command.Parameters.AddWithValue("nickname", nickname);
                    command.Parameters.AddWithValue("password", password);
                    int passwordDb = (int)command.ExecuteScalar();
                    return passwordDb != 0;
                }
            }
            catch
            {
                throw new NotImplementedException("a");
            }
        }
        public bool CheckNicknameExist(string nickname)
        {
            try
            {
                using(MySqlConnection connection = new(_sqlStringConnection))
                {
                    connection.Open();
                    MySqlCommand command = new("Select COUNT(user_nickname) FROM users WHERE user_nickname = @nickname", connection);
                    command.Parameters.AddWithValue("nickname", nickname);
                    int nicknameDb = Convert.ToInt32(command.ExecuteScalar());
                    return nicknameDb == 0;
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public bool CheckPasswordIsEqual(string password, string passwordRepeat)
        {
            return password == passwordRepeat;
        }
        public bool PasswordValidation(string password)
        {
            string specialCharacterPattern = @"[^\\p{L}\\p{N}\\s]";
            return password.Length > 8 && Regex.IsMatch(password, specialCharacterPattern) && Regex.IsMatch(password, @"\d");
        }
    }
}
