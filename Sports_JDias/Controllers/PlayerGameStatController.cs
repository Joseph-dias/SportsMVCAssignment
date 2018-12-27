using Sports_JDias.Code;
using Sports_JDias.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sports_JDias.Controllers
{
    public class PlayerGameStatController : Controller
    {
        private static int saveId = 0;
        // GET: PlayerGameStat
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateStat()
        {
            ViewBag.playerLST = dataHandler.handle.getPlayers().Select(n => n.name).ToList(); //Create the list of names
            ViewBag.gameLST = dataHandler.handle.getGames().Select(n => n.name).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult CreateStat(PlayerGameStatViewModel m)
        {
            m.createDate = DateTime.Now;
            dataHandler.handle.newStat(m);
            return RedirectToAction("ViewStats");
        }

        [HttpGet]
        public ActionResult ViewStats()
        {
            return View(dataHandler.handle.getStats());
        }

        [HttpGet]
        public ActionResult EditStat(int id)
        {
            saveId = id;
            List<PlayerGameStatViewModel> models = dataHandler.handle.getStats();
            foreach (PlayerGameStatViewModel m in models)
            {
                if (m.playerGameStatID == id) return View(m);
            }
            return View();
        }

        [HttpPost]
        public ActionResult EditStat(PlayerGameStatViewModel m)
        {
            m.playerGameStatID = saveId;
            dataHandler.handle.editStat(m);
            return RedirectToAction("ViewStats");
        }

        public ActionResult DeleteStat(int id)
        {
            dataHandler.handle.deleteStat(id);
            return RedirectToAction("ViewStats");
        }
    }
}