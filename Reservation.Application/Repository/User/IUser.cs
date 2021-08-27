using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Reservation.Application.Common.Response;
using Reservation.Application.Repository.User.Dtos.Responses;

namespace Reservation.Application.Repository.User
{
    public interface IUser
    {
        Task<OutputResponse<List<GetAllUserResponse>>> GetAllUser(int pageSize = Int32.MaxValue);
        Task<OutputResponse<bool>> ChangeActivity(Guid userId);

    }
}
