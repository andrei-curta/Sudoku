using Caliburn.Micro;
using Sudoku.Models;
using System.Collections.Generic;

namespace Sudoku.ViewModels
{
    class SudokuBoardViewModel : Conductor<object>
    {
        public BindableCollection<CellModel> Cells { get; set; }
        public BindableCollection<string> Elements { get; set; }
        private uint _size;
        private IWindowManager windowManager;

        //public List<List<string>> Elements { get; set; }

        public uint Size
        {
            get { return _size; }
            set { _size = value; }
        }

        public SudokuBoardViewModel(IWindowManager windowManager, uint boardSize)
        {
            this.windowManager = windowManager;
            Size = boardSize;
            Cells = new BindableCollection<CellModel>();
            Elements = new BindableCollection<string>();
            for (int i = 0; i < 5; i++)
            {
                Elements.Add(i.ToString());
                
            }
        }
    }
}
