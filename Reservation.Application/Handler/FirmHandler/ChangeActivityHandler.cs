using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Reservation.Application.Commands.StaticCommand;
using Reservation.Application.Common.Response;
using Reservation.Infrastructure.Data.ApplicationDbContext;

namespace Reservation.Application.Handler.FirmHandler
{
    public class ChangeActivityHandler : IRequestHandler<ChangeActivityCommand,OutputResponse<bool>>
    {
        private readonly ApplicationDbContext _context;

        public ChangeActivityHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<OutputResponse<bool>> Handle(ChangeActivityCommand request, CancellationToken cancellationToken)
        {
            var model = await _context.Firms.FirstOrDefaultAsync(d => d.Id == request.Id, cancellationToken: cancellationToken);
            if (model != null)
            {
                model.IsDeleted = !model.IsDeleted;
                return new OutputResponse<bool>()
                {
                    Model = model.IsDeleted,
                    Message = ResponseMessages.Success,
                    Success = true
                };
            }
            return new OutputResponse<bool>()
            {
                Model = false,
                Message = ResponseMessages.Success,
                Success = false
            };
        }
    }
}
