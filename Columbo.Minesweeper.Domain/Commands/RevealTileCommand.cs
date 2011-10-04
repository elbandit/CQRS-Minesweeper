using System;
using Columbo.Minesweeper.Domain.Model;

namespace Columbo.Minesweeper.Domain.Commands
{
    public class RevealTileCommand : ICommand
    {
        public Guid player_id { get; set; }

        public Coordinate coordinate { get; set; }
    }
}