using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Columbo.Minesweeper.Application.Domain;
using Machine.Specifications;
using Machine.Fakes;
using NUnit.Framework;
using Rhino.Mocks;

namespace Columbo.Minesweeper.Specs.Core.Domain_Specs
{
    public class MinePlanterSpecs
    {
        [Subject(typeof(MinePlanter))]
        public class when_planting_mines_on_a_grid : WithFakes
        {
            private Establish context = () =>
            {
                game_difficulty = new GameDifficulty(new MinefieldSize(3,3),3);

                random_coordinate_picker = An<ICoordinatePicker>();

                random_coordinate_picker.WhenToldTo(x => x.pick_coordinates_from(game_difficulty.minefield_size, game_difficulty.number_of_mines)).Return(new List<Coordinate>(){new Coordinate(1, 1)});           

                grid = An<IGrid>();
                                
                Subject = new MinePlanter(random_coordinate_picker, game_difficulty);
            };

            private Because of = () => Subject.plant_mines_on(grid);

            private It should_tell_the_coordinate_picker_to_pick_3_coordinates_based_on_the_size_of_the_minefield = () =>
            {
                random_coordinate_picker.WasToldTo(x => x.pick_coordinates_from(game_difficulty.minefield_size, game_difficulty.number_of_mines)).Times(3);
            };

            private It should_tell_grid_to_place_mines_on_coordinates_tiles = () =>
            {
                grid.WasToldTo(x => x.plant_mine_at(Arg<Coordinate>.Is.Anything));
            };
            
            private static IMinePlanter Subject;
            private static IGrid grid;
            private static GameDifficulty game_difficulty;
            private static ICoordinatePicker random_coordinate_picker;
        }
    }
}
