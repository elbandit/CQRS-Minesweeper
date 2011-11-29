using System;

namespace Columbo.Minesweeper.Application.Domain
{
    public interface IMinefieldFactory
    {
        IMinefield create_a_mindfield_with_these_options(GameOptions game_options, Guid game_id);
    }
}