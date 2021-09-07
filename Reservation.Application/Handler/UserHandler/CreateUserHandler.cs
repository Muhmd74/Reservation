using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Reservation.Application.Commands.UserCommand;
using Reservation.Application.Common.Response;
using Reservation.Application.Repository.User;
using Reservation.Application.Repository.User.Dtos.Responses;

namespace Reservation.Application.Handler.UserHandler
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, OutputResponseForValidationFilter>
    {
        private readonly IUser _user;

        public CreateUserHandler(IUser user)
        {
            _user = user;
        }

        public async Task<OutputResponseForValidationFilter> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var result =await _user.CreateUser(request);
            return result;
        }
    }
}
