using QLNVSSV.Models.Modes;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLNVSSV.DATA.Interfaces
{
    public interface IUserRepository:IBaseRepository<User>
    {
        User Login(string username,string password);
    }
}
