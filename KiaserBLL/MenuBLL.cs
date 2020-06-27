using KiaserIBLL;
using KiaserIDLL;
using KiaserModel.EntityModel;
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
        public void GetDefaultMenuTree()
        {
           
        }
    }
}
