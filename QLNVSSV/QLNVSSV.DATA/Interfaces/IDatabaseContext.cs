using System.Collections.Generic;
using System.Reflection;

namespace QLNVSSV.DATA.Interfaces
{
    public interface IDatabaseContext<T>
    {
        /// <summary>
        /// Get all
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> Get();

        /// <summary>
        /// Get by store Name
        /// </summary>
        /// <param name="storeName"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        IEnumerable<T> Get(string storeName,object[] obj=null);

        /// <summary>
        /// Get 
        /// </summary>
        /// <param name="storeName"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        object Get(string storeName, string code);
        /// <summary>
        /// Get by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(object id);
        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Insert(T entity);
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Update(T entity);
        /// <summary>
        /// Delete by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteById(object id);


        /// <summary>
        /// Lay tong ban ghi
        /// </summary>
        /// <returns></returns>
        int GetCountRecord();
        /// <summary>
        /// phan trang
        /// </summary>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        IEnumerable<T> GetPageing(int pageindex, int pagesize);
        /// <summary>
        /// update by proc
        /// </summary>
        /// <param name="storeName"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        int Update(string storeName, object[] obj = null);

        T GetByIdProc(string storeName, object[] obj = null);
    }
}
