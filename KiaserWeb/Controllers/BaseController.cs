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
    [AuthKiaser]
    public class BaseController : Controller
    {
        /// <summary>
        /// 是否验证
        /// </summary>
        public bool Checked { get; set; }

        /// <summary>
        /// 用户类型
        /// </summary>
        private Student _userInfo;
        public Student UserInfo {
            get
            {
                if (HttpContext.User.Identity.IsAuthenticated)
                {
                    _userInfo = JsonConvert.DeserializeObject<Student>(((FormsIdentity)User.Identity).Ticket.UserData);
                    //var authTicket = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value);
                    //_userInfo = JsonConvert.DeserializeObject<Student>(authTicket.UserData);
                }
                return _userInfo;
            }
        }


        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //base.OnActionExecuting(filterContext);
            var strError = string.Empty;
            if (filterContext.Controller.ViewData.ModelState.IsValid == false)
            {
                var keys = ModelState.Keys;
                foreach (var key in keys)
                {
                    foreach (var error in ModelState[key].Errors)
                    {
                        strError = error.ErrorMessage;
                        break;
                    }
                }
                filterContext.Result = new JsonResult
                {
                    Data = new ResponseModel { Code = -1, Msg = strError, Data = null },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
                return;
            }
        }
    }
}