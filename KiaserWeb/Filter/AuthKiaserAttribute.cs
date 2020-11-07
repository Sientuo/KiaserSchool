using KiaserMid;
using KiaserModel.ViewModel;
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
            //base.OnAuthorization(filterContext);
            bool isAllowAnonymous = filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), inherit: true);
            if (!isAllowAnonymous)
            {
                string cookieName = FormsAuthentication.FormsCookieName;
                HttpCookie authCookie = HttpContext.Current.Request.Cookies[cookieName];
                if (authCookie == null)
                {
                    //过期，重定向首页
                    filterContext.HttpContext.Response.Redirect("/Account/Index");
                    return;
                }
                //延长过期时间
                authCookie.Expires = DateTime.Now.AddMinutes(20);
                
                //var authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                //var name = HttpContext.Current.User.Identity.Name;
                //var data = authTicket.UserData;
            }
        }
    }
}