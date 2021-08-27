using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Reservation.Application.Commands.UserCommand;
using Reservation.Application.Common.Response;
using Reservation.Application.Repository.User;

namespace Reservation.Application.Handler.UserHandler
{
    public class ChangeActivityUserHandler: IRequestHandler<ChangeActivityCommand,OutputResponse<bool>>
    {
        private readonly IUser _user;

        public ChangeActivityUserHandler(IUser user)
        {
            _user = user;
        }

        public async Task<OutputResponse<bool>> Handle(ChangeActivityCommand request, CancellationToken cancellationToken)
        {
            var result =await _user.ChangeActivity(request.UserId);
            return result;
        }
    }
}
