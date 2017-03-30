using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LoowooTech.Faith.Models
{
    [Table("rank")]
    public class Rank
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int ELID { get; set; }
        public SystemData SystemData { get; set; }
        [NotMapped]
        public GradeDegree Degree
        {
            get
            {
                if (DeDuck == 100)
                {
                    return GradeDegree.A;
                }else if (DeDuck < 100 && DeDuck >= 80)
                {
                    return GradeDegree.B;
                }else if (DeDuck < 80 && DeDuck >= 60)
                {
                    return GradeDegree.C;
                }
                return GradeDegree.D;
            }
        }
        public long Times { get; set; }
        /// <summary>
        /// 扣分记录
        /// </summary>
        public double Values { get; set; }
        [NotMapped]
        public int Average
        {
            get
            {
                return (int)((double)Values / Times + 0.5);
            }
        }
        /// <summary>
        /// 违法用地扣分记录
        /// </summary>
        public int Record { get; set; }

        [NotMapped]
        public int DeDuck
        {
            get { return 100 - Average - Record; }
        }
    }
}