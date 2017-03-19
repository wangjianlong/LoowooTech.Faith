using LoowooTech.Faith.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoowooTech.Faith.Controllers
{
    public class OffendController : ControllerBase
    {
        // GET: Offend
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Create(int id = 0)
        {
            var model = Core.OffendManager.Get(id);
            ViewBag.Model = model;
            return View();
        }


        public ActionResult Create(Offend offend)
        {

            return SuccessJsonResult();
        }
    }
}