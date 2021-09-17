using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Reservation.Core.Entities;

namespace Reservation.Core.Interface
{
    public interface IJwtAuthManager
    {
        Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user);
    }
}
