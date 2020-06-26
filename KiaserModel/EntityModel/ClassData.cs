using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiaserModel.EntityModel
{
    public class ClassData
    {
        public string Id { get; set; }
        public string ClassName { get; set; }
        public string TeacherId { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
