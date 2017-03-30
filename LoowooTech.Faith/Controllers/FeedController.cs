using LoowooTech.Faith.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoowooTech.Faith.Controllers
{
    public class FeedController : ControllerBase
    {
        // GET: Feed
        public ActionResult Index(int page=1,int rows=20)
        {
            var parameter = new FeedParameter
            {
                HasRead = false,
                Page = new PageParameter(page, rows)
            };
            var list = Core.FeedManager.Search(parameter);
            ViewBag.List = list;
            ViewBag.Parameter = parameter;
            return View();
        }


    }
}