using LoowooTech.Faith.Common;
using LoowooTech.Faith.Models;
using LoowooTech.Faith.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoowooTech.Faith.Managers
{
    public class FlowNodeViewManager:ManagerBase
    {
        public List<FlowNodeView> Search(FlowNodeViewParameter parameter)
        {
            var query = Db.FlowNodeView.AsQueryable();
            if (parameter.UserID.HasValue)
            {
                query = query.Where(e => e.UserID == parameter.UserID.Value);
            }
            if (parameter.Credit.HasValue)
            {
                query = query.Where(e => e.Credit == parameter.Credit.Value);
            }
            if (parameter.Degree.HasValue)
            {
                query = query.Where(e => e.Degree == parameter.Degree.Value);
            }
            if (parameter.StartTime.HasValue)
            {
                query = query.Where(e => e.CreateTime >= parameter.StartTime.Value);
            }
            if (parameter.EndTime.HasValue)
            {
                query = query.Where(e => e.CreateTime <= parameter.EndTime.Value);
            }
            if (parameter.MaxScore.HasValue)
            {
                query = query.Where(e => e.Score <= parameter.MaxScore.Value);
            }
            if (parameter.MinScore.HasValue)
            {
                query = query.Where(e => e.Score >= parameter.MinScore.Value);
            }
            if (!string.IsNullOrEmpty(parameter.Name))
            {
                query = query.Where(e => e.Name.ToLower().Contains(parameter.Name.ToLower()));
            }
            if (!string.IsNullOrEmpty(parameter.sName))
            {
                query = query.Where(e => e.sName.ToLower().Contains(parameter.sName.ToLower()));
            }
            if (parameter.State.HasValue)
            {
                query = query.Where(e => e.State == parameter.State.Value);
            }
            if (parameter.fUserID.HasValue)
            {
                query = query.Where(e => e.fUserID == parameter.fUserID.Value);
            }
            if (parameter.fState.HasValue)
            {
                query = query.Where(e => e.fState == parameter.fState.Value);
            }
            if (parameter.SystemData.HasValue)
            {
                query = query.Where(e => e.SystemData == parameter.SystemData.Value);
            }
            if (parameter.StartUpdateTime.HasValue)
            {
                query = query.Where(e => e.UpdateTime >= parameter.StartUpdateTime.Value);
            }
            if (parameter.EndUpdateTime.HasValue)
            {
                query = query.Where(e => e.UpdateTime <= parameter.EndUpdateTime.Value);
            }
            query = query.OrderByDescending(e => e.CreateTime).SetPage(parameter.Page);
            return query.ToList();
        }
    }
}