using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LoowooTech.Faith.Models
{
    [Table("offend")]
    public class Offend
    {
        public Offend()
        {
            CreteTime = DateTime.Now;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        /// <summary>
        /// 企业ID
        /// </summary>
        public int EnterpriseID { get; set; }
        /// <summary>
        /// 查处文号
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// 违法用地面积
        /// </summary>
        public double IllArea { get; set; }
        /// <summary>
        /// 应扣分值
        /// </summary>
        public double Score { get; set; }
        public DateTime CreteTime { get; set; }
    }
}