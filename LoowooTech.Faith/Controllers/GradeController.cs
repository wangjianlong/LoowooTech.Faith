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

        /// <summary>
        /// 作用：对企业和自然人进行信用评级
        /// 作者：汪建龙
        /// 编写时间：2017年3月28日17:12:26
        /// </summary>
        /// <returns></returns>
        public ActionResult Calculate()
        {
            Core.GradeManager.Grade2(City.ID);
            return SuccessJsonResult();
        }

        public ActionResult Download(GradeDegree? degree=null)
        {
            var enterprise = Core.ScoreManager.GetEnterprise(City.ID);
            var lawyers = Core.ScoreManager.GetLawyer(City.ID);
            if (degree.HasValue)
            {
                enterprise = enterprise.Where(e => e.Degree == degree.Value).ToList();
                lawyers = lawyers.Where(e => e.Degree == degree.Value).ToList();
            }
            IWorkbook workbook = RollExcelManager.SaveScore(enterprise,lawyers);
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