using QLNVSSV.Client.Model;
using QLNVSSV.DATA.Interfaces;
using QLNVSSV.DATA.Paging;
using QLNVSSV.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QLNVSSV.DATA.Repository
{
    public class BaseRepository<T> : IBaseRepository<T>
    {
        protected readonly IDatabaseContext<T> _databaseContext;
        public BaseRepository(IDatabaseContext<T> databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public int Delete(object id)
        {
            return _databaseContext.DeleteById(id);
        }

        public IEnumerable<T> Get()
        {
            return _databaseContext.Get();
        }

        public T GetById(int id)
        {
            return _databaseContext.GetById(id);
        }

        public IEnumerable<T> GetByProc(string proc, object[] obj = null)
        {
            return _databaseContext.Get(proc, obj);
        }

        public ServiceResponse GetCountRecord()
        {
            var serviceResponse = new ServiceResponse();
            serviceResponse.Success = true;
            serviceResponse.Msg.Add("Thành công");
            serviceResponse.Data = _databaseContext.GetCountRecord();
            return serviceResponse;
        }

        public virtual PagedList<T> GetPaged(PageParameters parameters)
        {
            var data =  _databaseContext.Get();
            return PagedList<T>.ToPagedList(data, parameters.PageNumber, parameters.pageSize);
        }

        public IEnumerable<T> GetPaging(int pageindex, int pagesize)
        {
            return _databaseContext.GetPageing(pageindex, pagesize);
        }

        public ServiceResponse Insert(T entity)
        {
            var result = _databaseContext.Insert(entity);
            var serviceResponse = new ServiceResponse();
            if (result > 0)
            {
                serviceResponse.Success = false;
                serviceResponse.Msg.Add("Thất Bại");
                serviceResponse.Data = _databaseContext.Insert(entity);
            }
            else
            {
                serviceResponse.Success = true;
                serviceResponse.Msg.Add("Thành Công");
                serviceResponse.Data = _databaseContext.Insert(entity);
            }
            
            return serviceResponse;
            
        }

        public ServiceResponse Update(T entity)
        {
            var serviceResponse = new ServiceResponse();

            var result = _databaseContext.Update(entity);

            if (result > 0)
            {
                serviceResponse.Success = true;
                serviceResponse.Msg.Add("Thành công");
            }
            else
            {
                serviceResponse.Success = true;
                serviceResponse.Msg.Add("Thất bại");
            }
            return serviceResponse;
        }

        public ServiceResponse Update(string storeName, object[] obj = null)
        {
            var serviceResponse = new ServiceResponse();
            serviceResponse.Success = true;
            serviceResponse.Msg.Add("Thành công");
            serviceResponse.Data = _databaseContext.Update(storeName,obj);
            return serviceResponse;
        }
    }
}
