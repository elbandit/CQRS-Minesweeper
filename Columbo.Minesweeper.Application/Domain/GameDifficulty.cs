using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Columbo.Minesweeper.Application.Domain
{
    public class GameDifficulty
    {
        public GameDifficulty(MinefieldSize minefield_size, int number_of_mines)
        {
            this.minefield_size = minefield_size;
            this.number_of_mines = number_of_mines;
        }
        
        public MinefieldSize minefield_size { get; private set; }
        public int number_of_mines { get; private set; }
    }
}
