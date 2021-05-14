using QLNVSSV.Client.Model;
using QLNVSSV.DATA.Paging;
using QLNVSSV.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QLNVSSV.DATA.Interfaces
{
    public interface IBaseRepository<T>
    {
        IEnumerable<T>  Get();

        T GetById(int id );

        ServiceResponse Insert(T entity);

        ServiceResponse Update(T entity);

        int Delete(object id);

        ServiceResponse GetCountRecord();

        IEnumerable<T> GetPaging(int pageindex, int pagesize);

        IEnumerable<T> GetByProc(string proc,object[] obj=null);

        ServiceResponse Update(string storeName,object[] obj=null);

        PagedList<T> GetPaged(PageParameters parameters);
    }
}
