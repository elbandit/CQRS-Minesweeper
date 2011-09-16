using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Columbo.Minesweeper.Domain;

namespace Columbo.Minesweeper.Ui.Web.Controllers
{
    public class HomeController : Controller
    {
        private IBus _bus;

        public HomeController(IBus bus)
        {
            _bus = bus;       
        }
        
        public ActionResult Index()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult StartGame9x9()
        {
            _bus.send(new CreateGameCommand());

            return RedirectToAction("Index", "Game");
        }        
    }
}
