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
        private IPlayerIdentifier _player_identifier;

        public GameController(IPresenter presenter, IBus bus, IPlayerIdentifier player_identifier)
        {
            _presenter = presenter;
            _bus = bus;
            _player_identifier = player_identifier;
        }

        public ActionResult Index()
        {
            var minefield_model = _presenter.get_view_of_minefield_for(_player_identifier.get_player_identifier());                                                                              

            return View(minefield_model);
        }

        public ActionResult Reveal(int col, int row)
        {
            var reveal_tile_command = new RevealTileCommand();            
            reveal_tile_command.player_id = _player_identifier.get_player_identifier();
            reveal_tile_command.coordinate = new Coordinate(row, col);

            _bus.send(reveal_tile_command);

            return RedirectToAction("Index");
        }
    }
}
