using Caliburn.Micro;
using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Sudoku.ViewModels
{
    public class MenuViewModel : Conductor<object>
    {

        private UserModel _userData;
        private int _boardSize;

        public BitmapImage Picture { get; set; }

        public int BoardSize
        {
            get { return _boardSize; }
            set { _boardSize = value; }
        }

        IWindowManager windowManager;

        public MenuViewModel(IWindowManager windowManager)
        {
            _boardSize = 9;
            _userData = UsersListModel.CurrentUser;
            this.windowManager = windowManager;

            var path = Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()) +"\\..\\Data\\Users\\" + _userData.Username + "\\profilePic.png";
            if(!System.IO.File.Exists(path))
            {
                path = Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()) + "\\..\\Data\\" + "default.png";
            }

            Uri imagePath = new Uri(path, UriKind.Absolute);
            this.Picture = new BitmapImage(imagePath);
        }

        protected override void OnActivate()
        {
            
            base.OnActivate();
        }

        public UserModel UserData
        {
            get { return _userData; }
        }

        public void NewGame()
        {
            windowManager.ShowWindow(new SudokuBoardViewModel(windowManager, _boardSize));
        }
    }
}
