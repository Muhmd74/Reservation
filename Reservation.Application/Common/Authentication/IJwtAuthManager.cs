using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Reservation.Core.Entities;

namespace Reservation.Application.Common.Authentication
{
    public interface IJwtAuthManager
    {
        Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user);
    }
}
