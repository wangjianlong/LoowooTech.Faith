using LoowooTech.Faith.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoowooTech.Faith.Parameters
{
    public class LawyerParameter:ParameterBase
    {
        public string Name { get; set; }
        public Sex? Sex { get; set; }
        public string BornTime { get; set; }
        public string Number { get; set; }
        public string Address { get; set; }
        public string TelPhone { get; set; }
        public string Email { get; set; }
        public GradeDegree? Degree { get; set; }
        public bool Deleted { get; set; }

    }
}