using System;
using System.Web.Mvc;
using Columbo.Minesweeper.Application.Queries;
using Columbo.Minesweeper.Ui.Web.Controllers;
using Columbo.Minesweeper.Application.Domain;
using Columbo.Minesweeper.Application.Commands;
using Machine.Fakes;
using Machine.Specifications;
using MvcContrib.TestHelper;
using Rhino.Mocks;

namespace Columbo.Minesweeper.Specs.Core.Presentation_Specs
{
    public class GameControllerSpecs
    {
        [Subject(typeof(GameController))]
        public class When_displaying_the_game : WithSubject<GameController>
        {
            private Establish context = () =>
            {
                The<IPlayerIdentifier>().WhenToldTo(x => x.get_player_identifier()).Return(Guid.NewGuid());
            };

            private Because of = () => result = Subject.Index();

            private It should_get_the_identity_of_the_player = () =>
            {
                The<IPlayerIdentifier>().WasToldTo(x => x.get_player_identifier());
            };

            private It should_ask_for_a_view_of_the_minefield = () =>
            {
                The<IPresenter>().WasToldTo(x => x.get_view_of_minefield_for(Arg<Guid>.Is.Anything));
            };

            private It should_be_a_view_of_the_minefield = () =>
            {
                result.AssertViewRendered();
            };

            private static ActionResult result;
        }

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
}