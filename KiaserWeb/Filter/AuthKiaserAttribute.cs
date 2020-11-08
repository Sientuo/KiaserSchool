using KiaserMid;
using KiaserModel.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace KiaserWeb.Filter
{
    public class AuthKiaserAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            bool isAllowAnonymous = filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), inherit: true);
            if (!isAllowAnonymous)
            {
                if (!HttpContext.Current.User.Identity.IsAuthenticated) 
                {
                    //过期，重定向首页
                    filterContext.HttpContext.Response.Redirect("/Account/Index");
                    return;
                }
                else
                {
                    HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                    authCookie.Expires = DateTime.Now.AddMinutes(20);
                }
            }
        }
    }
}