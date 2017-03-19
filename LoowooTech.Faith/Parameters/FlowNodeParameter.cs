using LoowooTech.Faith.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoowooTech.Faith.Parameters
{
    public class FlowNodeParameter:ParameterBase
    {
        public int? UserID { get; set; }
        public DateTime? Time { get; set; }
        public DoingState? State { get; set; }
    }
}