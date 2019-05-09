using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Views
{
    class CellModel
    {
        private int _row;
        private int _col;
        private char _value = ' ';

        public int Row
        {
            get { return _row; }
            set { _row = value; }
        }

        public int Column
        {
            get { return _col; }
            set { _col = value; }
        }

        public char Value
        {
            get { return _value; }
            set
            {
                if(value >= '1' && value <= '9')
                    _value = value;
            }
        }

        public CellModel(int row, int col, char value)
        {
            Row = row;
            Column = col;
            Value = value;
        }

    }
}
