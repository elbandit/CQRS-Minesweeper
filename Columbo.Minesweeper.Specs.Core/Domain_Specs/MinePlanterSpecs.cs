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
                number_of_mines_to_plant = 3;

                random_tile_picker = An<ITilePicker>();

                grid = An<IGrid>();
                                
                Subject = new MinePlanter(random_tile_picker, number_of_mines_to_plant);
            };

            private Because of = () => Subject.plant_mines_on(grid);

            private It should_tell_the_grid_to_find_3_tiles_using_the_tile_picker = () =>
            {
                grid.WasToldTo(x => x.plant_mine_using(random_tile_picker)).Times(3);
            };
            
            private static IMinePlanter Subject;
            private static IGrid grid;
            private static int number_of_mines_to_plant;
            private static ITilePicker random_tile_picker;
        }
    }
}
