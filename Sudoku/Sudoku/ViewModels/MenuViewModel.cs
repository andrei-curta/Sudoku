using Caliburn.Micro;
using System.Windows;

namespace Sudoku.ViewModels
{
    public class MenuViewModel : Conductor<object>
    {

        private UserModel _userData;

        protected override void OnActivate()
        {
             _userData = UsersListModel.CurrentUser;
            base.OnActivate();
        }

        public UserModel UserData
        {
            get { return _userData; }
        }
    }
}
