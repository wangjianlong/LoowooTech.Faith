using LoowooTech.Faith.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoowooTech.Faith.Controllers
{
    public class RankController : ControllerBase
    {
        // GET: Rank
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail(int elid,SystemData systemData)
        {
            var model = Core.RankManager.Get(elid, systemData);
            ViewBag.Model = model;
            return View();
        }
    }
}