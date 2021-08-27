using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Reservation.Application.Common.Response;
using Reservation.Application.Query;
using Reservation.Application.Query.UserQuery;
using Reservation.Application.Repository.User;
using Reservation.Application.Repository.User.Dtos.Responses;

namespace Reservation.Application.Handler.UserHandler
{
    public class GetAllUserHandler : IRequestHandler<GetAllUserQuery,OutputResponse<List<GetAllUserResponse>>>
    {
        private readonly IUser _user;

        public GetAllUserHandler(IUser user)
        {
            _user = user;
        }

        public async Task<OutputResponse<List<GetAllUserResponse>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var model =await _user.GetAllUser(request.PageSize);
            return model;
        }
    }
}
