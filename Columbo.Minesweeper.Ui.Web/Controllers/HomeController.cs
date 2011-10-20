using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Columbo.Minesweeper.Application;
using Columbo.Minesweeper.Application.Domain;
using Columbo.Minesweeper.Application.Commands;
using log4net;
using StructureMap;

namespace Columbo.Minesweeper.Ui.Web.Controllers
{
    public class HomeController : Controller
    {
        private IBus _bus;
        private IPlayerIdentifier _player_identifier;

        public HomeController(IBus bus, IPlayerIdentifier player_identifier)
        {
            _bus = bus;
            _player_identifier = player_identifier;
        }
        
        public ActionResult Index()
        {
            if (!_player_identifier.has_indenitfier())
            {
                _player_identifier.set_player_identifier(Guid.NewGuid());
            }
                            
            return View();
        }

        [HttpPost]
        public ActionResult StartGame(string difficulty_name)
        {            
            var create_game_command = new CreateGameCommand();
            create_game_command.player_id = _player_identifier.get_player_identifier();
            create_game_command.game_difficulty = new GameDifficultyFactory().find_game_difficulty_by(difficulty_name);
            //create_game_command.grid_size = 3;
            //create_game_command.number_of_mines = 1;

          _bus.send(create_game_command);
            

            //var _log = LogManager.GetLogger("");
            //// test logging
            //_log.Error("from log4net inside StartGame9x9 action");         
            return RedirectToAction("Index", "Game");
        }        
    }
}
