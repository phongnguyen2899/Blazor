using QLNVSSV.Models.AuthenModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLNVSSV.DATA.Systems.User
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model, string ip);
        AuthenticateResponse RefreshToken(string token, string ip);
        bool RevokeToken(string token, string ipAddress);
        // get user
    }
}
