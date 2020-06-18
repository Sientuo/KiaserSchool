using KiaserIDLL;
using KiaserMid;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KiaserDLL
{
    public class BaseDLL<T> : IBaseDLL<T> where T : class, new()
    {
        public DbContext db = DbContextFactory.Create();
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(T model)
        {
            try
            {
                db.Set<T>().Add(model);
                return db.SaveChanges();
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex.Message + "--" + ex.StackTrace);
                return -1;
            }
        }

        /// <summary>
        /// 批量添加数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listModel"></param>
        /// <returns></returns>
        public int Add(List<T> listModel)
        {
            listModel.ForEach(i =>
            {
                db.Set<T>().Add(i);
            });
            return db.SaveChanges();
        }

        /// <summary>
        /// 删除数据  实体需包含主键Id
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Del(T model)
        {
            try
            {
                db.Set<T>().Attach(model);
                db.Set<T>().Remove(model);
                return db.SaveChanges();
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex.Message + "--" + ex.StackTrace);
                return -1;
            }


        }

        /// <summary>
        /// 删除多笔数据-条件
        /// </summary>
        /// <param name="delWhere"></param>
        /// <returns></returns>
        public int DelMulBy(Expression<Func<T, bool>> delWhere)
        {
            try
            {
                //3.1查询要删除的数据
                List<T> listDeleting = db.Set<T>().Where(delWhere).ToList();
                //3.2将要删除的数据 用删除方法添加到 EF 容器中
                listDeleting.ForEach(u =>
                {
                    db.Set<T>().Attach(u);//先附加到 EF容器
                    db.Set<T>().Remove(u);//标识为 删除 状态
                });
                //3.3一次性 生成sql语句到数据库执行删除
                return db.SaveChanges();
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex.Message + "--" + ex.StackTrace);
                return -1;
            }


        }

        /// <summary>
        /// 删除多笔数据 -集合
        /// </summary>
        /// <param name="lis"></param>
        /// <returns></returns>
        public int DelMulList(IQueryable<T> lis)
        {
            try
            {
                foreach (var item in lis)
                {
                    db.Set<T>().Attach(item);//先附加到 EF容器
                    db.Set<T>().Remove(item);//标识为 删除 状态
                }
                return db.SaveChanges();

            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex.Message + "---" + ex.StackTrace);
                return -1;
            }
        }

        /// <summary>
        /// 查询一笔数据
        /// </summary>
        /// <param name="lambda"></param>
        /// <returns></returns>
        public T GetOneEntity(Expression<Func<T, bool>> lambda)
        {
            return db.Set<T>().Where(lambda).FirstOrDefault();
        }


        /// <summary>
        /// 查询多笔数据+条件
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public IQueryable<T> GetListBy(Expression<Func<T, bool>> lambda)
        {
            return db.Set<T>().Where(lambda);
        }

        /// <summary>
        /// 查询多笔数据 条件+排序
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="whereLambda"></param>
        /// <param name="orderLambda"></param>
        /// <returns></returns>
        public IQueryable<T> GetListBy<TKey>(Expression<Func<T, bool>> lambda, Expression<Func<T, TKey>> orderLambda,bool isAsc, int startIndex, int pageSize,out int tolCount)
        {
            var data = db.Set<T>().Where(lambda);
            tolCount = data.Count();
            if (isAsc)
            {
                return data.OrderBy(orderLambda).Skip(startIndex).Take(pageSize).AsNoTracking();
            }
            return data.OrderByDescending(orderLambda).Skip(startIndex).Take(pageSize).AsNoTracking();
        }

        /// <summary>
        /// 修改一笔数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="proNames"></param>
        /// <returns></returns>
        public int Modify(T model, params string[] proNames)
        {
            //4.1将 对象 添加到 EF中
            DbEntityEntry entry = db.Entry<T>(model);
            //4.2先设置 对象的包装 状态为 Unchanged
            entry.State = EntityState.Unchanged;
            //4.3循环 被修改的属性名 数组
            foreach (string proName in proNames)
            {
                //4.4将每个 被修改的属性的状态 设置为已修改状态;后面生成update语句时，就只为已修改的属性 更新
                entry.Property(proName).IsModified = true;
            }
            //4.4一次性 生成sql语句到数据库执行
            return db.SaveChanges();
        }


        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="model">要修改的实体对象</param>
        /// <param name="whereLambda">查询条件</param>
        /// <param name="modifiedProNames">要修改的 属性 名称</param>
        /// <returns></returns>
        public int ModifyBy(T model, Expression<Func<T, bool>> whereLambda, params string[] modifiedProNames)
        {
            //4.1查询要修改的数据
            List<T> listModifing = db.Set<T>().Where(whereLambda).ToList();
            //获取 实体类 类型对象
            Type t = typeof(T); // model.GetType();
            //获取 实体类 所有的 公有属性
            List<PropertyInfo> proInfos = t.GetProperties(BindingFlags.Instance | BindingFlags.Public).ToList();
            //创建 实体属性 字典集合
            Dictionary<string, PropertyInfo> dictPros = new Dictionary<string, PropertyInfo>();
            //将 实体属性 中要修改的属性名 添加到 字典集合中 键：属性名  值：属性对象
            proInfos.ForEach(p =>
            {
                if (modifiedProNames.Contains(p.Name))
                {
                    dictPros.Add(p.Name, p);
                }
            });
            //4.3循环 要修改的属性名
            foreach (string proName in modifiedProNames)
            {
                //判断 要修改的属性名是否在 实体类的属性集合中存在
                if (dictPros.ContainsKey(proName))
                {
                    //如果存在，则取出要修改的 属性对象
                    PropertyInfo proInfo = dictPros[proName];
                    //取出 要修改的值
                    object newValue = proInfo.GetValue(model, null); //object newValue = model.uName;
                    //4.4批量设置 要修改 对象的 属性
                    foreach (T usrO in listModifing)
                    {
                        //为 要修改的对象 的 要修改的属性 设置新的值
                        proInfo.SetValue(usrO, newValue, null); //usrO.uName = newValue;
                    }
                }
            }
            //4.4一次性 生成sql语句到数据库执行
            return db.SaveChanges();
        }
    }
}
