using KiaserModel.EntityModel;
using KiaserModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiaserIBLL
{
    public interface IMenuBLL:IBaseBLL<Menu>
    {
        IQueryable<MenuTreeModel> GetDefaultMenuTree();
    }
}
