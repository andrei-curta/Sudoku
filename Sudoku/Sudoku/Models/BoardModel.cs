using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Models
{
    class BoardModel
    {
        public List<CellModel> Cells { get; set; }
        private string boardToBeFilled = "100004530500000610046008000800590006000407000400062003000300250051000007083700009";
        private string boardFilledCorrectly = "197624538528973614346158972832591746619437825475862193764389251951246387283715469";


        public BoardModel()
        {
            
        }


    }
}
