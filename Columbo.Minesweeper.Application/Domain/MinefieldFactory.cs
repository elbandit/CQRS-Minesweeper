using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Columbo.Minesweeper.Application.Domain
{
    public class MinefieldFactory : IMinefieldFactory
    {
        private readonly IGridFactory _grid_factory;
        private readonly IMinePlanterFactory _mine_planter_factory;
        private readonly IMineClearer _mine_clearer;

        public MinefieldFactory(IGridFactory grid_factory, IMinePlanterFactory mine_planter_factory, IMineClearer mine_clearer)
        {
            _grid_factory = grid_factory;
            _mine_planter_factory = mine_planter_factory;
            _mine_clearer = mine_clearer;
        }

        public IMinefield create_a_mindfield_with_these_options(GameOptions game_options, Guid game_id)
        {                                   
            var grid = _grid_factory.create_grid_with_size_of(game_options.game_difficulty.minefield_size, 
                                                                          game_id);

            var mine_planter = _mine_planter_factory.create_for(game_options.game_difficulty);

            mine_planter.plant_mines_on(grid);

            var minefield = new Minefield(grid, _mine_clearer);
           
            // TODO: Move this to inside the constructor?
            // DomainEvent.raise(new MinefieldCreatedFor(_game_id, minefield));

            return minefield;
        }
    }
}
