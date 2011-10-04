using System.Web.Mvc;
using Columbo.Minesweeper.Application.Domain;
using Columbo.Minesweeper.Application.Commands;
using Columbo.Minesweeper.Application.Queries;
using Columbo.Minesweeper.Ui.Web.Controllers;
using Machine.Fakes;
using Machine.Specifications;
using MvcContrib.TestHelper;
using Rhino.Mocks;

namespace Columbo.Minesweeper.Specs.Core.Presentation_Specs
{
    [Subject(typeof(GameController))]
    public class When_revealing_a_tile_on_the_minefield : WithSubject<GameController>
    {
        private Establish context = () =>
        {
        };

        private Because of = () => result = Subject.Reveal(1, 1);

        private It should_send_a_command_to_reveal_the_tile = () =>
        {
            The<IBus>().WasToldTo(x => x.send(Arg<RevealTileCommand>.Is.TypeOf));
        };

        private It should_redirect_to_the_view_game_action = () =>
        {
            result.AssertActionRedirect();
        };

        private static ActionResult result;
    }
}