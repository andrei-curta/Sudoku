using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Models
{
    public static class UsersListModel
    {
        private static List<UserModel> Users;

        public static bool IsUserInDatabase(string username, string password)
        {
            return Users.Exists(user => user.Username == username && user.Password == password);
        }
    }
}
