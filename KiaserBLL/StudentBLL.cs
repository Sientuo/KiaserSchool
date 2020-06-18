using KiaserIBLL;
using KiaserIDLL;
using KiaserModel.EntityModel;
using KiaserModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KiaserBLL
{
    public class StudentBLL:BaseBLL<Student>, IStudentBLL
    {
         IStudentDLL StuDLL { set; get; }
        public StudentBLL(IStudentDLL dLL)
        {
            BaseDLL = dLL;
            StuDLL = dLL;
        }

        public IQueryable<StudentEditModel> GetStudentListBy<TKey>(Expression<Func<StudentEditModel, bool>> lambda, Expression<Func<StudentEditModel, TKey>> orderLambda, bool isAsc, int startIndex, int pageSize, out int tolCount)
        {
            return StuDLL.GetStudentListBy(lambda, orderLambda, isAsc, startIndex, pageSize, out tolCount);
        }
    }
}
