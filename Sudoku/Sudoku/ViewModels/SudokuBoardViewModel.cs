using Caliburn.Micro;
using Sudoku.Models;
using Sudoku.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace Sudoku.ViewModels
{
    class SudokuBoardViewModel : Conductor<object>
    {
        public ObservableCollection<ObservableCollection<CellModel>> Elements { get; set; }
        private int _size;
        private IWindowManager windowManager;
        private BoardModel board;

        public int Size
        {
            get { return _size; }
            set { _size = value; }
        }

        public void LoadBoardToScreen()
        {
            string b = "100004530500000610046008000800590006000407000400062003000300250051000007083700009";
            for (int i = 0; i < _size; i++)
            {
                Elements.Add(new ObservableCollection<CellModel>());
                for (int j = 0; j < _size; j++)
                {
                    Elements[i].Add( new CellModel(i, j, b[i * _size + j]));
                   // MessageBox.Show(boardString[i * _size + j].ToString());
                }
            }
        }

        public bool isBoardSolvedCorrectly()
        {
            string boardString = "";
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    boardString += Elements[i][j];
                }
            }

            if (boardString == board.BoardFilledCorrectly)
                return true;
            return false;
        }

        public SudokuBoardViewModel(IWindowManager windowManager, int boardSize)
        {
            _size = boardSize;
            Elements = new ObservableCollection<ObservableCollection<CellModel>>();
            LoadBoardToScreen();
        }
    }
}
