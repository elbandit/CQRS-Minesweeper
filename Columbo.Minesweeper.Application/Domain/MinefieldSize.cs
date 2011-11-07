using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Columbo.Minesweeper.Application.Domain
{
    public class MinefieldSize
    {        
        public MinefieldSize(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
        }

        public int rows { get; private set; }
        public int columns { get; private set; }
    }
}
