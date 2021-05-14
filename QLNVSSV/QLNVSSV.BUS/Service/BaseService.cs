using QLNVSSV.BUS.Interfaces;
using QLNVSSV.DATA.Interfaces;
using QLNVSSV.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLNVSSV.BUS.Service
{
    public class BaseService<T> : IBaseService<T>
    {
        protected IBaseRepository<T> _baseRepository;

        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public int Delete(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Get()
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
           return _baseRepository.GetById(id);
        }

        public ServiceResponse Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
