using LoowooTech.Faith.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoowooTech.Faith.Managers
{
    public class OffendManager:ManagerBase
    {
        /// <summary>
        /// 作用：保存
        /// 作者：汪建龙
        /// 编写时间：2017年3月16日17:03:13
        /// </summary>
        /// <param name="offend"></param>
        /// <returns></returns>
        public int Save(Offend offend)
        {
            Db.Offends.Add(offend);
            Db.SaveChanges();
            return offend.ID;
        }

        /// <summary>
        /// 作用：编辑更新违法用地信息
        /// 作者：汪建龙
        /// 编写时间：2017年3月16日17:04:41
        /// </summary>
        /// <param name="offend"></param>
        /// <returns></returns>
        public bool Edit(Offend offend)
        {
            var model = Db.Offends.Find(offend.ID);
            if (model == null)
            {
                return false;
            }
            Db.Entry(model).CurrentValues.SetValues(offend);
            Db.SaveChanges();
            return true;
        }

        /// <summary>
        /// 作用：删除违法用地信息记录
        /// 作者：汪建龙
        /// 编写时间：2017年3月16日17:06:50
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            var model = Db.Offends.Find(id);
            if (model == null)
            {
                return false;
            }
            Db.Offends.Remove(model);
            Db.SaveChanges();
            return true;
        }

        /// <summary>
        /// 作用：获取违法用地记录实体
        /// 作者：汪建龙
        /// 编写时间：2017年3月16日17:07:41
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Offend　Get(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            var model = Db.Offends.Find(id);
            return model;
        }
       
    }
}