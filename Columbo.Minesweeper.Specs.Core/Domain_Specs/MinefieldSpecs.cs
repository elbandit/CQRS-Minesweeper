using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Columbo.Minesweeper.Application.Domain;
using Machine.Fakes;
using Machine.Specifications;
using Rhino.Mocks;

namespace Columbo.Minesweeper.Specs.Core.Domain_Specs
{
    public class MinefieldSpecs
    {

        public class when_checking_for_surrounding_tiles_next_to_mines_with_a_small_grid : WithSubject<Minefield>
        {
            private Establish context = () =>
            {
                //    |   | X
                // __________
                //    |   |  
                // __________
                //    |   |  

                // when clickling on coord 0,0 should look like

                //    | 1 | X
                // __________
                //    | 1 | 1 
                // __________
                //    |   |  
                
                tile_which_contains_a_mine = An<ITile>();
                tile_which_contains_a_mine.WhenToldTo(x => x.contains_mine()).Return(true);
              
                tile_which_is_next_to_a_mine_1 = An<ITile>();
                tile_which_is_next_to_a_mine_1.WhenToldTo(x => x.is_adjacent_by_a_mine()).Return(true);

                tile_which_is_next_to_a_mine_2 = An<ITile>();
                tile_which_is_next_to_a_mine_2.WhenToldTo(x => x.is_adjacent_by_a_mine()).Return(true);

                tile_which_is_next_to_a_mine_3 = An<ITile>();
                tile_which_is_next_to_a_mine_3.WhenToldTo(x => x.is_adjacent_by_a_mine()).Return(true);

                empty_tile_1 = An<ITile>();
                empty_tile_2 = An<ITile>();
                empty_tile_3 = An<ITile>();
                empty_tile_4 = An<ITile>();
                empty_tile_5 = An<ITile>();

                The<IGrid>().WhenToldTo(x => x.get_tile_at(Arg<Coordinate>.Matches(c => c.Equals(Coordinate.new_coord(0, 2))))).Return(tile_which_contains_a_mine);
                The<IGrid>().WhenToldTo(x => x.get_tile_at(Arg<Coordinate>.Matches(c => c.Equals(Coordinate.new_coord(0, 1))))).Return(tile_which_is_next_to_a_mine_1);
                The<IGrid>().WhenToldTo(x => x.get_tile_at(Arg<Coordinate>.Matches(c => c.Equals(Coordinate.new_coord(1, 1))))).Return(tile_which_is_next_to_a_mine_2);
                The<IGrid>().WhenToldTo(x => x.get_tile_at(Arg<Coordinate>.Matches(c => c.Equals(Coordinate.new_coord(1, 2))))).Return(tile_which_is_next_to_a_mine_3);

            };

            private Because of = () => Subject.reveal_tile_at(Coordinate.new_coord(0,0));

            private It should_get_the_tile_at_the_coordinate = () =>
            {
                The<IGrid>().WasToldTo(x => x.get_tile_at(Arg<Coordinate>.Matches(c => c.Equals(Coordinate.new_coord(0,0)))));
            };

            private It should_reveal_all_the_empty_tiles = () =>
            {
            };

            private It should_not_reveal_the_tile_with_the_mine = () =>
            {
            };

            private It should_tell_the_tiles_that_are_adjacent_to_mines_to_display_how_many_mines_they_are_near_to = () =>
            {
            };

            private static ITile tile_which_contains_a_mine;
            private static ITile tile_which_is_next_to_a_mine_1;
            private static ITile tile_which_is_next_to_a_mine_2;
            private static ITile tile_which_is_next_to_a_mine_3;
            private static ITile empty_tile_1;
            private static ITile empty_tile_2;
            private static ITile empty_tile_3;
            private static ITile empty_tile_4;
            private static ITile empty_tile_5;
        }
    }
}
