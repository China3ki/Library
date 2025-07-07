using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
namespace Library.Components
{
    internal class ValidationManager
    {    
        private string _sqlStringConnection = "Data Source=127.0.0.1;Initial Catalog=library;User id=root";
        public bool CheckThePassword(string nickname, string password)
        {
            try
            {
                using (SqlConnection connection = new(_sqlStringConnection))
                {
                    connection.Open();
                    SqlCommand command = new("Select COUNT(user_password) FROM users WHERE user_password = @password AND user_nickname = @nickname");
                    command.Parameters.AddWithValue("nickname", nickname);
                    command.Parameters.AddWithValue("password", password);
                    int passwordDb = (int)command.ExecuteScalar();
                    return passwordDb == 0;
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
                using(SqlConnection connection = new(_sqlStringConnection))
                {
                    connection.Open();
                    SqlCommand command = new("Select COUNT(user_nickname) FROM users WHERE user_nickname = @nickname");
                    command.Parameters.AddWithValue("nickname", nickname);
                    int nicknameDb =(int)command.ExecuteScalar();
                    return nicknameDb == 1;
                }
            }
            catch
            {
                throw new NotImplementedException("a");
            }
        }
        public bool CheckPasswordIsEqual(string password, string passwordRepeat)
        {
            return password == passwordRepeat;
        }
    }
}
