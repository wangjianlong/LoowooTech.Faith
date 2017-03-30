using LoowooTech.Faith.Common;
using LoowooTech.Faith.Models;
using LoowooTech.Faith.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoowooTech.Faith.Managers
{
    public class FeedManager:ManagerBase
    {
        public List<Feed> Search(FeedParameter parameter)
        {
            var query = Db.Feeds.AsQueryable();
            if (parameter.HasRead.HasValue)
            {
                query = query.Where(e => e.HasRead == parameter.HasRead.Value);
            }

            query = query.OrderByDescending(e => e.CreateTime).SetPage(parameter.Page);
            return query.ToList();
        }

        public int Save(Feed feed)
        {
            Db.Feeds.Add(feed);
            Db.SaveChanges();
            return feed.ID;
        }
    }
}