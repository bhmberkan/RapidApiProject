using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WebApiJwt.Models
{
    public class CreateToken
    {
        public string TokenCreate()
        {
            var bytes = Encoding.UTF8.GetBytes("aspnetcoreapiapi");
            SymmetricSecurityKey key = new SymmetricSecurityKey(bytes);
            SigningCredentials credentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            JwtSecurityToken token = new JwtSecurityToken(issuer:"http://localhost",audience:"http://localhost",notBefore:DateTime.Now,expires:DateTime.Now.AddSeconds(30),signingCredentials:credentials);
            // issuer = tokeni oluşturan 
            // audience = bu tokkeni kullanacak olan hedef sistem veya kullanıcı grubunu belirtir.
            // notbefore = tokenin geçerli olmaya başlayacağı zamanı belirler.
            // expires = bu tokenin ne kadar zaman geçerli olacağını belirtir.
            // signingCredentials = bu tokeni imzalamak için kullanılacak güvenlik kimlik bilgilerini belirtir.
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
           return handler.WriteToken(token);
        }

        public string TokenCreateAdmin()
        {
            var bytes = Encoding.UTF8.GetBytes("aspnetcoreapiapi");
            SymmetricSecurityKey key = new SymmetricSecurityKey(bytes);
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role,"Admin"),
                new Claim(ClaimTypes.Role,"Visitor")
            };
            JwtSecurityToken token = new JwtSecurityToken(issuer:"http://localhost",audience:"http://localhost",notBefore:DateTime.Now,expires:DateTime.Now.AddSeconds(30),signingCredentials:credentials,claims:claims);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(token);
            
        }
    }
}
