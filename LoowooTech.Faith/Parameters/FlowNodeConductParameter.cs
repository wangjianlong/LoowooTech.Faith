using LoowooTech.Faith.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoowooTech.Faith.Parameters
{
    public class FlowNodeConductParameter:ParameterBase
    {
        public int? UserID { get; set; }
        public DoingState? FlowNodeState { get; set; }
    }
}