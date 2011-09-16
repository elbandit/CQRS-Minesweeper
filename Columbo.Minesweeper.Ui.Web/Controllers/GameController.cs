using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Columbo.Minesweeper.Ui.Web.Models;
using Columbo.Minesweeper.Domain.Presentation;
using Columbo.Minesweeper.Domain.Presentation.Views;

namespace Columbo.Minesweeper.Ui.Web.Controllers
{
    public class GameController : Controller
    {
        private IPresenter _presenter;

        public GameController(IPresenter presenter)
        {
            _presenter = presenter;
        }

        public ActionResult Index()
        {            
            var minefield_model = _presenter.get_view_of_minefield();

            return View(minefield_model);
        }

        public ActionResult Reveal(int col, int row)
        {
            return RedirectToAction("Index");
        }
    }
}
