using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Reservation.WebUI.Service
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContext;

        public UserService(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }



        public string GetUserById()
        {
            return _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
