using LoowooTech.Faith.Common;
using LoowooTech.Faith.Models;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoowooTech.Faith.Controllers
{
   
    public class RollController : ControllerBase
    {
        [UserAuthorize]
        public ActionResult Index(BREnum BREnum = BREnum.Black, string key = null)
        {
            ViewBag.BREnum = BREnum;
            ViewBag.Key = key;
            return View();
        }

        public ActionResult Black(string key=null)
        {
            ViewBag.Key = key;
            return View();
        }

        public ActionResult Red(string key=null)
        {
            ViewBag.Key = key;
            return View();
        }
        [UserAuthorize(false)]
        public ActionResult List(BREnum bREnum,string key)
        {
            var list = Core.RollViewManager.GetList(bREnum,key);
            ViewBag.List = list;
            return View();
        }


        [UserAuthorize]
        public ActionResult DownLoad()
        {
            var list = Core.RollViewManager.GetList();
            IWorkbook workbook = RollExcelManager.SaveRoll(list);
            MemoryStream ms = new MemoryStream();
            workbook.Write(ms);
            ms.Flush();
            byte[] fileContents = ms.ToArray();
            return File(fileContents, "application/ms-excel", "诚信系统名单列表.xls");
        }
    }
}