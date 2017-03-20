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
    [UserAuthorize]
    public class GradeController : ControllerBase
    {
        // GET: Grade
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Working()
        {
            int years = 0;
            if(!int.TryParse(System.Configuration.ConfigurationManager.AppSettings["Time"].ToString(),out years))
            {
                return ErrorJsonResult("未获取年限时间");
            }
            var BeginTime = DateTime.Now.AddYears(-years);
            var grades = GradeHelper.GetList().OrderByDescending(e=>e.Order).ToList();
            if (grades.Count == 0)
            {
                return ErrorJsonResult("未读取到评级标准");
            }
            var daily1 = Core.GradeManager.GradeEnterprise(BeginTime, Identity.UserID, grades);
            var daily2 = Core.GradeManager.GradeLawyer(BeginTime, Identity.UserID, grades);
            daily1.AddRange(daily2);
            if (daily1.Count > 0)
            {
                Core.DailyManager.AddRange(daily1);
            }
            return SuccessJsonResult();
        }

        public ActionResult Download()
        {
            var list = Core.ScoreManager.Get();
            IWorkbook workbook = RollExcelManager.SaveScore(list);
            MemoryStream ms = new MemoryStream();
            workbook.Write(ms);
            ms.Flush();
            byte[] fileContents = ms.ToArray();
            return File(fileContents, "application/ms-excel", "综合分值表.xls");
        }

        public ActionResult Score(int ELID,SystemData systemData)
        {
            var model = Core.ScoreManager.Get(ELID, systemData);
            ViewBag.Model = model;
            return View();
        }
    }
}