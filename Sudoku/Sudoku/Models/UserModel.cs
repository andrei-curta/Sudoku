using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class UserModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int StartedGames { get; set; }
        public int WonGames { get; set; }

        public UserModel(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public static bool operator == (UserModel u1, UserModel u2)
        {
            if (null == u1)
                return (null == u2);

            if (u1.Username == u2.Username && u1.Password == u2.Password)
                return true;
            return false;
        }

        public static bool operator !=(UserModel u1, UserModel u2)
        {
            return !(u1 == u2);
        }
    }
}
