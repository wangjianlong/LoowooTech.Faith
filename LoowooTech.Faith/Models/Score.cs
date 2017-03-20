using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LoowooTech.Faith.Models
{
    [Table("scores")]
    public class Score
    {
        [Key]
        public int ID { get; set; }
        public string ELName { get; set; }
        public SystemData SystemData { get; set; }
        public int? Times { get; set; }
        public int? ScoreValue { get; set; }
        [NotMapped]
        public int Average
        {
            get
            {
                if (ScoreValue.HasValue&&Times.HasValue)
                {
                    return (int)((double)ScoreValue.Value / Times.Value+0.5);
                }
                return 0;
            }
        }
        public int? Record { get; set; }
        [NotMapped]
        public int DeDuck
        {
            get
            {
                if (Record.HasValue)
                {
                    return 100- Average - Record.Value;
                }
                return 100-Average;
            }
        }
        [NotMapped]
        public string Degree
        {
            get
            {
                if (DeDuck == 100)
                {
                    return "A";
                }else if (DeDuck < 100 && DeDuck >= 80)
                {
                    return "B";
                }else if (DeDuck < 80 && DeDuck >= 60)
                {
                    return "C";
                }
                return "D";
            }
        }
    }
}