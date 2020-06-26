using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiaserModel.EntityModel
{
    public class Student
    {
        public string Id { get; set; }
        public string SUserCode { get; set; }
        public string SName { get; set; }
        public string ClassId { get; set; }
        public int Sex { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
