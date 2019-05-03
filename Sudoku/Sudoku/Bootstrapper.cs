using Caliburn.Micro;
using Sudoku.ViewModels;
using System.Windows;

namespace Sudoku
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<LogInViewModel>();
        }
    }
}
