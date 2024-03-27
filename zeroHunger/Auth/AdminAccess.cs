using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using zeroHunger.EF;

namespace zeroHunger.Auth
{
    public class AdminAccess : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["user"] != null)
            {
                var user = (Login)httpContext.Session["user"];
                if (user.type.Equals("Admin"))
                {
                    return true;
                }
            }
            return false;
        }
    }
}