using LoowooTech.Faith.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoowooTech.Faith.Parameters
{
    public class FlowNodeViewParameter:ConductViewParameter
    {
        public int? fUserID { get; set; }
        public DoingState? fState { get; set; }
        public string UserName { get; set; }
        public DateTime? StartUpdateTime { get; set; }
        public DateTime? EndUpdateTime { get; set; }
    }
}