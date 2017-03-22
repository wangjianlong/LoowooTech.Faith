using LoowooTech.Faith.Models;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace LoowooTech.Faith.Common
{
    public static class ExcelManager
    {
        public static ICell GetCell(IRow row, int line, IRow modelRow = null)
        {
            ICell cell = row.GetCell(line);
            if (cell == null)
            {
                if (modelRow != null)
                {
                    cell = row.CreateCell(line, modelRow.GetCell(line).CellType);
                    cell.CellStyle = modelRow.GetCell(line).CellStyle;
                }
                else
                {
                    cell = row.CreateCell(line);
                }
            }
            return cell;
        }
        public static IWorkbook OpenExcel(this string filePath)
        {
            IWorkbook workbook = null;
            using (var fs=new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite))
            {
                workbook = WorkbookFactory.Create(fs);
            }
            return workbook;
        }
        private static ICell[] GetCells(IRow row,int startline,int endline)
        {
            var cells = new ICell[endline - startline+1];
            var j = 0;
            for(var i = startline; i <= endline; i++)
            {
                var cell = row.GetCell(i);
                if (cell == null)
                {
                    return null;
                }
                cells[j++] = cell;
            }
            return cells;
        }
        private static string[] GetString(IRow row,int startline,int endline)
        {
            var results = new string[endline - startline+1];
            var j = 0;
            for(var i = startline; i <= endline; i++)
            {
                var cell = row.GetCell(i);
                if (cell == null)
                {
                    return null;
                }
                results[j++] = cell.ToString().Trim();
            }
            return results;
        }

        /// <summary>
        /// 作用：分析一行得到自然人实体类
        /// 作者：汪建龙
        /// 编写时间：2017年3月6日14:52:36
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private static Lawyer AnalyzeLawyer(IRow row)
        {
            var cells = new ICell[11];
            for(var i = 0; i < cells.Length; i++)
            {
                cells[i] = row.GetCell(i);
            }
            var name = cells[0].ToString();
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }
            var lawyer = new Lawyer
            {
                Name = name,
                BornTime = cells[2].ToString().Trim(),
                Number = cells[4].ToString().Trim(),
                Address = cells[8].ToString().Trim(),
                TelPhone = cells[9].ToString().Trim(),
                EMail=cells[10].ToString().Trim()
            };
            try
            {
                lawyer.Sex = EnumHelper.GetEnum<Sex>(cells[1].ToString().Trim());
                lawyer.Credential = EnumHelper.GetEnum<Credential>(cells[3].ToString().Trim());
            }
            catch
            {

            }
            return lawyer;
        }
        private static LandRecordView AnalyzeLandRecord(IRow row)
        {
            var cells = GetCells(row, 0, 7);
            if (cells == null)
            {
                return null;
            }
            var name = cells[0].ToString().Trim();
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }
            var a = .0;
            var model = new LandRecordView
            {
                ELName = name,
                Code = cells[1].ToString().Trim(),
                IllegalArea = double.TryParse(cells[2].ToString().Trim(), out a) ? a : .0,
                Area = double.TryParse(cells[3].ToString().Trim(), out a) ? a : .0,
                Score = double.TryParse(cells[5].ToString().Trim(), out a) ? a : .0
            };
            return model;
        }
        private static Land AnalyzeLand(IRow row)
        {
            var cells = GetCells(row, 0, 21);
            if (cells == null)
            {
                return null;
            }
            var elName = cells[2].ToString().Trim();
            var name = cells[5].ToString().Trim();
            if (string.IsNullOrEmpty(elName)||string.IsNullOrEmpty(name))
            {
                return null;
            }
            var a = .0;
            DateTime time;
            var land = new Land
            {
                ELName = elName,
                Name = name,
                Number = cells[6].ToString().Trim(),
                ContractNumber = cells[7].ToString().Trim(),
                LandNumber = cells[8].ToString().Trim(),
                Area = double.TryParse(cells[10].ToString().Trim(), out a) ? a : .0,
                Money=double.TryParse(cells[12].ToString().Trim(),out a)?a:.0,
                Code=cells[13].ToString().Trim(),
                SignTime=DateTime.TryParse(cells[15].ToString().Trim(),out time)?time:time,
                ApproveTime=DateTime.TryParse(cells[18].ToString().Trim(),out time)?time:time,
                Recycle=cells[19].ToString().Trim()=="否"?false:true,
                Location=cells[20].ToString().Trim()
            };
            var area = cells[11].ToString().Trim();
            if (!string.IsNullOrEmpty(area))
            {
                if(double.TryParse(area,out a))
                {
                    land.ReplaceArea = a;
                }
            }
            var way = cells[9].ToString().Trim();
            if (!string.IsNullOrEmpty(way))
            {
                try
                {
                    land.Way = EnumHelper.GetEnum<SoldWay>(way);

                }
                catch
                {

                }
            }

            return land;
        }
        private static List<ConductStandard> AnalyzeConductStandard(IRow row,string[] standardName)
        {
            var list = new List<ConductStandard>();
            var cells = GetCells(row, 0, 25);
            if (cells == null)
            {
                return null;
            }
            var landname = cells[2].ToString().Trim();
            var elName = cells[3].ToString().Trim();
            if (string.IsNullOrEmpty(landname)||string.IsNullOrEmpty(elName))
            {
                return null;
            }
            double a = .0;

            for(var i = 4; i <= 25; i++)
            {
                var cell = cells[i];
                if(double.TryParse(cell.ToString().Trim(),out a)&&a>0)
                {
                    list.Add(new ConductStandard
                    {
                        ELName = elName,
                        LandName=landname,
                        Score = a,
                        StandardName = standardName[i - 4]
                    });
                }
            }
            return list;
        }

        /// <summary>
        /// 作用：分析一行 获取企业类型
        /// 作者：汪建龙
        /// 编写时间：2017年3月6日14:59:21
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private static Enterprise AnalyzeEnterprise(IRow row)
        {
            var cells = GetCells(row, 0, 17);
            if (cells == null)
            {
                return null;
            }
            var name = cells[0].ToString().Trim();
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }
            var a = .0;
            var enterprise = new Enterprise
            {
                Name = name,
                OIBC = cells[1].ToString().Trim(),
                USCC = cells[2].ToString().Trim(),
                Address = cells[6].ToString().Trim(),
                Lawyer = cells[7].ToString().Trim(),
                LawNumber = cells[8].ToString().Trim(),
                Number = cells[9].ToString().Trim(),
                Scope = cells[10].ToString().Trim(),
                Type = cells[11].ToString().Trim(),
                Money = double.TryParse(cells[12].ToString(), out a) ? a : .0,
                ContactWay = cells[13].ToString().Trim(),
                Contact = cells[15].ToString().Trim(),
                TelPhone = cells[16].ToString().Trim()
            };
            return enterprise;
        }


        /// <summary>
        /// 作用：分析文件得到自然人列表信息
        /// 作者：汪建龙
        /// 编写时间：2017年3月6日14:51:05
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static List<Lawyer> AnalyzeLawyer(string filePath)
        {
            var list = new List<Lawyer>();
            IWorkbook workbook = filePath.OpenExcel();
            if (workbook != null)
            {
                ISheet sheet = workbook.GetSheetAt(0);
                if (sheet != null)
                {
                    for(var i = 1; i <= sheet.LastRowNum; i++)
                    {
                        var row = sheet.GetRow(i);
                        if (row == null)
                        {
                            continue;
                        }
                        var lawyer = AnalyzeLawyer(row);
                        if (lawyer != null)
                        {
                            list.Add(lawyer);
                        }
                    }
                }
            }
            return list;
        }
        /// <summary>
        /// 作用：分析文件获取违法用地列表
        /// 作者：汪建龙
        /// 编写时间：2017年3月19日16:44:28
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static List<LandRecordView> AnalyzeLandRecord(string filePath)
        {
            var list = new List<LandRecordView>();
            IWorkbook workbook = filePath.OpenExcel();
            if (workbook != null)
            {
                ISheet sheet = workbook.GetSheetAt(0);
                if (sheet != null)
                {
                    for(var i = 1; i <= sheet.LastRowNum; i++)
                    {
                        var row = sheet.GetRow(i);
                        if (row == null)
                        {
                            continue;
                        }
                        var landrecord = AnalyzeLandRecord(row);
                        if (landrecord != null)
                        {
                            list.Add(landrecord);
                        }
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// 作用：分析获取文件中的供地列表
        /// 作者：汪建龙
        /// 编写时间：2017年3月16日20:09:11
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static List<Land> AnalyzeLand(string filePath)
        {
            var list = new List<Land>();
            IWorkbook workbook = filePath.OpenExcel();
            if (workbook != null)
            {
                ISheet sheet = workbook.GetSheetAt(0);
                if (sheet != null)
                {
                    for(var i = 1; i <= sheet.LastRowNum; i++)
                    {
                        var row = sheet.GetRow(i);
                        if (row == null)
                        {
                            continue;
                        }
                        var land = AnalyzeLand(row);
                        if (land != null)
                        {
                            list.Add(land);
                        }
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// 作用：分析企业文件得到企业列表
        /// 作者：汪建龙
        /// 编写时间：2017年3月6日15:00:29
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static List<Enterprise> AnalyzeEnterprise(string filePath)
        {
            var list = new List<Enterprise>();
            IWorkbook workbook = filePath.OpenExcel();
            if (workbook != null)
            {
                ISheet sheet = workbook.GetSheetAt(0);
                if (sheet != null)
                {
                    for(var i = 1; i <= sheet.LastRowNum; i++)
                    {
                        var row = sheet.GetRow(i);
                        if (row == null)
                        {
                            continue;
                        }
                        try
                        {
                            var enterprise = AnalyzeEnterprise(row);
                            if (enterprise != null)
                            {
                                list.Add(enterprise);
                            }
                        }
                        catch
                        {

                        }
                      
                    }
                }
            }
            return list;
        }


        public static List<ConductStandard> AnalyzeConduct(string filePath)
        {
            var list = new List<ConductStandard>();
            IWorkbook workbook = filePath.OpenExcel();
            if (workbook != null)
            {
                ISheet sheet = workbook.GetSheetAt(0);
                if (sheet != null)
                {
                    var headrow = sheet.GetRow(2);
                    if (headrow == null)
                    {
                        throw new ArgumentException("无诚信行为记录");
                    }
                    var standardNames = GetString(headrow, 4, 24);
                    if (standardNames == null)
                    {
                        throw new ArgumentException("未获取诚信行为记录信息");
                    }
                    for(var i = 3; i <= sheet.LastRowNum; i++)
                    {
                        var row = sheet.GetRow(i);
                        if (row == null)
                        {
                            continue;
                        }
                        var temp = AnalyzeConductStandard(row, standardNames);
                        if (temp != null && temp.Count > 0)
                        {
                            list.AddRange(temp);
                        }
                    }
                }
            }
            return list;
        }
    }
}