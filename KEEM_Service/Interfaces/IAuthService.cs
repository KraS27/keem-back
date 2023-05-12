using KEEM_Domain.Entities.Responses;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEEM_Service.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(string login, string password, HttpContext context);

        Task<AuthResponse> LogOut(HttpContext context);

        Task<AuthResponse> IsAuthenticate(HttpContext context);
    }
}
