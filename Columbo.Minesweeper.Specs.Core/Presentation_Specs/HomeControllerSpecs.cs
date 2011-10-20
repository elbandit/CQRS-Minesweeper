using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Columbo.Minesweeper.Application.Commands;
using Machine.Specifications;
using Columbo.Minesweeper.Ui.Web.Controllers;
using System.Web.Mvc;
using MvcContrib.TestHelper;
using Rhino.Mocks;
using Columbo.Minesweeper.Application.Domain;
using Machine.Fakes;

namespace Columbo.Minesweeper.Specs.Core.Presentation_Specs
{
    public class HomeControllerSpecs
    {
        [Subject(typeof(HomeController))]
        public class When_starting_a_new_game : WithSubject<HomeController>
        {
            private Establish context = () =>
            {
            };

            private Because of = () => result = Subject.StartGame("");

            private It should_send_a_command_for_a_new_game_to_be_created = () =>
            {
                The<IBus>().WasToldTo(x => x.send(Arg<CreateGameCommand>.Is.TypeOf));
            };

            private It should_redirect_to_the_game_play_screen = () =>
            {
                result.AssertActionRedirect().ToAction<GameController>(x => x.Index());
            };

            private static ActionResult result;
        }
    }
}
