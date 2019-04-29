﻿using Caliburn.Micro;
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
        private String _username;
        private String _password;

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

        public void LogInOrRegister()
        {

            //test wether username field is empty
            if (Username == null)
            {
                MessageBox.Show("Username field can not be empty!");
                return;
            }

            //test wether Password field is empty
            if (Password == null)
            {
                MessageBox.Show("Password field can not be empty!");
                return;
            }

            //make sure there are no spaces in the input fields
            Username = Username.Trim();
            Password.Trim();

            if (UsersListModel.IsUserInDatabase(Username, Password))
            {
                MessageBox.Show("Log In success");
                return;
            }
            if(UsersListModel.IsUsernameInDatabase(Username))
            {
                MessageBox.Show("Username in db");
                return;
            }

            //if the username does not mathch an existing user, 
            //creates a dialog that asks if the user wants to create an account
            MessageBoxResult result = MessageBox.Show("Username not found. Do you want to create an account?", "Exit", MessageBoxButton.YesNo);

            if(result == MessageBoxResult.Yes)
            {
                //Create a new account
                UsersListModel.CurrentUser = new UserModel(Username, Password);
                UsersListModel.Save();

                //Todo: add code to enter the applications

                return;
            }

            return;
        }


    }
}
