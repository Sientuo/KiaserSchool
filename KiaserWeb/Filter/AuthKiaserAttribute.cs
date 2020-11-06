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
    //public class AuthKiaserAttribute: AuthorizeAttribute
    //{
    //    public override void OnAuthorization(AuthorizationContext filterContext)
    //    {

    //        base.OnAuthorization(filterContext);
    //        bool isAllowAnonymous = filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), inherit: true);

    //        if (!isAllowAnonymous)
    //        {
    //            //验证缓存
    //            var userGuid = filterContext.HttpContext.Request.Cookies["LoginGuid"].Value;
    //            if (userGuid == null)
    //            {
    //                //为空,则跳转到登陆
    //                //filterContext.Result = new RedirectResult();
    //                filterContext.HttpContext.Response.Redirect("/Account/Index");
    //                return;
    //            }
    //            //获取当前用户信息
    //            var userInfo = (UserInfo)CacheHelper.GetCache(userGuid.ToStr());
    //            if (userInfo == null)
    //            {
    //                //用户长时间未操作,则跳转到登陆
    //                filterContext.HttpContext.Response.Redirect("/Account/Index");
    //                return;
    //            }
    //            //重新写入缓存时间
    //            CacheHelper.SetCacheDateTime(userGuid.ToStr(), userInfo, 20 * 60);
    //        }
    //    }
    //}
}