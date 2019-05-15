using Caliburn.Micro;
using Sudoku.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sudoku.Models
{
    class BoardModel
    {
        private string _boardFilledCorrectly;
        private string _boardToBeFilled;

        public string BoardToBeFilled
        {
            get { return _boardToBeFilled; }
            set { _boardToBeFilled = value; }
        }
        public string BoardFilledCorrectly
        {
            get { return _boardFilledCorrectly; }
            set { _boardFilledCorrectly = value; }
        }

        public BoardModel(string boardFilledCorrectly, string boardToBeFilled)
        {
            _boardFilledCorrectly = boardFilledCorrectly;
            _boardToBeFilled = boardToBeFilled;
        }

        public BoardModel()
        {

        }
    }
}
