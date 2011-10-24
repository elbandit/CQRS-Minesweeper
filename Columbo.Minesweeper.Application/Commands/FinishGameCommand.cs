using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Columbo.Minesweeper.Application.Commands
{
    public class FinishGameCommand : ICommand
    {
        public Guid player_id { get; set; }
    }
}
