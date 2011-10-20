using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Columbo.Minesweeper.Application.Domain;

namespace Columbo.Minesweeper.Application.Commands
{
    public interface IGameTypeMapper
    {
        GameOptions map_from(CreateGameCommand command);
    }
}
