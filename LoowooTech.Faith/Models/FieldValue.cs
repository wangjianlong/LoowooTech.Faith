using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LoowooTech.Faith.Models
{
    [Table("fieldValue")]
    public class FieldValue
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int InfoId { get; set; }
        public DateTime Time { get; set; } = DateTime.Now;
        public int FieldId { get; set; }
        public virtual Field Field { get; set; }
        public string Value { get; set; }
    }
}