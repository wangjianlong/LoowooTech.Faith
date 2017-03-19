using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoowooTech.Faith.Models
{
    public class Subject:ScoreBase
    {
        /// <summary>
        /// 评级
        /// </summary>
        public string Level { get; set; }
        public string LevelDescription { get; set; }
        /// <summary>
        /// 评级时间
        /// </summary>
        public DateTime? GradeTime { get; set; }
    }
}