using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Machine.Fakes;
using NUnit.Framework;
using Columbo.Minesweeper.Application.Domain;

namespace Columbo.Minesweeper.Specs.Core.Domain_Specs
{
    public class TileSpecs
    {
        [Subject(typeof(Tile))]
        public class when_asking_if_surrounded_by_mines : WithFakes
        {
            private Establish context = () =>
            {

            };
        }
    }
}
