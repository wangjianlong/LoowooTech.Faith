using LoowooTech.Faith.Common;
using LoowooTech.Faith.Models;
using NPOI.SS.UserModel;
using NPOI.XWPF.UserModel;
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
            // var list = Core.RollViewManager.GetList(bREnum,key);
            var list = Core.RollViewManager.GetRollList(bREnum, key);
            ViewBag.List = list;
            return View();
        }


        [UserAuthorize]
        public ActionResult DownLoad(BREnum brenum,string key)
        {
            var list = Core.RollViewManager.GetRollList(brenum, key);
            IWorkbook workbook = RollExcelManager.SaveRoll(list);
            MemoryStream ms = new MemoryStream();
            workbook.Write(ms);
            ms.Flush();
            byte[] fileContents = ms.ToArray();
            return File(fileContents, "application/ms-excel", string.Format("诚信系统{0}名单列表.xls",brenum==BREnum.Black?"黑":"异常"));
        }

        public ActionResult DownloadWord()
        {
            XWPFDocument doc = RollExcelManager.SaveWord(Core.RollViewManager.GetRollList(BREnum.Black,null,true));
            MemoryStream ms = new MemoryStream();
            doc.Write(ms);
            //workbook.Write(ms);
            ms.Flush();
            byte[] fileContents = ms.ToArray();
            return File(fileContents, "application/octet-stream", "黑名单公式.docx");
        }
    }
}