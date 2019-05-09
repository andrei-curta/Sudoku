using Caliburn.Micro;
using System.Windows;

namespace Sudoku.ViewModels
{
    public class MenuViewModel : Conductor<object>
    {

        private UserModel _userData;
        private int _boardSize;

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
