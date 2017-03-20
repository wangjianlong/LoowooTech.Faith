using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoowooTech.Faith.Parameters
{
    public class ConductStandardParameter:ConductParameter
    {
        /// <summary>
        /// 企业或者自然人名称
        /// </summary>
        public string ELName { get; set; }
        /// <summary>
        /// 诚信行为名称
        /// </summary>
        public string StandardName { get; set; }
    }
}