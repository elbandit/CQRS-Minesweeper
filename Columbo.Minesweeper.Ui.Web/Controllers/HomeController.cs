using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Columbo.Minesweeper.Application;
using Columbo.Minesweeper.Application.Commands.Infrastructure;
using Columbo.Minesweeper.Application.Domain;
using Columbo.Minesweeper.Application.Commands;
using log4net;
using StructureMap;
using Columbo.Minesweeper.Application.Queries;
using Columbo.Minesweeper.Application.Queries.Views;
using Columbo.Minesweeper.Ui.Web.Models;

namespace Columbo.Minesweeper.Ui.Web.Controllers
{
    public class HomeController : Controller
    {
        private IBus _bus;
        private IPlayerIdentifier _player_identifier;
        private IPresenter _presenter;

        public HomeController(IBus bus, IPlayerIdentifier player_identifier, IPresenter presenter)
        {
            _bus = bus;
            _player_identifier = player_identifier;
            _presenter = presenter;
        }
        
        public ActionResult Index()
        {
            StartGameViewModel viewmodel =new StartGameViewModel() ;

            if (!_player_identifier.has_indenitfier())
            {
                _player_identifier.set_player_identifier(Guid.NewGuid());
            }
            else
            {
                var game_view = _presenter.get_view_of_minefield_for(_player_identifier.get_player_identifier());

                if (game_view != null && !game_view.game_has_finished())
                {
                    viewmodel.show_resume_game_button = true;
                }
            }

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult ResumeGame()
        {
            return RedirectToAction("Index", "Game");
        }

        [HttpPost]
        public ActionResult StartGame(string difficulty_name)
        {            
            var create_game_command = new CreateGameCommand();
            create_game_command.player_id = _player_identifier.get_player_identifier();
            create_game_command.game_difficulty = new GameDifficultyFactory().find_game_difficulty_by(difficulty_name);
            
            _bus.send(create_game_command);
                        
            return RedirectToAction("Index", "Game");
        }        
    }
}
