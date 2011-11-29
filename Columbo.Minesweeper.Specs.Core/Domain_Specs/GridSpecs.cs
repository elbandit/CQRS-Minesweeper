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
    public class GridSpecs
    {
        [Subject(typeof(Grid))]
        public class when_checking_for_unrevealed_tiles_with_no_mines : WithFakes
        {
            private Establish context = () =>
            {
                tile_factory = An<ITileFactory>();
                minesweeper = An<IMinesweeper>();
                tile = An<ITile>();

                tile_factory.WhenToldTo(x => x.create_for(Arg<Coordinate>.Is.Anything, Arg<Guid>.Is.Anything))
                            .Return(tile);

                number_of_rows = 3;
                number_of_columns = 3;
                minefield_size = new MinefieldSize(3, 3);


                Subject = new Grid(tile_factory, minefield_size, Guid.NewGuid());
            };

            private Because of = () => Subject.contains_unrevealed_tiles_with_no_mines();

            private It should_check_all_tiles_to_see_if_we_have_unrevealed_tiles_with_no_mines = () =>
            {
                var row_count = 0;
                while (row_count < number_of_rows)
                {
                    var column_count = 0;
                    while (column_count < number_of_columns)
                    {
                        tile.AssertWasCalled(x => x.is_unrevealed_with_no_mine());

                        column_count++;
                    }

                    row_count++;
                }
            };

            private static IGrid Subject;
            private static ITileFactory tile_factory;
            private static int number_of_rows;
            private static int number_of_columns;
            private static ITile tile;
            private static IMinesweeper minesweeper;
            private static MinefieldSize minefield_size;
        }

        [Subject(typeof(Grid))]
        public class when_creating_a_grid : WithFakes
        {
            private Establish context = () =>
            {
                tile_factory = An<ITileFactory>();
                minesweeper = An<IMinesweeper>();

                number_of_rows = 3;
                number_of_columns = 3;
                minefield_size = new MinefieldSize(3, 3);
            };

            private Because of = () => Subject = new Grid(tile_factory, minefield_size, Guid.NewGuid());

            private It should_tell_the_tile_factory_to_create_a_tile_for_each_coordinate = () =>
            {
                var row_count = 0;
                while (row_count < number_of_rows)
                {
                    var column_count = 0;
                    while (column_count < number_of_columns)
                    {
                        tile_factory.WasToldTo(x => x.create_for(Arg<Coordinate>.Matches(c => c.Equals(new Coordinate(row_count, column_count))), Arg<Guid>.Is.Anything));

                        column_count++;
                    }

                    row_count++;
                }

            };

            //private It should_have_a_tile_at_all_of_the_grid_positions = () =>
            //{
            //    var row_count = 0;
            //    while (row_count < number_of_rows)
            //    {
            //        var column_count = 0;
            //        while (column_count < number_of_columns)
            //        {
            //            Assert.That(Subject.contains_tile_at(new Coordinate(row_count, column_count)), Is.True);

            //            column_count++;
            //        }

            //        row_count++;
            //    }
            //};

            //private It should_not_have_tiles_out_side_of_the_grid_positions = () =>
            //{
            //    Assert.Fail();
            //};

            private static IGrid Subject;
            private static ITileFactory tile_factory;
            private static int number_of_rows;
            private static int number_of_columns;
            private static IMinesweeper minesweeper;
            private static MinefieldSize minefield_size;
        }
    }
}
