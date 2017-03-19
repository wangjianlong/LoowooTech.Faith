using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LoowooTech.Faith.Models
{
    [Table("conduct_standard_view")]
    public class ConductStandard
    {
        public int ID { get; set; }
        public int LandID { get; set; }
        public string LandName { get; set; }
        public Credit Credit { get; set; }
        public CreditDegree Degree { get; set; }
        public int standardID { get; set; }
        public string StandardName { get; set; }
        public double Score { get; set; }
        public BaseState? State { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public DateTime CreateTime { get; set; }
        public int ELID { get; set; }
        public SystemData SystemData { get; set; }
        public string ELName { get; set; }
        public string Remark { get; set; }
    }
}