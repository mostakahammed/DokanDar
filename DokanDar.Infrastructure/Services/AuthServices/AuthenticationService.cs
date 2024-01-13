using DokanDar.Application.IServices.AuthServices;
using DokanDar.Domain.DBModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DokanDar.Infrastructure.Services.AuthServices
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthenticationService(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<bool> UserLogin(LoginModel user)
        {
            var identityUser = await _userManager.FindByNameAsync(user.UserName);
            if (identityUser == null)
                return false;
            return await _userManager.CheckPasswordAsync(identityUser, user.Password);
        }

        public async Task<bool> UserRegister(RegisterModel user)
        {
            var identityUser = new IdentityUser
            {
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };

            var result = await _userManager.CreateAsync(identityUser, user.Password);
            return result.Succeeded;
        }

        public async Task<bool> UserFindByEmail(string mail)
        {
            IdentityUser? user = await _userManager.FindByEmailAsync(mail);
            return user == null ? false : true;
        }

        public async Task<bool> UserFindByUsername(string username)
        {
            IdentityUser? user = await _userManager.FindByNameAsync(username);
            return user == null ? false : true;
        }

        public string GenerateJwtToken(LoginModel user)
        {
            List<Claim> claims = new List<Claim> 
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, "Admin")
            };
            var key = _configuration.GetSection("Jwt:Key").Value;
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var signingCred = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha512Signature);

            var securityToken = new JwtSecurityToken
                (
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(60),
                    issuer: _configuration.GetSection("Jwt:Issuer").Value,
                    audience: _configuration.GetSection("Jwt:Audience").Value,
                    signingCredentials: signingCred
                );
            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return token;
        }
    }
}
