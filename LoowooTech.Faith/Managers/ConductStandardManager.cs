using LoowooTech.Faith.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoowooTech.Faith.Managers
{
    public class ConductStandardManager:ManagerBase
    {
        /// <summary>
        /// 作用：获取某一个供地的诚信记录
        /// 作者：汪建龙
        /// 编写时间：2017年3月18日16:15:44
        /// </summary>
        /// <param name="landID"></param>
        /// <returns></returns>
        public List<ConductStandard> GetByLandID(int landID)
        {
            var list = Db.ConductStandards.Where(e => e.LandID == landID).ToList();
            return list;
        }
    }
}