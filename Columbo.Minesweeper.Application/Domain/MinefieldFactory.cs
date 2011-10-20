using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Columbo.Minesweeper.Application.Domain
{
    public class MinefieldFactory : IMinefieldFactory
    {
        private IGridFactory _grid_factory;
        private readonly IMinePlanterFactory _mine_planter_factory;

        public MinefieldFactory(IGridFactory grid_factory, IMinePlanterFactory mine_planter_factory)
        {
            _grid_factory = grid_factory;
            _mine_planter_factory = mine_planter_factory;
        }

        public IMinefield create_a_mindfield_with_these_options(GameOptions game_type, IMinesweeper minesweeper)
        {                        
            var mine_planter = _mine_planter_factory.create(game_type.game_difficulty.number_of_mines);                       

            var minefield =  new Minefield(_grid_factory.create_grid_with_size_of(game_type.game_difficulty.rows, 
                                                                                  game_type.game_difficulty.columns, 
                                                                                  minesweeper));

            minefield.plant_mines_with(mine_planter);

            return minefield;
        }
    }
}
