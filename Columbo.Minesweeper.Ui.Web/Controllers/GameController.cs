using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Columbo.Minesweeper.Application.Domain;
using Columbo.Minesweeper.Application.Commands;
using Columbo.Minesweeper.Ui.Web.Models;
using Columbo.Minesweeper.Application.Queries;
using Columbo.Minesweeper.Application.Queries.Views;

namespace Columbo.Minesweeper.Ui.Web.Controllers
{
    public class GameController : Controller
    {
        private IPresenter _presenter;
        private readonly IBus _bus;

        public GameController(IPresenter presenter, IBus bus)
        {
            _presenter = presenter;
            _bus = bus;
        }

        public ActionResult Index()
        {            
            var minefield_model = _presenter.get_view_of_minefield();

            return View(minefield_model);
        }

        public ActionResult Reveal(int col, int row)
        {
            _bus.send(new RevealTileCommand());

            return RedirectToAction("Index");
        }
    }
}
