using System;

namespace Columbo.Minesweeper.Domain.Commands
{
    public class CreateGameCommand : ICommand
    {
        public Guid player_id { get; set; }
    }
}
