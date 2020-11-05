using KiaserIBLL;
using KiaserIDLL;
using KiaserMid;
using KiaserModel.EntityModel;
using KiaserModel.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KiaserWeb.Controllers
{
    public class HomeController : BaseController
    {
        public IStudentBLL StuBLL { set; get; }
        public IMenuBLL MenuBLL { set; get; }
        public HomeController(IStudentBLL bLL,IMenuBLL menuBLL)
        {
            StuBLL = bLL;
            MenuBLL = menuBLL;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GerStudentListData(Search search)
        {
            var model = new StudentGridModel
            {
                Searchs = search
            };
            var bol = search.Sord == "ascending";
            model.Searchs.SetPageIndex();
            model.Students = StuBLL.GetStudentListBy(c =>true, c => c.SUserCode,bol, model.Searchs.StartIndex, model.Searchs.PageSize, out int tolCount).ToList();
            model.Searchs.TotalCount = tolCount;
            model.Searchs.SetPageInfo();
            return Json(model);
        }

        //查询菜单
        public JsonResult GetTreeData()
        {
            var data = MenuBLL.GetDefaultMenuTree();
            return Json(data);
        }
    }
}