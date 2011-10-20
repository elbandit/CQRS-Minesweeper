using System;

namespace Columbo.Minesweeper.Application.Domain
{
    public class MinesweeperFactory : IMinesweeperFactory
    {
        private readonly IMinefieldFactory _minefield_factory;        

        public MinesweeperFactory(IMinefieldFactory minefield_factory)
        {
            _minefield_factory = minefield_factory;            
        }

        public IMinesweeper create_game_with(GameOptions game_options)
        {                       
            return new Minesweeper(_minefield_factory, game_options);           
        }
    }
}