using Caliburn.Micro;
using System.Windows;

namespace Sudoku.ViewModels
{
    public class MenuViewModel : Conductor<object>
    {

        private UserModel _userData;
        IWindowManager windowManager;


        public MenuViewModel(IWindowManager windowManager)
        {
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
            windowManager.ShowWindow(new SudokuBoardViewModel(windowManager, 5));
        }
    }
}
