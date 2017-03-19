using LoowooTech.Faith.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoowooTech.Faith.Parameters
{
    public class ConductParameter:ParameterBase
    {
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public Credit? Credit { get; set; }
        public CreditDegree? Degree { get; set; }
        public double? MinScore { get; set; }
        public double? MaxScore { get; set; }
        public BaseState? State { get; set; }
        public int? UserID { get; set; }
        public SystemData? SystemData { get; set; }
    }
}