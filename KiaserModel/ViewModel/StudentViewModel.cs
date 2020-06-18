using System;
using System.Collections.Generic;

namespace KiaserModel.ViewModel
{
    public class StudentViewModel
    {
        public string id { get; set; }
        public string SUserCode { get; set; }
        public string SName { get; set; }
        public string ClassId { get; set; }
        public int Sex { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
    }

    public class StudentEditModel
    {
        public string id { get; set; }
        public string SUserCode { get; set; }
        public string SName { get; set; }
        public string ClassId { get; set; }
        public int Sex { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }

        public string ClassName { get; set; }
    }

    public class StudentGridModel
    {
        public List<StudentEditModel> Students { set; get; }

        public Search Searchs { set; get; }
    }

    public class Search : SearchBase
    {
        public string SName { get; set; }

        public string SUserCode { get; set; }
    }
}
