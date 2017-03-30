using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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


        #region  信用评级
        public long? Times { get; set; }
        public double? Values { get; set; }
        public int? Record { get; set; }
        public GradeDegree? Degree { get; set; }
        [NotMapped]
        public int? Average
        {
            get
            {
                if (Values.HasValue && Times.HasValue)
                {
                    return (int)((double)Values.Value / Times.Value + 0.5);
                }
                else
                {
                    return null;
                }
               
            }
        }
        [NotMapped]
        public int? DeDuck
        {
            get
            {
                if (Average.HasValue && Record.HasValue)
                {
                    return 100 - Average.Value - Record.Value;
                }
                return null;
            }
        }
        #endregion

        public bool Deleted { get; set; }
        public string Remark { get; set; }
    }
}