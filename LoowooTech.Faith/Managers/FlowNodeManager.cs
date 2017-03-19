using LoowooTech.Faith.Models;
using LoowooTech.Faith.Common;
using LoowooTech.Faith.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoowooTech.Faith.Managers
{
    public class FlowNodeManager:ManagerBase
    {
        /// <summary>
        /// 作用：保存
        /// 作者：汪建龙
        /// 编写时间：2017年3月7日15:18:13
        /// </summary>
        /// <param name="flowNode"></param>
        /// <returns></returns>
        public int Save(FlowNode flowNode)
        {
            Db.FlowNodes.Add(flowNode);
            Db.SaveChanges();
            return flowNode.ID;
        }
        /// <summary>
        /// 作用：编辑更新
        /// 作者：汪建龙
        /// 编写时间：2017年3月7日15:18:38
        /// </summary>
        /// <param name="flowNode"></param>
        /// <returns></returns>
        public bool Edit(FlowNode flowNode)
        {
            var model = Db.FlowNodes.Find(flowNode.ID);
            if (model == null)
            {
                return false;
            }
            Db.Entry(model).CurrentValues.SetValues(flowNode);
            Db.SaveChanges();
            return true;
        }
        /// <summary>
        /// 作用：
        /// 作者：汪建龙
        /// 编写时间：2017年3月7日15:19:58
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FlowNode Get(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            return Db.FlowNodes.Find(id);
        }
        /// <summary>
        /// 作用：查询
        /// 作者：汪建龙
        /// 编写时间：2017年3月7日16:44:42
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public List<FlowNode> Search(FlowNodeParameter parameter)
        {
            var query = Db.FlowNodes.AsQueryable();
            if (parameter.State.HasValue)
            {
                query = query.Where(e => e.State == parameter.State.Value);
            }
            if (parameter.UserID.HasValue)
            {
                query = query.Where(e => e.UserID == parameter.UserID.Value);
            }
            if (parameter.Time.HasValue)
            {
                query = query.Where(e => e.CreateTime > parameter.Time.Value);
            }
            query = query.OrderByDescending(e => e.CreateTime).SetPage(parameter.Page);
            foreach(var item in query)
            {
                Db.Entry(item).Reference(e => e.Conduct).Load();
            
                if (item.Conduct != null)
                {
                    item.Conduct.Standard = Core.StandardManager.Get(item.Conduct.StandardId);
                    item.Conduct.ScoreBase = Core.ConductManager.GetScoreBase(item.Conduct.DataId, item.Conduct.SystemData);
                }
                
            }
            return query.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<FlowNode> GetHistory()
        {
            var query = Db.FlowNodes.Where(e => e.State != DoingState.None).AsQueryable();
            query = query.OrderByDescending(e => e.CreateTime);
            foreach (var item in query)
            {
                Db.Entry(item).Reference(e => e.Conduct).Load();

                if (item.Conduct != null)
                {
                    item.Conduct.Standard = Core.StandardManager.Get(item.Conduct.StandardId);
                    item.Conduct.ScoreBase = Core.ConductManager.GetScoreBase(item.Conduct.DataId, item.Conduct.SystemData);
                }

            }
            return query.ToList();
        }
    }
}