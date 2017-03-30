using LoowooTech.Faith.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoowooTech.Faith.Parameters
{
    public class EnterpriseParameter:ParameterBase
    {
        public string Name { get; set; }
        public string OIBC { get; set; }
        public string USCC { get; set; }
        public string Address { get; set; }
        public string Lawyer { get; set; }
        public string LawNumber { get; set; }
        public string Number { get; set; }
        public string Scope { get; set; }
        public string Type { get; set; }
        public double? MinMoney { get; set; }
        public double? MaxMoney { get; set; }
        public string Contact { get; set; }
        public string TelPhone { get; set; }
        public GradeDegree? Degree { get; set; }
        public bool Deleted { get; set; }
    }
}