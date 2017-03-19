using LoowooTech.Faith.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoowooTech.Faith.Managers
{
    public class RollManager:ManagerBase
    {
        /// <summary>
        /// 作用：保存名单
        /// 作者：汪建龙
        /// 编写时间：2017年3月6日21:40:30
        /// </summary>
        /// <param name="roll"></param>
        /// <returns></returns>
        public int Save(Roll roll)
        {
            Db.Rolls.Add(roll);
            Db.SaveChanges();
            return roll.ID;
        }

        /// <summary>
        /// 作用：编辑名单
        /// 作者：汪建龙
        /// 编写时间：2017年3月6日21:42:02
        /// </summary>
        /// <param name="roll"></param>
        /// <returns></returns>
        public bool Edit(Roll roll)
        {
            var model = Db.Rolls.Find(roll.ID);
            if (model == null)
            {
                model = Db.Rolls.FirstOrDefault(e => e.DataId == roll.DataId && e.SystemData == roll.SystemData);
                if (model == null)
                {
                    return false;
                }
              
            }
            Db.Entry(model).CurrentValues.SetValues(roll);
            Db.SaveChanges();
            return true;
        }
        /// <summary>
        /// 作用：删除名单
        /// 作者：汪建龙
        /// 编写时间：2017年3月6日21:43:16
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            var model = Db.Rolls.Find(id);
            if (model == null)
            {
                return false;
            }
            Db.Rolls.Remove(model);
            Db.SaveChanges();
            return true;
        }
        /// <summary>
        /// 作用：更新名单
        /// 作者：汪建龙
        /// 编写时间：2017年3月7日20:23:56
        /// </summary>
        /// <param name="id"></param>
        /// <param name="systemData"></param>
        /// <param name="degree"></param>
        /// <returns></returns>
        public string Update(int id,SystemData systemData,CreditDegree degree)
        {
            if (degree == CreditDegree.Good)
            {
                return null;;
            }
            string error = string.Empty;
            var model = Db.Rolls.FirstOrDefault(e => e.DataId == id && e.SystemData == systemData);
            if (model == null)
            {
                model = new Roll { DataId = id, SystemData = systemData,BREnum=degree==CreditDegree.Less?BREnum.Red:BREnum.Black };
                var rid = Save(model);
                if (rid <= 0)
                {
                    error = "添加名单";
                }
            }
            else
            {
                if (model.BREnum == BREnum.Red && degree == CreditDegree.Bad)
                {
                    model.BREnum = BREnum.Black;
                    if (!Edit(model))
                    {
                        error = "更新名单";
                    }
                }
            }
            return error;
            
        }
        public long Count(BREnum brenum)
        {
            return Db.Rolls.Where(e => e.BREnum == brenum).LongCount();
        }
    }
}