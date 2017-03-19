using LoowooTech.Faith.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoowooTech.Faith.Common
{
    public class UserAuthorizeAttribute:AuthorizeAttribute
    {  
        private UserRole _role { get; set; }
        private bool _enable { get; set; }
        public UserAuthorizeAttribute(bool enable = true)
        {
            _enable = enable;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return httpContext.User.Identity.IsAuthenticated;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (_enable)
            {
                var returnUrl = filterContext.HttpContext.Request.Url.AbsoluteUri;
                filterContext.HttpContext.Response.Redirect("/user/login?returnUrl=" + HttpUtility.UrlEncode(returnUrl));
            }
        }
    }
}