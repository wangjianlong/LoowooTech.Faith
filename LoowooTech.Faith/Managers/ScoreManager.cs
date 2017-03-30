using LoowooTech.Faith.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoowooTech.Faith.Managers
{
    public class ScoreManager:ManagerBase
    {
        public List<Score> Get()
        {
            return Db.Scores.ToList();
        }
        public List<Score> Get(SystemData systemData)
        {
            return Db.Scores.Where(e => e.SystemData == systemData).ToList();
        }
        public Score Get(int ELID,SystemData systemData)
        {
            var model = Db.Scores.FirstOrDefault(e => e.ID == ELID && e.SystemData == systemData);
            return model;
        }

    }
}