using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LoowooTech.Faith.Models
{
    [Table("conductview")]
    public class ConductView:ScoreBase
    {
        public int ID { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        public string Content { get; set; }
        public string Remark { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int DataId { get; set; }
        public SystemData SystemData { get; set; }
        public Credit Credit { get; set; }
        public CreditDegree Degree { get; set; }
        public int StandardId { get; set; }
        public double Score { get; set; }
        /// <summary>
        /// 审核结果  空  表示未审核  Checking 正在审核 
        /// </summary>
        public BaseState? State { get; set; }
        /// <summary>
        /// 录入人的ID
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// 诚信行为
        /// </summary>
        public string sName { get; set; }
        
    }
}