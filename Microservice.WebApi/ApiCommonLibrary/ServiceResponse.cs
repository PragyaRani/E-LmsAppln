using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ApiCommonLibrary.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ApiCommonLibrary
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    } 

    public class TokenInfo
    {
        public TokenInfo() { }
        public string CreateToken(UserResponse user, string jwtToken)
        {
           
            List<Claim> claims = new List<Claim>{
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };
            SymmetricSecurityKey key = new SymmetricSecurityKey
                (System.Text.Encoding.UTF8.GetBytes(jwtToken));
            SigningCredentials creds = new SigningCredentials
                (key, SecurityAlgorithms.HmacSha512Signature);
            SecurityTokenDescriptor desc = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(desc);
            return tokenHandler.WriteToken(token);

        }
    }


}
