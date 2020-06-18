using KiaserIDLL;
using KiaserMid;
using KiaserModel.EntityModel;
using KiaserModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KiaserIBLL
{
    public interface IStudentBLL: IBaseBLL<Student>
    {
        IQueryable<StudentEditModel> GetStudentListBy<TKey>(Expression<Func<StudentEditModel, bool>> lambda, Expression<Func<StudentEditModel, TKey>> orderLambda, bool isAsc, int startIndex, int pageSize, out int tolCount);
    }
}
