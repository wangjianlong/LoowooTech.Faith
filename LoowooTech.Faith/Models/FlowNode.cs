using LoowooTech.Faith.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LoowooTech.Faith.Models
{
    [Table("flownode")]
    public class FlowNode
    {
        public FlowNode()
        {
            CreateTime = DateTime.Now;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        /// <summary>
        /// 审核人ID
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// 诚信行为记录ID
        /// </summary>
        public int InfoID { get; set; }
        [ForeignKey("InfoID")]
        public Conduct Conduct { get; set; }
        /// <summary>
        /// 录入时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }
        public DoingState State { get; set; }

    }

    public enum DoingState
    {
        [Description("待办")]
        None,
        [Description("办结")]
        Done,
        [Description("退回")]
        Roll
    }
}