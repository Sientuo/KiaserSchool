using KiaserMid;
using KiaserModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KiaserWeb.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// 是否验证
        /// </summary>
        public bool Checked { get; set; }

        /// <summary>
        /// 用户类型
        /// </summary>
        public UserInfo UserInfo { get; set; }


        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (Checked)
            {
                var userGuid = Request.Cookies["LoginGuid"];
                if (userGuid == null)
                {
                    //为空,则跳转到登陆
                    filterContext.HttpContext.Response.Redirect("/Login/Index");
                    return;
                }
                //获取当前用户信息
                var userInfo = (UserInfo)CacheHelper.GetCache(userGuid.ToStr());
                if (UserInfo == null)
                {
                    //用户长时间未操作,则跳转到登陆
                    filterContext.HttpContext.Response.Redirect("/Login/Index");
                    return;
                }
                //重新写入缓存时间
                CacheHelper.SetCacheDateTime(userGuid.ToStr(), UserInfo, 20 * 60);
            }
        }

    }
}