using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KiaserMid
{
    public class ServiceLocator
    {
        private static Dictionary<string, object> _serviceDict = new Dictionary<string, object>();

        private static IContainer _container;

        /// <summary>
        /// 设置IOC容器
        /// </summary>
        /// <param name="container"></param>
        public static void SetContainer(IContainer container)
        {
            _container = container;
        }

        /// <summary>
        /// 获取IOC容器
        /// </summary>
        /// <returns></returns>
        public static IContainer GetContainer()
        {
            return _container;
        }

        //public static TService GetService<TService>()
        //{
        //    return _container.Resolve<TService>();
        //}

        /// <summary>
        /// 根据serviceName获取Service，不区分大小写
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        public static TService GetServiceByName<TService>(string serviceName)
        {
            serviceName = serviceName.ToLower();
            if (_serviceDict.ContainsKey(serviceName))
            {
                return (TService)_serviceDict[serviceName];
            }
            lock (serviceName)
            {
                if (_serviceDict.ContainsKey(serviceName))
                {
                    return (TService)_serviceDict[serviceName];
                }
                var list = AutofacDependencyResolver.Current.GetServices(typeof(TService));
                if (list.Count() == 0)
                {
                    throw new NullReferenceException(); ;
                }
                foreach (var item in list)
                {
                    Type type = item.GetType();
                    Attribute sa = type.GetCustomAttribute(typeof(ServiceAttribute));
                    if (sa != null)
                    {
                        if (((ServiceAttribute)sa).Name.ToLower() == serviceName.ToLower())
                        {
                            _serviceDict.Add(serviceName, item);
                            return (TService)item;
                        }
                    }
                }
                _serviceDict.Add(serviceName, list.ElementAt(0));
                return (TService)list.ElementAt(0);
            }
        }
    }
}
