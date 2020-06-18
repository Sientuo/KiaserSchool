using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiaserModel.ViewModel
{
    public class SearchBase
    {
        private string _sidx;
        /// <summary>
        /// 排序字段
        /// </summary>
        public string Sidx
        {
            get { return string.IsNullOrEmpty(_sidx) ? "CreateDate" : _sidx; }
            set { _sidx = value; }
        }
        private string _sord;
        /// <summary>
        /// 排序方式asc or desc
        /// </summary>
        public string Sord
        {
            get { return string.IsNullOrEmpty(_sord) ? "desc" : _sord; }
            set { _sord = value; }
        }
        private int _pageIndex;

        public int PageIndex
        {
            get
            {
                return _pageIndex < 1 ? 1 : _pageIndex;
            }
            set { _pageIndex = value; }
        }

        private int _pageSize;

        public int PageSize
        {
            get { return _pageSize < 1 ? 10 : _pageSize; }
            set { _pageSize = value; }
        }

        public int StartIndex { get; set; }

        public int EndIndex { get; set; }

        public string Keyword { get; set; }

        public int TotalPage { get; set; }

        public int TotalCount { get; set; }

        public void SetPageInfo()
        {
            TotalPage = (int)Math.Ceiling((float)TotalCount / PageSize);
        }

        public void SetPageIndex()
        {
            StartIndex = (PageIndex - 1) * PageSize + 1;
            EndIndex = PageIndex * PageSize;
        }
    }
}
