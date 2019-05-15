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
        private int _boardSize = 9;

        public BitmapImage Picture { get; set; }

        public int BoardSize
        {
            get { return _boardSize; }
            set { _boardSize = value; }
        }

        IWindowManager windowManager;

        public MenuViewModel(IWindowManager windowManager)
        {
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

        public void LoadGame()
        {
            var path = Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()) + "\\..\\Data\\Users\\" + _userData.Username + "\\savedGame.txt";
            if (!System.IO.File.Exists(path))
            {
                MessageBox.Show("No saved games!");
                return;
            }
            windowManager.ShowWindow(new SudokuBoardViewModel(windowManager));
        }
        public void ShowStats()
        {
            windowManager.ShowWindow(new StatisticsViewModel(windowManager));
        }
    }
}
