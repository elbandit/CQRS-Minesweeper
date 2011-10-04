using System;

namespace Columbo.Minesweeper.Application.Commands
{
    public class CreateGameCommand : ICommand
    {
        public Guid player_id { get; set; }
    }
}
