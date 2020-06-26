using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiaserModel.EntityModel
{
    public class Menu
    {
        public int Id { get; set; }
        public string MenuCode { get; set; }

        public string MenuName { get; set; }

        public string PId { get; set; }

        public string MenuUrl { get; set; }

        public string Remark { get; set; }

        public DateTime?  CreateDate { get; set; }

        public string CreateBy { get; set; }

        public DateTime? ModifyDate { get; set; }

        public string ModifyBy { get; set; }

    }
}
