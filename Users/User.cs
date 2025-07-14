using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Users
{
    static internal class User
    {
        static public string Nickname { get; set; } = "";
        static public UserTypeList UserType { get; set; }
        static public int LoginCount { get; set; }
    }
}
