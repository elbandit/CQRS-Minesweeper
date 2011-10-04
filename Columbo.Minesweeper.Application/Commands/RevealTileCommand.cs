using System;
using Columbo.Minesweeper.Application.Domain;

namespace Columbo.Minesweeper.Application.Commands
{
    public class RevealTileCommand : ICommand
    {
        public Guid player_id { get; set; }

        public Coordinate coordinate { get; set; }
    }
}