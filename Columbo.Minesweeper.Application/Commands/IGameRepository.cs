using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Columbo.Minesweeper.Application.Domain;

namespace Columbo.Minesweeper.Application.Commands
{
    public interface IGameRepository
    {
        void save(IMinesweeper minesweeper);

        void add(IMinesweeper minesweeper);

        IMinesweeper get_by(Guid game_id);
    }
}
