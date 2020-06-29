using KiaserIBLL;
using KiaserIDLL;
using KiaserModel.EntityModel;
using KiaserModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiaserBLL
{
    public class MenuBLL:BaseBLL<Menu>,IMenuBLL
    {
        IMenuDLL MenuDLL { set; get; }
        public MenuBLL(IMenuDLL dLL)
        {
            BaseDLL = dLL;
            MenuDLL = dLL;
        }


        //查询菜单树
        public IQueryable<MenuTreeModel> GetDefaultMenuTree()
        {
            var data = MenuDLL.GetListBy(c => c != null).OrderBy(c => c.PId);
            if (data != null)
            {
                var temp = from b in data
                           select new MenuTreeModel
                           {
                               Id = b.Id,
                               MenuCode = b.MenuCode,
                               PId = b.PId,
                               MenuName = b.MenuName,
                               MenuUrl = b.MenuUrl
                           };
                return temp;
            }
            return null;
        }
    }
}
