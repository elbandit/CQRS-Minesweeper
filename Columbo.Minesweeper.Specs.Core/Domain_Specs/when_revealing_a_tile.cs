using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Columbo.Minesweeper.Application.Domain;
using Machine.Fakes;
using Machine.Specifications;

namespace Columbo.Minesweeper.Specs.Core.Domain_Specs
{
    public class when_revealing_a_tile : WithSubject<Application.Domain.Minesweeper>
    {
        private Establish context = () =>
        {
            
        };

        private Because of = () => Subject.reveal_tile_at(coordinate);

        private It should_ask_the_minefield_to_reveal_the_tile = () =>
        {
            The<IMinefield>().WasToldTo(x => x.reveal_tile_at(coordinate));
        };

        private static Coordinate coordinate;
    }
}
