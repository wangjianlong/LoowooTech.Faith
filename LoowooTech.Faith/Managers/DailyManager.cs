using LoowooTech.Faith.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoowooTech.Faith.Managers
{
    public class DailyManager:ManagerBase
    {
        public void AddRange(List<Daily> list)
        {
            try
            {
                Db.Dailys.AddRange(list);
                Db.SaveChanges();
            }
            catch
            {

            }
        }
        /// <summary>
        /// 作用：保存
        /// 作者：汪建龙
        /// 编写时间：2017年3月7日10:08:31
        /// </summary>
        /// <param name="daily"></param>
        /// <returns></returns>
        public int Save(Daily daily)
        {
            Db.Dailys.Add(daily);
            Db.SaveChanges();
            return daily.ID;
        }
    }
}