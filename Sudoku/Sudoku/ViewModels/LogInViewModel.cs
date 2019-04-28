using Caliburn.Micro;
using Sudoku.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sudoku.ViewModels
{
    class LogInViewModel : Screen
    {
        private string _username;
        private string _password;

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public bool IsLogInCorrect()
        {
            MessageBox.Show("user founf=d in db");
            return UsersListModel.IsUserInDatabase(Username, Password);
        }
    }
}
