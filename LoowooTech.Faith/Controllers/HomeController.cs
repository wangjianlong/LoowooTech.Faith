using LoowooTech.Faith.Common;
using LoowooTech.Faith.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoowooTech.Faith.Controllers
{

    public class HomeController : ControllerBase
    {
        public ActionResult Index()
        {
            if (!Identity.IsAuthenticated)
            {
                return Redirect("/User/Login");
            }
            ViewBag.ECount = Core.EnterpriseManager.Count();
            ViewBag.LCount = Core.LawyerManager.Count();
            ViewBag.LandCount = Core.LandManager.Count();
            ViewBag.LandRecordCount = Core.LandRecordManager.Count();
            ViewBag.Black = Core.RollManager.Count(Models.BREnum.Black);
            ViewBag.Red = Core.RollManager.Count(Models.BREnum.Red);
            ViewBag.CCount = Core.ConductManager.Count();
            ViewBag.FCount = Core.FeedManager.Count();
            return View();
        }


        public ActionResult Search()
        {
            return View();
        }

        public ActionResult SearchEnterprise(string key,int page=1)
        {
            var parameter = new EnterpriseParameter
            {
                Name = key,
                Page = new PageParameter(page,20)
            };
            var list = Core.EnterpriseManager.Search(parameter);
            parameter.SearchEndTime = DateTime.Now;
            ViewBag.List = list;
            ViewBag.Parameter = parameter;
            return View();
        }
        public ActionResult DetailEnterprise(int id)
        {
            var model = Core.EnterpriseManager.Get(id);
            ViewBag.Model = model;
            return View();
        }


        public ActionResult DetailLawyer(int id)
        {
            var model = Core.LawyerManager.Get(id);
            ViewBag.Model = model;
            return View();
        }

        public ActionResult SearchLawyer(string key,int page=1)
        {
            var parameter = new LawyerParameter
            {
                Name = key,
                Page = new PageParameter(page,20),
                
            };
            var list = Core.LawyerManager.Search(parameter);
            parameter.SearchEndTime = DateTime.Now;
            ViewBag.Parameter = parameter;
            ViewBag.List = list;
            return View();
        }
    }
}