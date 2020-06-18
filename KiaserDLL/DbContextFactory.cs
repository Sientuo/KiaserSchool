using KiaserModel.EntityModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace KiaserDLL
{
    public class DbContextFactory
    {
        public static DbContext Create()
        {
            if (!(CallContext.GetData("DbContext") is DbContext dbContext))
            {
                dbContext = new KiaserDbContext();
                CallContext.SetData("DbContext", dbContext);
            }
            return dbContext;

        }
    }
}
