using CoreApiResponse;
using DokanDar.Application.IServices.AuthServices;
using DokanDar.Domain.DBModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DokanDar.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthenticationController : BaseController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isUserNameExist = await _authenticationService.UserFindByUsername(user.UserName);
                    if (isUserNameExist == false)
                        return CustomResult("You are not a registered user.", isUserNameExist, HttpStatusCode.NotFound);
                    else
                    {
                        var result = await _authenticationService.UserLogin(user);
                        if (result == true)
                        {
                            string token = _authenticationService.GenerateJwtToken(user);
                            return CustomResult("Login Successful", token, HttpStatusCode.OK);
                        }
                            
                        else
                            return CustomResult("Password is incorrect", result, HttpStatusCode.BadRequest);
                    }
                }
                else
                    return CustomResult("Modelstate is not valid", HttpStatusCode.BadRequest);
            }
            catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.InternalServerError);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel user)
        {
            try
            {
                var isUserNameExist = await _authenticationService.UserFindByUsername(user.UserName);
                if (isUserNameExist == true)
                    return CustomResult("Username already taken. Use Another username", HttpStatusCode.BadRequest);

                var isEmailExist = await _authenticationService.UserFindByEmail(user.Email);
                if (isEmailExist == true)
                    return CustomResult("Email already used. User Another Email", HttpStatusCode.BadRequest);

                var result = await _authenticationService.UserRegister(user);

                if (result == true)
                    return CustomResult("New user created successfully", result, HttpStatusCode.Created);
                else
                    return CustomResult("User create failed", result, HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.InternalServerError);
            }
        }
    }
}
