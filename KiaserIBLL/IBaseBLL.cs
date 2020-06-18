using KiaserMid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KiaserIBLL
{
    public interface IBaseBLL<T>: IDependency where T:class,new()
    {
        int Add(T model);

        int Add(List<T> lis);

        int Del(T model);

        int DelMulBy(Expression<Func<T, bool>> delWhere);

        int DelMulList(IQueryable<T> lis);

        T GetOneEntity(Expression<Func<T, bool>> lambda);

        IQueryable<T> GetListBy(Expression<Func<T, bool>> lambda);

        IQueryable<T> GetListBy<TKey>(Expression<Func<T, bool>> lambda, Expression<Func<T, TKey>> orderLambda,bool isAsc, int startIndex, int pageSize,out int tolCount);

        int Modify(T model, params string[] proNames);

        int ModifyBy(T model, Expression<Func<T, bool>> whereLambda, params string[] modifiedProNames);
    }
}
