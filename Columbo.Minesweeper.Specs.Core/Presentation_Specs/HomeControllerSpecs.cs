using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Columbo.Minesweeper.Application.Commands;
using Machine.Specifications;
using Columbo.Minesweeper.Ui.Web.Controllers;
using System.Web.Mvc;
using MvcContrib.TestHelper;
using MvcContrib;
using Rhino.Mocks;
using Columbo.Minesweeper.Application.Domain;
using Machine.Fakes;
using NUnit.Framework;
using Columbo.Minesweeper.Ui.Web.Models;

namespace Columbo.Minesweeper.Specs.Core.Presentation_Specs
{
    public class HomeControllerSpecs
    {
        [Subject(typeof(HomeController))]
        public class when_displaying_the_start_page_with_a_game_already_started : WithSubject<HomeController>
        {
            private Establish context = () =>
            {

            };

            private Because of = () => result = Subject.Index();

            private It should_check_to_see_if_the_current_player_has_already_started_a_game = () =>
            {
                
            };

            private It should_tell_the_view_to_display_the_resume_game_button = () =>
            {
                var view_result = (ViewResult)result;

                var view_model = (StartGameViewModel)view_result.ViewData.Model;

                Assert.That(view_model.show_resume_game_button, Is.True);
            };

            private static ActionResult result;

        };

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
