using KiaserModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KiaserWeb.Filter
{
    public class ExceptionAttribute: HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            // 判断是否已经处理过异常
            if (!filterContext.ExceptionHandled)
            {
                // 获取出现异常的controller和action名称，用于记录
                string strControllerName = filterContext.RouteData.Values["controller"].ToString();
                string strActionName = filterContext.RouteData.Values["action"].ToString();
                // 定义一个HandleErrorInfo,用于Error视图展示异常信息
                HandleErrorInfo info = new HandleErrorInfo(filterContext.Exception, strControllerName, strActionName);
                //var respon = new ResponseModel { Code = -1, Data = null };
                //ViewResult result = new ViewResult
                //{
                //    ViewName = View,
                //    // 定义ViewData，泛型
                //    //ViewData = new ViewDataDictionary<HandleErrorInfo>(info)
                //    ViewData = new ViewDataDictionary<ResponseModel>(respon)
                //};

                filterContext.Result = new JsonResult
                {
                    Data = new ResponseModel { Code = -1, Msg = filterContext.Exception.Message, Data = null },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
                var bol = filterContext.HttpContext.Request.IsAjaxRequest();
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    // 设置已经处理过异常
                    filterContext.ExceptionHandled = true;                   
                }
                else
                {
                    base.OnException(filterContext);
                }
            }
        }
    }
}