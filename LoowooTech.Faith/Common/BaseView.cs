using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace LoowooTech.Faith.Common
{
    public class BaseView<TModule>:WebViewPage<TModule>
    {
        public UserIdentity Identity { get; private set; }
        public BaseView()
        {
            Identity = Thread.CurrentPrincipal.Identity as UserIdentity;
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }

    }
}