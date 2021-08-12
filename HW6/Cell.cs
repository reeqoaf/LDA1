using System;
using System.Collections.Generic;
using System.Text;

namespace HW6
{
    public class Cell
    {
        public CellType CellType { get; set; }
        public Cell(CellType CellType)
        {
            this.CellType = CellType;
        }
    }
}
