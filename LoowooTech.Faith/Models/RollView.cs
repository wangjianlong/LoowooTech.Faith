using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LoowooTech.Faith.Models
{
    [Table("rollview")]
    public class RollView:ScoreBase
    {
        public int ID { get; set; }
        public BREnum BREnum { get; set; }
        public int DataId { get; set; }
        public SystemData SystemData { get; set; }
    }
}