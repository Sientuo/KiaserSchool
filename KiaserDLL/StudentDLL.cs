using KiaserIDLL;
using KiaserModel.EntityModel;
using KiaserModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KiaserDLL
{
    public class StudentDLL:BaseDLL<Student>,IStudentDLL
    {
        /// <summary>
        /// 查询多笔数据 条件+排序
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="whereLambda"></param>
        /// <param name="orderLambda"></param>
        /// <returns></returns>
        public IQueryable<StudentEditModel> GetStudentListBy<TKey>(Expression<Func<StudentEditModel, bool>> lambda, Expression<Func<StudentEditModel, TKey>> orderLambda, bool isAsc, int startIndex, int pageSize, out int tolCount)
        {

            var data = from b in db.Set<Student>()
                       join c in db.Set<ClassData>() on b.ClassId equals c.id into kk
                       from k in kk.DefaultIfEmpty()
                       select new StudentEditModel
                       {
                           id = b.id,
                           SUserCode = b.SUserCode,
                           SName = b.SName,
                           Sex = b.Sex,
                           ClassName = k.ClassName,
                           CreateDate = b.CreateDate
                       };

            var da = data.Where(lambda);
            tolCount = da.Count();
            if (isAsc)
            {
                return da.OrderBy(orderLambda).Skip(startIndex).Take(pageSize).AsNoTracking();
            }
            return da.OrderByDescending(orderLambda).Skip(startIndex).Take(pageSize).AsNoTracking();
        }
    }
}
