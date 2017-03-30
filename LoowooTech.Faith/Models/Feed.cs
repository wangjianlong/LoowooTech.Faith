using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LoowooTech.Faith.Models
{
    [Table("feed")]
    public class Feed
    {
        public Feed()
        {
            CreateTime = DateTime.Now;
        }
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int ELID { get; set; }
        public SystemData SystemData { get; set; }
        public GradeDegree? Old { get; set; }
        public GradeDegree? New { get; set; }
        public DateTime CreateTime { get; set; }
        public bool HasRead { get; set; }
        public int? ConductID { get; set; }
    }
}