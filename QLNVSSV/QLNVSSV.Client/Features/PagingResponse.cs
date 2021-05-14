using QLNVSSV.Client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLNVSSV.Client.Features
{
    public class PagingResponse<T>
    {
        public List<MetaData> MetaData { get; set; }
        public List<T> Items { get; set; }
    }
}
