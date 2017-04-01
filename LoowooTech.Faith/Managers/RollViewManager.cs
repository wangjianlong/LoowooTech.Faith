using LoowooTech.Faith.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoowooTech.Faith.Managers
{
    public class RollViewManager:ManagerBase
    {
        /// <summary>
        /// 作用：获取某一类名单列表
        /// 作者：汪建龙
        /// 编写时间：2017年3月8日09:33:37
        /// </summary>
        /// <param name="brenum"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public List<RollView> GetList(BREnum brenum,string key)
        {
            var query = Db.RollViews.Where(e => e.BREnum == brenum).AsQueryable();
            if (!string.IsNullOrEmpty(key))
            {
                query = query.Where(e => e.Name.ToLower().Contains(key.ToLower()));
            }
            return query.ToList();
        }

        public long Count(BREnum brnum)
        {
            return GetRollList(brnum, null).LongCount();
        }

        public List<RollList> GetRollList(BREnum brenum,string key)
        {
            return GetList(brenum == BREnum.Black ? GradeDegree.D : GradeDegree.C, key);
        }

        public List<RollList> GetList(GradeDegree degree,string key)
        {
            var result = new List<RollList>();
            result.AddRange(GetEnterprise(degree,key));
            result.AddRange(GetLawyer(degree, key));
            return result;
        }

        public List<RollList> GetEnterprise(GradeDegree degree,string key)
        {
            var query = Db.Enterprises.Where(e => e.Deleted == false && e.Degree == degree).AsQueryable();
            if (!string.IsNullOrEmpty(key))
            {
                query = query.Where(e => e.Name.ToLower().Contains(key.ToLower()));
            }
            return query.ToList().Select(e => new RollList { DataId = e.ID, SystemData = SystemData.Enterprise, Name = e.Name }).ToList();
        }

        public List<RollList> GetLawyer(GradeDegree degree,string key)
        {
            var query = Db.Lawyers.Where(e => e.Deleted == false && e.Degree == degree).AsQueryable();
            if (!string.IsNullOrEmpty(key))
            {
                query = query.Where(e => e.Name.ToLower().Contains(key.ToLower()));
            }
            return query.ToList().Select(e => new RollList { DataId = e.ID, SystemData = SystemData.Lawyer, Name = e.Name }).ToList();
        }


        public List<RollView> GetList()
        {
            return Db.RollViews.ToList();
        }
    }
}