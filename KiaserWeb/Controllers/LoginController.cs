using KiaserMid;
using KiaserModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KiaserWeb.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult Login(UserInfo model)
        {
            //验证用户名-密码
            if (model != null && !string.IsNullOrEmpty(model.UserName) && !string.IsNullOrEmpty(model.PassWord))
            {
                //数据库查询用户名和密码
                //。。。。
                //将数据存入缓存中
                var cookieKey = Guid.NewGuid().ToString();
                Response.Cookies["LoginGuid"].Value = cookieKey;
                //当前用户存入Cache缓存中
                CacheHelper.SetCacheDateTime(cookieKey, model, 20 * 60);

            }
            return Json("Ok");

        }
    }
}