using System;
using Columbo.Minesweeper.Application.Domain;

namespace Columbo.Minesweeper.Application.Commands.Infrastructure
{
    public interface IGameRepository
    {
        void save(IMinesweeper minesweeper);

        void add(IMinesweeper minesweeper);

        void delete(IMinesweeper minesweeper);

        IMinesweeper get_by(Guid game_id);
    }
}
