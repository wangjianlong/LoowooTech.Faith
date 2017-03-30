using LoowooTech.Faith.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoowooTech.Faith.Managers
{
    public class RankManager:ManagerBase
    {

        public void AddRange(List<Rank> list)
        {
            var feeds = new List<Feed>();
            foreach(var rank in list)
            {
                var history = Db.Ranks.FirstOrDefault(e => e.SystemData == rank.SystemData && e.ELID == rank.ELID);
                if (history == null)
                {
                    Db.Ranks.Add(rank);
                }
                else
                {
                    if (history.Degree != rank.Degree)
                    {
                        feeds.Add(new Feed
                        {
                            ELID = rank.ELID,
                            SystemData = rank.SystemData,
                            Old = history.Degree,
                            New = rank.Degree
                        });
                    }
                    rank.ID = history.ID;
                    Db.Entry(history).CurrentValues.SetValues(rank);
                }
            }
            if (feeds.Count > 0)
            {
                Db.Feeds.AddRange(feeds);
            }
            Db.SaveChanges();
        }


        public Rank Get(int elId,SystemData systemData)
        {
            var model = Db.Ranks.FirstOrDefault(e => e.ELID == elId && e.SystemData == systemData);
            return model;
        }
    }
}