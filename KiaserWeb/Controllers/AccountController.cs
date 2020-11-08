using KiaserIBLL;
using KiaserMid;
using KiaserModel.EntityModel;
using KiaserModel.ViewModel;
using KiaserWeb.Filter;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace KiaserWeb.Controllers
{
    public class AccountController : BaseController
    {
        public IStudentBLL StuBLL { set; get; }
        public AccountController(IStudentBLL bLL)
        {
            StuBLL = bLL;
        }


        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public JsonResult Login(UserInfo userInfo)
        {
            //数据库查询当天用户
            var user = StuBLL.GetOneEntity(c => c.SUserCode == userInfo.UserCode);
            if (user == null)
            {
                //密码错误
                return Json(new ResponseModel { Code = -1, Msg = "账号不存在" });
            }
            if (!user.SPassword.Equals(MD5Helper.GetMD5X2(userInfo.Password)))
            {
                //密码错误
                return Json(new ResponseModel { Code = -1, Msg = "密码错误" });
            }
            //构造用户信息
            user.SPassword = string.Empty; 
            var jsonUser = JsonConvert.SerializeObject(user);

            //签名存储用户信息
            FormsAuthentication.SetAuthCookie(userInfo.UserCode, false, FormsAuthentication.FormsCookiePath);
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(2, user.SUserCode, DateTime.Now, DateTime.Now.AddHours(2), false, jsonUser);
            string hashTicket = FormsAuthentication.Encrypt(ticket);
            HttpCookie httpCookie = new HttpCookie(FormsAuthentication.FormsCookieName, hashTicket)
            {
                Expires = DateTime.Now.AddMinutes(20)
            };
            HttpContext.Response.Cookies.Add(httpCookie);

            return Json(new ResponseModel { Code = 0, Msg = "登录成功" });
        }

        public ActionResult LogOut()
        {
            string strUserData = ((FormsIdentity)HttpContext.User.Identity).Ticket.UserData;
            FormsAuthentication.SignOut();
            return View("Index");
        } 
    }
}