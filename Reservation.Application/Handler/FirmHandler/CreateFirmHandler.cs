using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Reservation.Application.Commands.FirmCommand;
using Reservation.Application.Common.Response;
using Reservation.Infrastructure.Data.ApplicationDbContext;

namespace Reservation.Application.Handler.FirmHandler
{
    public class CreateFirmHandler : IRequestHandler<CreateFirmCommand, OutputResponse<bool>>
    {
        private readonly ApplicationDbContext _context;

        public CreateFirmHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<OutputResponse<bool>> Handle(CreateFirmCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _context.Firms.AddAsync(new Core.Entities.Firm()
                {
                    Address = request.Address,
                    Email = request.Email,
                    IsActive = true,
                    IsDeleted = false,
                    Landline = request.Landline,
                    Lat = request.Lat,
                    Long = request.Long,
                    Mobile = request.Mobile,
                    Name = request.Name,
                    Note = request.Note,
                    Website = request.Website,

                });
                await _context.SaveChangesAsync();
                return new OutputResponse<bool>()
                {
                    Model = true,
                    Message = ResponseMessages.Success,
                    Success = true
                };

            }
            catch (Exception e)
            {
                return new OutputResponse<bool>()
                {
                    Model = false,
                    Message = e.Message,
                    Success = true,
                    Errors = new List<ErrorModel> {
                        new ErrorModel {
                            Message = e.Message,
                            Property = "Exception"
                        },
                        new ErrorModel {
                            Message = e.InnerException?.Message,
                            Property = "Inner Exception"
                        },
                        new ErrorModel {
                            Message = e.Source,
                            Property = "Source"
                        }
                    }
                };

            }
        }
    }
}
