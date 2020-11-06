using KiaserMid;
using KiaserModel.ViewModel;
using KiaserWeb.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KiaserWeb.Controllers
{
    public class AccountController : Controller
    {
        // GET: Login
        //[AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        //[AllowAnonymous]
        [Authorize]
        public JsonResult Login(UserInfo userInfo)
        {
            //数据库查询用户名和密码
            //。。。。
            //将数据存入缓存中
            if (userInfo.UserCode=="12345")
            {

                var aa = User.Identity.Name;

                var cookieKey = Guid.NewGuid().ToString();
                Request.Cookies["LoginGuid"].Value = cookieKey;
                //当前用户存入Cache缓存中
                CacheHelper.SetCacheDateTime(cookieKey, userInfo, 20 * 60);
            }
            return Json("Ok");
        }
    }
}