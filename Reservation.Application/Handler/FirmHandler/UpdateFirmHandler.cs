using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Reservation.Application.Commands.FirmCommand;
using Reservation.Application.Common.Response;
using Reservation.Infrastructure.Data.ApplicationDbContext;

namespace Reservation.Application.Handler.FirmHandler
{
    public class UpdateFirmHandler : IRequestHandler<UpdateFirmCommand,OutputResponse<bool>>
    {
        private readonly ApplicationDbContext _context;

        public UpdateFirmHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<OutputResponse<bool>> Handle(UpdateFirmCommand request, CancellationToken cancellationToken)
        {
            var model = await _context.Firms.FirstOrDefaultAsync(d => d.Id == request.Id, cancellationToken: cancellationToken);

            if (model!=null)
            {
                model.Email = request.Email;
                model.Landline = request.Landline;
                model.Mobile = request.Mobile;
                model.Address = request.Address;
                model.Lat = request.Lat;
                model.Long = request.Long;
                model.Name = request.Name;
                await _context.SaveChangesAsync(cancellationToken);
                return new OutputResponse<bool>()
                {
                    Model = true,
                    Message = ResponseMessages.Success,
                    Success = true
                };
            }
            return new OutputResponse<bool>()
            {
                Model = false,
                Message = ResponseMessages.NotFound,
                Success = false
            };
        }
    }
}
