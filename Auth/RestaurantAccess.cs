using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zeroHunger.EF;

namespace zeroHunger.Auth
{
    public class RestaurantAccess : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["user"] != null)
            {
                var user = (Login)httpContext.Session["user"];
                if (user.type.Equals("Restaurant"))
                {
                    return true;
                }
            }
            return false;
        }
    }
}