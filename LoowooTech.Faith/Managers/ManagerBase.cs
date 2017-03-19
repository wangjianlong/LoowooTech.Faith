using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoowooTech.Faith.Managers
{
    public class ManagerBase
    {
        protected ManagerCore Core { get { return ManagerCore.Instance; } }
        protected FaithDbContext Db { get { return OneContext.Current; } }
        //protected DataContext GetDbContext()
        //{
        //    return new DataContext();
        //}
    }
}