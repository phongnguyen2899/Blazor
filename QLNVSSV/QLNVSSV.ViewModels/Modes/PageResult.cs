using System.Collections.Generic;

namespace QLNVSSV.Models.Modes
{
    public class PageResult<T>
    {
        public IEnumerable<T> Data;
        public int pageSize { get; set; }
        public int pageIndex { get; set; }
    }
}
