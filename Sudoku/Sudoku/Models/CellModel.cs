using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Models
{
    class CellModel
    {
        private uint _row;
        private uint _col;
        private uint _value;

        public uint Row
        {
            get { return _row; }
            set { _row = value; }
        }

        public uint Column
        {
            get { return _col; }
            set { _col = value; }
        }

        public uint Value
        {
            get { return _value; }
            set
            {
                if(value >= 1 && value <= 9)
                    _value = value;
            }
        }
    }
}
