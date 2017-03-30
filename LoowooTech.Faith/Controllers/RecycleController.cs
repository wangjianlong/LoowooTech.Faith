using LoowooTech.Faith.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoowooTech.Faith.Controllers
{
    public class RecycleController : ControllerBase
    {
        // GET: Recycle
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GetEnterprises()
        {
            var list = Core.EnterpriseManager.Search(new Parameters.EnterpriseParameter()
            {
                Deleted = true
            });
            ViewBag.List = list;
            return View();
        }

        public ActionResult GetLawyers()
        {
            var list = Core.LawyerManager.Search(new Parameters.LawyerParameter
            {
                Deleted = true
            });
            ViewBag.List = list;
            return View();
        }

    }
}