using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LoowooTech.Faith.Models
{
    [Table("flownodeview")]
    public class FlowNodeView:ConductView
    {
        /// <summary>
        /// 
        /// </summary>
        public int? fUserID { get; set; }
        public DoingState? fState { get; set; }
        public DateTime? fCreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        /// <summary>
        /// 审核人名字
        /// </summary>
        public string UserName { get; set; }
    }
}