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
        public UserInfo UserInfo { get; set; }


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

        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            if (UserInfo == null)
            {
                var userGuid = Request.Cookies["LoginGuid"].Value;
                UserInfo = (UserInfo)CacheHelper.GetCache(userGuid.ToStr());
            }
        }
    }
}