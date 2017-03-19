using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace LoowooTech.Faith.Models
{
    public class Grade
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Bad { get; set; }
        public int? Less { get; set; }
        public int? Litter { get; set; }
        public double? MinScore { get; set; }
        public double? MaxScore { get; set; }
        public string Content
        {
            get
            {
                var sb = new StringBuilder();
                if (Bad.HasValue)
                {
                    if (Bad.Value != 0)
                    {
                        sb.AppendFormat("{0}条（含）以上严重不诚信行为;", Bad.Value);
                    }
                  
                }
                else
                {
                    sb.Append("具有严重不诚信行为;");
                }
                if (Less.HasValue )
                {
                    if(Less.Value != 0)
                    {
                        sb.AppendFormat("{0}条（含）不诚信行为;", Less.Value);
                    }
                  
                }
                else
                {
                    sb.Append("具有不诚信行为;");
                }
                if (Litter.HasValue)
                {
                    if(Litter.Value != 0)
                    {
                        sb.AppendFormat("{0}条（含）轻微不诚信行为;", Litter.Value);
                    }
                 
                }
                else
                {
                    sb.Append("具有轻微不诚信行为;");
                }
                if (MinScore.HasValue)
                {
                    sb.AppendFormat("诚信分{0}分（含）以上", MinScore.Value);
                }
                if (MaxScore.HasValue)
                {
                    sb.AppendFormat("诚信分{0}（含）以下", MaxScore.Value);
                }
                return sb.ToString();
            }
        }

        public int Order { get; set; }
    }
}