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
    public class when_revealing_a_tile_on_a_minefield : WithSubject<Minefield>
    {
        private Establish context = () =>
        {
            coordinate = Coordinate.parse("0,0");
            selected_tile = An<ITile>();
            The<IGrid>().WhenToldTo(x => x.get_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate)))).Return(selected_tile);
        };

        private Because of = () => Subject.reveal_tile_at(coordinate);

        private It should_get_the_tile_at_the_coordinate = () =>
        {
            The<IGrid>().WasToldTo(x => x.get_tile_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate))));
        };

        private It should_reveal_the_tile_at_the_coordinate = () =>
        {
            selected_tile.WasToldTo(x => x.reveal());
        };

        private It should_reveal_surrounding_tiles_with_no_mines = () =>
        {
            Assert.Fail();
        };

        private It should_not_reveal_the_tile_containing_the_mine = () =>
        {
            Assert.Fail();
        };

        private static Coordinate coordinate;
        private static ITile selected_tile;
    }
}
