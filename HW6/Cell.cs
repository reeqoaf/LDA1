using System;
using System.Collections.Generic;
using System.Text;

namespace HW6
{
    public partial class Cell
    {
        public enum Type
        {
            FreeCell,
            EnemyCell,
            PlayerCell,
            ResourceCell
        }
        public Type CellType { get; set; }
        public Cell(Type CellType)
        {
            this.CellType = CellType;
        }
    }
}
