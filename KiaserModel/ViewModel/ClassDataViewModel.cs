using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiaserModel.ViewModel
{
    public class ClassDataViewModel
    {
        public string Id { get; set; }
        public string ClassName { get; set; }
        public string TeacherId { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
    }

    public class ClassDataEditModel
    {
        public string Id { get; set; }
        public string ClassName { get; set; }
        public string TeacherId { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
