using DokanDar.Domain.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokanDar.Application.IServices.AuthServices
{
    public interface IAuthenticationService
    {
        Task<bool> UserLogin(LoginModel user);
        Task<bool> UserRegister(RegisterModel user);
        Task<bool> UserFindByEmail(string mail);
        Task<bool> UserFindByUsername(string username);
        string GenerateJwtToken(LoginModel user);
    }
}
