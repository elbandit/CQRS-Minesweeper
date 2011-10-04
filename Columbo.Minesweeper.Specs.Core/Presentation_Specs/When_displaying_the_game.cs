using System.Web.Mvc;
using Columbo.Minesweeper.Application.Queries;
using Columbo.Minesweeper.Ui.Web.Controllers;
using Machine.Fakes;
using Machine.Specifications;
using MvcContrib.TestHelper;

namespace Columbo.Minesweeper.Specs.Core.Presentation_Specs
{
    [Subject(typeof(GameController))]
    public class When_displaying_the_game : WithSubject<GameController>
    {
        private Establish context = () =>
        {
        };

        private Because of = () => result = Subject.Index();

        private It should_ask_for_a_view_of_the_minefield = () =>
        {
            The<IPresenter>().WasToldTo(x => x.get_view_of_minefield());
        };

        private It should_be_a_view_of_the_minefield = () =>
        {
            result.AssertViewRendered();
        };
  
        private static ActionResult result;
    }
}