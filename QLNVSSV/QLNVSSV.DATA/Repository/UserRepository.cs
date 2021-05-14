using QLNVSSV.DATA.Interfaces;
using QLNVSSV.Models.Modes;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLNVSSV.DATA.Repository
{
    public class UserRepository:BaseRepository<User>,IUserRepository
    {
        public UserRepository(IDatabaseContext<User> databaseContext) : base(databaseContext)
        {

        }

        public User Login(string username, string password)
        {
            var user = base._databaseContext.GetByIdProc("Proc_CheckLogin @username , @password ", new object[] { username, password });
            return user;
        }
    }
}
