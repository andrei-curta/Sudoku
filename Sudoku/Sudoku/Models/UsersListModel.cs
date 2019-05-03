using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Sudoku.ViewModels
{
    [Serializable]
    public static class UsersListModel
    {
        [XmlArray("UserList")]
        [XmlArrayItem("User")]
        private static List<UserModel> Users;
        private static string SavePath = @"E:\Facultate\Anul_II\Sem_II\MVP\2.Teme\3.Sudoku\Sudoku\Sudoku\Sudoku\Data\UsersList.xml";
        private static UserModel _currentUser;

        public static UserModel CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }

        static UsersListModel()
        {
            Deserialize();
        }

        public static bool IsUsernameInDatabase(string username)
        {
            return Users.Exists(user => user.Username == username);
        }

        public static bool IsUserInDatabase(string username, string password)
        {
            return Users.Exists(user => user.Username == username && user.Password == password);
        }

        public static void Add(string username, string password)
        {
            Users.Add(new UserModel(username, password));
        }

        public static void Add(UserModel user)
        {
            Users.Add(user);
        }

        public static void Save()
        {
            Add(CurrentUser);
            Serialize();
        }

        public static void Deserialize()
        {
             var serializer = new XmlSerializer(typeof(List<UserModel>));

            StreamReader reader = new StreamReader(SavePath);
            Users = (List<UserModel>)serializer.Deserialize(reader);
            reader.Close();
        }

        private static void Serialize() 
        {
            var serializer = new XmlSerializer(typeof(List<UserModel>));
            StringBuilder stringBuilder = new StringBuilder();
            StringWriter stringWriter = new StringWriter(stringBuilder);
            serializer.Serialize(stringWriter, Users);
            string xmlResult = stringWriter.GetStringBuilder().ToString();

            System.IO.File.WriteAllText(SavePath, xmlResult);
        }

        public static void SetCurrentUser(string username)
        {
            foreach(UserModel user in Users)
            {
                if(user.Username == username)
                {
                    CurrentUser = user;
                    return;
                }
            }
        }
    }
}
