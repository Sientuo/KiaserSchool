using KiaserIBLL;
using KiaserIDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KiaserBLL
{
    public class BaseBLL<T> : IBaseBLL<T> where T : class, new()
    {
        protected IBaseDLL<T> BaseDLL = null;

        public int Add(T model)
        {
            return BaseDLL.Add(model);
        }

        public int Add(List<T> lis)
        {
            return BaseDLL.Add(lis);
        }

        public int Del(T model)
        {
            return BaseDLL.Del(model);
        }

        public int DelMulBy(Expression<Func<T, bool>> delWhere)
        {
            return BaseDLL.DelMulBy(delWhere);
        }

        public int DelMulList(IQueryable<T> lis)
        {
            return BaseDLL.DelMulList(lis);
        }

        public IQueryable<T> GetListBy(Expression<Func<T, bool>> lambda)
        {
            return BaseDLL.GetListBy(lambda);
        }

        public IQueryable<T> GetListBy<TKey>(Expression<Func<T, bool>> lambda, Expression<Func<T, TKey>> orderLambda,bool isAsc, int startIndex, int pageSize,out int count)
        {
            return BaseDLL.GetListBy(lambda, orderLambda, isAsc, startIndex, pageSize, out count);
        }

        public T GetOneEntity(Expression<Func<T, bool>> lambda)
        {
            return BaseDLL.GetOneEntity(lambda);
        }

        public int Modify(T model, params string[] proNames)
        {
            return BaseDLL.Modify(model,proNames);
        }

        public int ModifyBy(T model, Expression<Func<T, bool>> whereLambda, params string[] modifiedProNames)
        {
            return BaseDLL.ModifyBy(model, whereLambda, modifiedProNames);
        }
    }
}
