using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Sudoku
{
    [Serializable]
    [XmlRoot(ElementName = "User")]
    public class UserModel : ISerializable
    {
        [XmlElement("Username")]
        public string Username { get; set; }

        [XmlElement("Password")]
        public string Password { get; set; }

        [XmlElement("StartedGames")]
        public int StartedGames { get; set; }

        [XmlElement("WonGames")]
        public int WonGames { get; set; }

        public UserModel(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public UserModel()
        {

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

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Username", Username);
            info.AddValue("Password", Password);
            info.AddValue("Sterted Games", StartedGames);
            info.AddValue("Won Games", WonGames);
        }

        public UserModel(SerializationInfo info, StreamingContext context)
        {
            Username = (string)info.GetValue("Username", typeof(string));
            Password = (string)info.GetValue("Password", typeof(string));
            StartedGames = (int)info.GetValue("Started Games", typeof(int));
            WonGames = (int)info.GetValue("Username", typeof(int));

        }
    }
}
