using LoowooTech.Faith.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoowooTech.Faith.Parameters
{
    public class FeedParameter:ParameterBase
    {
        public string ELName { get; set; }
        public GradeDegree? Old { get; set; }
        public GradeDegree? New { get; set; }
        public bool? HasRead { get; set; }

    }
}