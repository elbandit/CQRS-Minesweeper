using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Columbo.Minesweeper.Application.Domain
{
    public class GameDifficulty
    {
        public GameDifficulty(int rows, int columns, int number_of_mines)
        {
            this.rows = rows;
            this.columns = columns;
            this.number_of_mines = number_of_mines;
        }
        public int rows { get; private set; }
        public int columns { get; private set; }
        public int number_of_mines { get; private set; }
    }
}
