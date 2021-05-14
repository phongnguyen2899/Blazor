
using QLNVSSV.Client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLNVSSV.DATA.Paging
{
    public class PagedList<T>:List<T>
    {
        public MetaData MetaData { get; set; }

        public PagedList(List<T> items,int count,int pageNumber,int pageSize)
        {
            MetaData = new MetaData()
            {
                TotalRecord = items.Count,
                PageSize=pageSize,
                CurrentPage=pageNumber,
                TotalPage = (int)Math.Ceiling(count / (double)pageSize)
            };

            AddRange(items);
        }

        public static PagedList<T> ToPagedList(IEnumerable<T> source,int pageNumber,int pageSize)
        {
            var count = source.Count();
            //lay ra danh sach tra ve tren 1 page
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
