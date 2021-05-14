using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLNVSSV.Client.Model
{
    public class MetaData
    {
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
        public int PageSize { get; set; }
        public int TotalRecord { get; set; }

        public bool HasPrev => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPage;
    }
}
