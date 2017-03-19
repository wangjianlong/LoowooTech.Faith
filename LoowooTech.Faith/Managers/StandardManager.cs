using LoowooTech.Faith.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoowooTech.Faith.Managers
{
    /// <summary>
    /// 各个环节行为评定
    /// </summary>
    public class StandardManager:ManagerBase
    {
        /// <summary>
        /// 作用：保存标准
        /// 作者：汪建龙
        /// 编写时间：2017年3月6日17:08:54
        /// </summary>
        /// <param name="standard"></param>
        /// <returns></returns>
        public int Save(Standard standard)
        {
            Db.Standards.Add(standard);
            Db.SaveChanges();
            return standard.ID;
        }
        /// <summary>
        /// 作用：编辑更新标准行为
        /// 作者：汪建龙
        /// 编写时间：2017年3月6日17:10:113
        /// </summary>
        /// <param name="standard"></param>
        /// <returns></returns>
        public bool Edit(Standard standard)
        {
            var model = Db.Standards.Find(standard.ID);
            if (model == null)
            {
                return false;
            }
            Db.Entry(model).CurrentValues.SetValues(standard);
            Db.SaveChanges();
            return true;
        }
        /// <summary>
        /// 作用：获取
        /// 作者：汪建龙
        /// 编写时间：2017年3月6日17:11:24
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Standard Get(int id)
        {
            if (id == 0)
            {
                return null;
            }
            return Db.Standards.Find(id);
        }
        /// <summary>
        /// 作用：删除
        /// 作者：汪建龙
        /// 编写时间：2017年3月6日17:13:19
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            var model = Db.Standards.Find(id);
            if (model == null)
            {
                return false;
            }
            Db.Standards.Remove(model);
            Db.SaveChanges();
            return true;
        }
        /// <summary>
        /// 作用：获取系统中所有的评定标准  按照环节分组
        /// 作者：汪建龙
        /// 编写时间：2017年3月6日17:16:15
        /// </summary>
        /// <returns></returns>
        public Dictionary<Credit,List<Standard>> GetList()
        {
            var list = Db.Standards.ToList();
            return list.GroupBy(e => e.Credit).ToDictionary(e => e.Key, e => e.ToList());
        }
        /// <summary>
        /// 作用：验证系统中是否存在记录
        /// 作者：汪建龙
        /// 编写时间：2017年3月6日17:39:03
        /// </summary>
        /// <param name="name"></param>
        /// <param name="credit"></param>
        /// <returns></returns>
        public bool Exist(string name,Credit credit)
        {
            return Db.Standards.Any(e => e.Name.ToLower() == name.ToLower() && e.Credit == credit);
        }
        /// <summary>
        /// 作用：获取某一环节的诚信类型
        /// 作者：汪建龙
        /// 编写时间：2017年3月6日19:09:46
        /// </summary>
        /// <param name="credit"></param>
        /// <returns></returns>
        public List<Standard> GetList(Credit credit)
        {
            return Db.Standards.Where(e => e.Credit == credit).OrderBy(e => e.ID).ToList();
        }
    }
}