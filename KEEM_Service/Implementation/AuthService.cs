using KEEM_DAL.Interfaces;
using KEEM_Domain.Entities.Models;
using KEEM_Domain.Entities.Responses;
using KEEM_Service.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KEEM_Service.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly IBaseRepository<User> _userRepository;

        public AuthService(IBaseRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<BaseResponse<bool>> Login(string login, string password, HttpContext context)
        {
            try
            {
                var user = await _userRepository.GetAll()
                    .FirstOrDefaultAsync( u => u.UserName == login && u.Password == password);

                if (user != null)
                {
                    var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.Description) };
                    
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
                    
                    await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    return new BaseResponse<bool> { Data = true };
                }                             
                else  
                    return new BaseResponse<bool> { Data= false, Description = "User not Found" }; 
            }
            catch(Exception ex)
            {
                return new BaseResponse<bool> { Data = false, Description = $"[Login]: {ex.Message}" };
            }
        }

        public async Task<BaseResponse<bool>> LogOut(HttpContext context)
        {
            try
            {
                await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                return new BaseResponse<bool> { Data = true};
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool> { Data = true, Description = $"[LogOut]: {ex.Message}" };
            }
        }
        
    }
}
