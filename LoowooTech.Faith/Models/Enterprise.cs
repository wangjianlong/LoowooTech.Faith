using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LoowooTech.Faith.Models
{
    [Table("enterprise")]
    public class Enterprise:Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        /// <summary>
        /// 组织机构代码
        /// </summary>
        public string OIBC { get; set; }
        /// <summary>
        /// 统一社会信用代码
        /// </summary>
        public string USCC { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 法人
        /// </summary>
        public string Lawyer { get; set; }
        /// <summary>
        /// 法人身份证号
        /// </summary>
        public string LawNumber { get; set; }
        /// <summary>
        /// 营业执照/注册号
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// 经营范围
        /// </summary>
        public string Scope { get; set; }
        /// <summary>
        /// 企业类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 注册资本
        /// </summary>
        public double Money { get; set; }
        /// <summary>
        /// 企业联系方式
        /// </summary>
        public string ContactWay { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string Contact { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string TelPhone { get; set; }
        [NotMapped]
        public List<Conduct> Conducts { get; set; }
        public int? LawyerID { get; set; }

        
    }
}