using Sports_JDias.Code;
using Sports_JDias.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sports_JDias.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        private static int saveId = 0;
        // GET: Game
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateGame()
        {
            GameViewModel model = new GameViewModel();
            model.gameDate = DateTime.Now; //Set default value for the game date.  Assume it happened today.
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateGame(GameViewModel model)
        {
            model.createDate = DateTime.Now;
            dataHandler.handle.newGame(model);
            return RedirectToAction("ListGames");
        }

        [HttpGet]
        public ActionResult ListGames()
        {
            return View(dataHandler.handle.getGames());
        }

        [HttpGet]
        public ActionResult EditGame(int id)
        {
            saveId = id;
            List<GameViewModel> models = dataHandler.handle.getGames();
            foreach (GameViewModel m in models)
            {
                if (m.gameID == id) return View(m);
            }
            return View();
        }

        [HttpPost]
        public ActionResult EditGame(GameViewModel model)
        {
            model.gameID = saveId;
            dataHandler.handle.editGame(model);
            return RedirectToAction("ListGames");
        }

        public ActionResult DeleteGame(int id)
        {
            dataHandler.handle.deleteGame(id);
            return RedirectToAction("ListGames");
        }
    }
}