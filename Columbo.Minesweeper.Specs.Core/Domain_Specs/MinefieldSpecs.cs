using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Columbo.Minesweeper.Application.Domain;
using Machine.Fakes;
using Machine.Specifications;
using NUnit.Framework;
using Rhino.Mocks;

namespace Columbo.Minesweeper.Specs.Core.Domain_Specs
{
    public class MinefieldSpecs
    {
        [Subject(typeof(Minefield))]
        public class when_revealing_a_tile_on_a_minefield : WithSubject<Minefield>
        {
            private Establish context = () =>
            {
            };

            private Because of = () => Subject.reveal_tile_at(new Coordinate(0, 0));

            private It should_check_to_see_if_all_tiles_not_containing_mines_have_been_revealed = () =>
            {
                The<IGrid>().WasToldTo(x => x.contains_unrevealed_tiles_with_no_mines());
            };

            private It should_check_to_see_if_the_revealed_tile_contains_a_mine = () =>
            {
                The<IGrid>().WasToldTo(x => x.mine_on_tile_at(Arg<Coordinate>.Matches(c => c.Equals(new Coordinate(0, 0)))));
            };        
        }

        [Subject(typeof(Minefield))]
        public class when_revealing_a_tile_on_a_minefield_at_coordinate_0_0_with_mine_at_coordinate_2_2 : WithSubject<Minefield>
        {
            private Establish context = () =>
            {
                var coordinate_00 = new Coordinate(0, 0);                                
                The<IGrid>().WhenToldTo(x => x.contains_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_00)))).Return(true);
                The<IGrid>().WhenToldTo(x => x.mine_on_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_00)))).Return(false);
                The<IGrid>().WhenToldTo(x => x.mines_surrounding_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_00)))).Return(false);

                var coordinate_01 = new Coordinate(0, 1);
                                               
                The<IGrid>().WhenToldTo(x => x.contains_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_01)))).Return(true);
                The<IGrid>().WhenToldTo(x => x.mine_on_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_01)))).Return(false);
                The<IGrid>().WhenToldTo(x => x.mines_surrounding_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_01)))).Return(false);

                var coordinate_02 = new Coordinate(0, 2);                                                
                The<IGrid>().WhenToldTo(x => x.contains_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_02)))).Return(true);
                The<IGrid>().WhenToldTo(x => x.mine_on_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_02)))).Return(false);
                The<IGrid>().WhenToldTo(x => x.mines_surrounding_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_02)))).Return(false);

                var coordinate_10 = new Coordinate(1, 0);                                
                The<IGrid>().WhenToldTo(x => x.contains_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_10)))).Return(true);
                The<IGrid>().WhenToldTo(x => x.mine_on_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_10)))).Return(false);
                The<IGrid>().WhenToldTo(x => x.mines_surrounding_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_10)))).Return(false);

                var coordinate_11 = new Coordinate(1, 1);                
                The<IGrid>().WhenToldTo(x => x.contains_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_11)))).Return(true);
                The<IGrid>().WhenToldTo(x => x.mine_on_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_11)))).Return(false);
                The<IGrid>().WhenToldTo(x => x.mines_surrounding_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_11)))).Return(true);

                var coordinate_12 = new Coordinate(1, 2);                                
                The<IGrid>().WhenToldTo(x => x.contains_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_12)))).Return(true);
                The<IGrid>().WhenToldTo(x => x.mine_on_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_12)))).Return(false);
                The<IGrid>().WhenToldTo(x => x.mines_surrounding_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_12)))).Return(true);

                var coordinate_20 = new Coordinate(2, 0);                
                The<IGrid>().WhenToldTo(x => x.contains_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_20)))).Return(true);
                The<IGrid>().WhenToldTo(x => x.mine_on_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_20)))).Return(false);
                The<IGrid>().WhenToldTo(x => x.mines_surrounding_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_20)))).Return(false);

                var coordinate_21 = new Coordinate(2, 1);                
                The<IGrid>().WhenToldTo(x => x.contains_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_21)))).Return(true);
                The<IGrid>().WhenToldTo(x => x.mine_on_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_21)))).Return(false);
                The<IGrid>().WhenToldTo(x => x.mines_surrounding_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_21)))).Return(true);

                var coordinate_22 = new Coordinate(2,2);                
                The<IGrid>().WhenToldTo(x => x.contains_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_22)))).Return(true);
                The<IGrid>().WhenToldTo(x => x.mine_on_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_22)))).Return(true);
                The<IGrid>().WhenToldTo(x => x.mines_surrounding_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_22)))).Return(true);                
            };

            private Because of = () => Subject.reveal_tile_at(new Coordinate(0,0));

            private It should_tell_the_grid_to_reveal_the_tile_at_the_coordinate = () =>
            {
                The<IGrid>().WasToldTo(x => x.reveal_tile_at(Arg<Coordinate>.Matches(c => c.Equals(new Coordinate(0,0)))));
            };

            //      |   |   
            //  ------------
            //      | 1 | 1  
            //  ------------
            //      | 1 | X              
                        
            private It should_reveal_surrounding_tiles_with_no_mines = () =>
            {
                The<IGrid>().WasToldTo(x => x.reveal_tile_at(Arg<Coordinate>.Matches(c => c.Equals(new Coordinate(0, 0)))));
                The<IGrid>().WasToldTo(x => x.reveal_tile_at(Arg<Coordinate>.Matches(c => c.Equals(new Coordinate(0, 1)))));
                The<IGrid>().WasToldTo(x => x.reveal_tile_at(Arg<Coordinate>.Matches(c => c.Equals(new Coordinate(0, 2)))));

                The<IGrid>().WasToldTo(x => x.reveal_tile_at(Arg<Coordinate>.Matches(c => c.Equals(new Coordinate(1, 0)))));
                The<IGrid>().WasToldTo(x => x.reveal_tile_at(Arg<Coordinate>.Matches(c => c.Equals(new Coordinate(1, 2)))));
                The<IGrid>().WasToldTo(x => x.reveal_tile_at(Arg<Coordinate>.Matches(c => c.Equals(new Coordinate(1, 2)))));

                The<IGrid>().WasToldTo(x => x.reveal_tile_at(Arg<Coordinate>.Matches(c => c.Equals(new Coordinate(2, 0)))));
                The<IGrid>().WasToldTo(x => x.reveal_tile_at(Arg<Coordinate>.Matches(c => c.Equals(new Coordinate(2, 1)))));
            };

            private It should_not_reveal_the_tile_containing_the_mine = () =>
            {
                The<IGrid>().WasNotToldTo(x => x.reveal_tile_at(Arg<Coordinate>.Matches(c => c.Equals(new Coordinate(2, 2)))));
            };
        }

        [Subject(typeof(Minefield))]
        public class when_revealing_a_tile_on_a_minefield_at_coordinate_0_0_with_mine_at_coordinate_1_1 : WithSubject<Minefield>
        {
            private Establish context = () =>
            {
                var coordinate_00 = new Coordinate(0, 0);                
                The<IGrid>().WhenToldTo(x => x.contains_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_00)))).Return(true);
                The<IGrid>().WhenToldTo(x => x.mine_on_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_00)))).Return(false);
                The<IGrid>().WhenToldTo(x => x.mines_surrounding_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_00)))).Return(true);

                var coordinate_01 = new Coordinate(0, 1);                
                The<IGrid>().WhenToldTo(x => x.contains_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_01)))).Return(true);
                The<IGrid>().WhenToldTo(x => x.mine_on_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_01)))).Return(false);
                The<IGrid>().WhenToldTo(x => x.mines_surrounding_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_01)))).Return(true);

                var coordinate_02 = new Coordinate(0, 2);
                The<IGrid>().WhenToldTo(x => x.contains_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_02)))).Return(true);
                The<IGrid>().WhenToldTo(x => x.mine_on_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_02)))).Return(false);
                The<IGrid>().WhenToldTo(x => x.mines_surrounding_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_02)))).Return(true);

                var coordinate_10 = new Coordinate(1, 0);                
                The<IGrid>().WhenToldTo(x => x.contains_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_10)))).Return(true);
                The<IGrid>().WhenToldTo(x => x.mine_on_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_10)))).Return(false);
                The<IGrid>().WhenToldTo(x => x.mines_surrounding_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_10)))).Return(true);

                var coordinate_11 = new Coordinate(1, 1);
                The<IGrid>().WhenToldTo(x => x.contains_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_11)))).Return(true);
                The<IGrid>().WhenToldTo(x => x.mine_on_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_11)))).Return(true);
                The<IGrid>().WhenToldTo(x => x.mines_surrounding_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_11)))).Return(false);

                var coordinate_12 = new Coordinate(1, 2);
                The<IGrid>().WhenToldTo(x => x.contains_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_12)))).Return(true);
                The<IGrid>().WhenToldTo(x => x.mine_on_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_12)))).Return(false);
                The<IGrid>().WhenToldTo(x => x.mines_surrounding_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_12)))).Return(true);

                var coordinate_20 = new Coordinate(2, 0);                
                The<IGrid>().WhenToldTo(x => x.contains_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_20)))).Return(true);
                The<IGrid>().WhenToldTo(x => x.mine_on_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_20)))).Return(false);
                The<IGrid>().WhenToldTo(x => x.mines_surrounding_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_20)))).Return(true);

                var coordinate_21 = new Coordinate(2, 1);                
                The<IGrid>().WhenToldTo(x => x.contains_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_20)))).Return(true);
                The<IGrid>().WhenToldTo(x => x.mine_on_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_20)))).Return(false);
                The<IGrid>().WhenToldTo(x => x.mines_surrounding_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_20)))).Return(true);

                var coordinate_22 = new Coordinate(2, 2);
                The<IGrid>().WhenToldTo(x => x.contains_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_22)))).Return(true);
                The<IGrid>().WhenToldTo(x => x.mine_on_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_22)))).Return(true);
                The<IGrid>().WhenToldTo(x => x.mines_surrounding_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_22)))).Return(true);
            };

            private Because of = () => Subject.reveal_tile_at(new Coordinate(0, 0));

            private It should_tell_the_grid_to_reveal_the_tile_at_the_coordinate_0_0 = () =>
            {
                The<IGrid>().WasToldTo(x => x.reveal_tile_at(Arg<Coordinate>.Matches(c => c.Equals(new Coordinate(0, 0)))));
            };
            
            //    1 |   |   
            //  ------------
            //      | x |   
            //  ------------
            //      |   |   

            private It should_only_reveal_the_tile_at_coordinate_0_0 = () =>
            {
                The<IGrid>().WasNotToldTo(x => x.reveal_tile_at(Arg<Coordinate>.Matches(c => c.Equals(new Coordinate(0, 1)))));
                The<IGrid>().WasNotToldTo(x => x.reveal_tile_at(Arg<Coordinate>.Matches(c => c.Equals(new Coordinate(0, 2)))));

                The<IGrid>().WasNotToldTo(x => x.reveal_tile_at(Arg<Coordinate>.Matches(c => c.Equals(new Coordinate(1, 0)))));
                The<IGrid>().WasNotToldTo(x => x.reveal_tile_at(Arg<Coordinate>.Matches(c => c.Equals(new Coordinate(1, 1)))));
                The<IGrid>().WasNotToldTo(x => x.reveal_tile_at(Arg<Coordinate>.Matches(c => c.Equals(new Coordinate(1, 2)))));

                The<IGrid>().WasNotToldTo(x => x.reveal_tile_at(Arg<Coordinate>.Matches(c => c.Equals(new Coordinate(2, 0)))));
                The<IGrid>().WasNotToldTo(x => x.reveal_tile_at(Arg<Coordinate>.Matches(c => c.Equals(new Coordinate(2, 1)))));
                The<IGrid>().WasNotToldTo(x => x.reveal_tile_at(Arg<Coordinate>.Matches(c => c.Equals(new Coordinate(2, 2)))));
            };

        }
    }
}
