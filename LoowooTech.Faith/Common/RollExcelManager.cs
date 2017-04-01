using LoowooTech.Faith.Models;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoowooTech.Faith.Common
{
    public static class RollExcelManager
    {
        private static string _modelExcelName { get; set; }
        private static string _modelExcelPath { get; set; }


        private static string _modelScorePath { get; set; }
        static RollExcelManager()
        {
            _modelExcelName = System.Configuration.ConfigurationManager.AppSettings["Roll"] ?? "Roll.xls";
            _modelExcelPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Excels", _modelExcelName);

            _modelScorePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Excels", System.Configuration.ConfigurationManager.AppSettings["Score"] ?? "Score.xls");
        }

        public static IWorkbook SaveScore(List<EnterpriseScore> enterprises,List<LawyerScore> lawyers)
        {
            if (!System.IO.File.Exists(_modelScorePath))
            {
                return null;
            }
            IWorkbook workbook = _modelScorePath.OpenExcel();
            if (workbook != null)
            {
                ISheet sheet = workbook.GetSheetAt(0);
                if (sheet != null)
                {
                    var modelrow = sheet.GetRow(0);
                    Write<EnterpriseScore>(enterprises, ref sheet, modelrow);
                }
                var sheet2 = workbook.GetSheetAt(1);
                if (sheet2 != null)
                {
                    var modelRow = sheet2.GetRow(0);
                    Write<LawyerScore>(lawyers, ref sheet2, modelRow);
                }
            }
            return workbook;
        }
        /// <summary>
        /// 作用：生成表单
        /// </summary>
        /// <param name="rollViews"></param>
        /// <returns></returns>
        public static IWorkbook SaveRoll(List<RollList> list)
        {
            if (!System.IO.File.Exists(_modelExcelPath))
            {
                return null;
            }
            IWorkbook workbook = _modelExcelPath.OpenExcel();
            if (workbook == null)
            {
                return null;
            }
            ISheet sheet = workbook.GetSheetAt(0);
            if (sheet != null)
            {
                var modelrow = sheet.GetRow(2);
                WriteTime(ref sheet);
                Write(list, ref sheet, modelrow);
            }
            //ISheet sheet2 = workbook.GetSheetAt(1);
            //if (sheet2 != null)
            //{
            //    var modelrow = sheet2.GetRow(2);
            //    WriteTime(ref sheet2);
            //    Write(rollViews.Where(e => e.BREnum == BREnum.Black).ToList(), ref sheet2, modelrow);
            //}
            return workbook;
        }
        /// <summary>
        /// 作用：填写时间：
        /// 作者：汪建龙
        /// 编写时间：2017年3月8日15:48:22
        /// </summary>
        /// <param name="sheet"></param>
        private static void WriteTime(ref ISheet sheet)
        {
            IRow row = sheet.GetRow(0);
            if (row == null)
            {
                row = sheet.CreateRow(0);
            }
            ICell cell = row.GetCell(3);
            if (cell == null)
            {
                cell = row.CreateCell(3);
            }
            cell.SetCellValue(DateTime.Now.ToString("yyyy-MM-dd"));
        }

        private static void Write(List<RollList> list,ref ISheet sheet,IRow modelRow)
        {
            var startLine = 2;
            var serial = 1;
            foreach(var item in list)
            {
                var row = sheet.GetRow(startLine);
                if (row == null)
                {
                    row = sheet.CreateRow(startLine);
                }
                startLine++;
                var cell = ExcelManager.GetCell(row, 0, modelRow);
                cell.SetCellValue(serial++);
                ExcelManager.GetCell(row, 1, modelRow).SetCellValue(item.Name);
            }
        }

        private static void Write<T>(List<T> list,ref ISheet sheet,IRow modelRow) where T:BaseScore
        {
            var startLine = 1;
            foreach(var item in list)
            {
                var row = sheet.GetRow(startLine);
                if (row == null)
                {
                    row = sheet.CreateRow(startLine);
                }
                startLine++;
                var cell = ExcelManager.GetCell(row, 0, modelRow);
                cell.SetCellValue(item.Name);
                ExcelManager.GetCell(row, 1, modelRow).SetCellValue(item.Times.HasValue ? item.Times.Value : 0);
                ExcelManager.GetCell(row, 2, modelRow).SetCellValue(item.ScoreValue ?? 0);
                ExcelManager.GetCell(row, 3, modelRow).SetCellValue(item.Average);
                ExcelManager.GetCell(row, 4, modelRow).SetCellValue(item.Record ?? 0);
                ExcelManager.GetCell(row, 5, modelRow).SetCellValue(item.DeDuck);
                ExcelManager.GetCell(row, 6, modelRow).SetCellValue(item.Degree.ToString());
            }
        }
    }
}