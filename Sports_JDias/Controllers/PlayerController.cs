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
    public class PlayerController : Controller
    {
        private static int saveId = 0;
        // GET: Player
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreatePlayer()
        {
            PlayerViewModel model = new PlayerViewModel();
            model.dob = DateTime.Now.AddYears(-20);
            return View(model);
        }

        [HttpPost]
        public ActionResult CreatePlayer(PlayerViewModel model)
        {
            model.createDate = DateTime.Now;
            dataHandler.handle.newPlayer(model);
            return RedirectToAction("ListPlayers");
        }


        [HttpGet]
        public ActionResult ListPlayers()
        {
            return View(dataHandler.handle.getPlayers());
        }

        [HttpGet]
        public ActionResult EditPlayer(int id)
        {
            saveId = id;
            List<PlayerViewModel> models = dataHandler.handle.getPlayers();
            foreach(PlayerViewModel m in models)
            {
                if (m.playerID == id) return View(m);
            }
            return View();
        }

        [HttpPost]
        public ActionResult EditPlayer(PlayerViewModel model)
        {
            model.playerID = saveId;
            dataHandler.handle.editPlayer(model);
            return RedirectToAction("ListPlayers");
        }

        public ActionResult DeletePlayer(int id)
        {
            dataHandler.handle.deletePlayer(id);
            return RedirectToAction("ListPlayers");
        }
    }
}