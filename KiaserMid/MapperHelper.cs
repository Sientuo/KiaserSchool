using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiaserMid
{
    public class MapperHelper<T,U> where T:class where U:class
    {
        public static U AutoMapper(T t)
        {
            try
            {
                Mapper.Initialize(x => x.CreateMap<T, U>());
                return Mapper.Map<U>(t);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex.Message + "---" + ex.StackTrace);
                return null;
            }
        }

        public static List<U> AutoMapperList(List<T> t)
        {
            try
            {
                Mapper.Initialize(x => x.CreateMap<T, U>());
                return Mapper.Map<List<U>>(t);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex.Message + "---" + ex.StackTrace);
                return null;
            }
        }
    }
}
