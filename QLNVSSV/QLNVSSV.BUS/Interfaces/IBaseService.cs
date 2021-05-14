using QLNVSSV.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLNVSSV.BUS.Interfaces
{
    public interface IBaseService<T>
    {
        IEnumerable<T> Get();

        T GetById(int id);
        ServiceResponse Insert(T entity);
        ServiceResponse Update(T entity);
        int Delete(object id);
    }
}
