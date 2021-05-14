using Microsoft.IdentityModel.Tokens;
using QLNVSSV.DATA.Interfaces;
using QLNVSSV.Models.AuthenModel;
using QLNVSSV.Models.Modes;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace QLNVSSV.DATA.Systems.User
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public AuthenticateResponse Authenticate(AuthenticateRequest model, string ip)
        {
            var user = _userRepository.Login(model.Username, model.Password);
            if (user.Id == 0)
            {
                return null;
            }
            var jwtToken = generateJwtToken(user);

            //create refresh token
            var refreshToken = generateRefreshToken(ip);

            return new QLNVSSV.Models.AuthenModel.AuthenticateResponse(user, jwtToken, refreshToken.Token);

        }

        public string generateJwtToken(QLNVSSV.Models.Modes.User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            //decode chuoi bi mat thanh dang bytes
            var key = Encoding.ASCII.GetBytes("this is my custom Secret key for authnetication");
            List<Claim> listRole = new List<Claim>();
            listRole.Add(new Claim(ClaimTypes.Name, user.Id.ToString()));

            //get role
            listRole.Add(new Claim(ClaimTypes.Role,"ADMIN"));



            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(listRole),

                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private RefreshToken generateRefreshToken(string ipAddress)
        {
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                var randomBytes = new byte[64];
                rngCryptoServiceProvider.GetBytes(randomBytes);
                return new RefreshToken
                {
                    Token = Convert.ToBase64String(randomBytes),
                    Expires = DateTime.UtcNow.AddDays(7),
                    Created = DateTime.UtcNow,
                    CreatedByIp = ipAddress
                };
            }
        }

        

        public bool RevokeToken(string token, string ipAddress)
        {
            throw new NotImplementedException();
        }

        public AuthenticateResponse RefreshToken(string token, string ip)
        {
            throw new NotImplementedException();
        }
    }
}
