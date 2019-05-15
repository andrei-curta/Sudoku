using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.ViewModels
{
    class StatisticsViewModel : Conductor<object>
    {
        private string _stats;

        public string Stats
        {
            get { return _stats; }
            set { _stats = value; }
        }

        public StatisticsViewModel(IWindowManager windowManager)
        {
            _stats = UsersListModel.GetStatistics();
        }
    }
}
