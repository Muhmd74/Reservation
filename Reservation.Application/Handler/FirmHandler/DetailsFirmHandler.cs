using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Reservation.Application.Common.Response;
using Reservation.Application.Dtos;
using Reservation.Application.Query.FirmQuery;
using Reservation.Application.Repository.Trip.Dtos.Responses;
using Reservation.Infrastructure.Data.ApplicationDbContext;
using Reservation.Infrastructure.Helpers;

namespace Reservation.Application.Handler.FirmHandler
{
    public class DetailsFirmHandler : IRequestHandler<DetailsFirmQuery, OutputResponse<FirmDetailsResponse>>
    {
        private readonly ApplicationDbContext _context;

        public DetailsFirmHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<OutputResponse<FirmDetailsResponse>> Handle(DetailsFirmQuery request, CancellationToken cancellationToken)
        {
            var model = await _context.Firms.FirstOrDefaultAsync(d => d.Id == request.Id, cancellationToken: cancellationToken);
            if (model != null)
            {
                return new OutputResponse<FirmDetailsResponse>()
                {
                    Model = new FirmDetailsResponse()
                    {
                        Name = model.Name,
                        Address = model.Address,
                        Email = model.Email,
                        Id = model.Id,
                        Mobile = model.Mobile,
                        Landline = model.Landline,
                        Note = model.Note,
                        Website = model.Website,
                        Rate = FirmHelper.CalculationRate(model.Id),
                        RateCount = FirmHelper.RateCount(model.Id),
                        Trips = model.Trips.Select(d => new TripResponses
                        {
                            CityName = d.City.Name,
                            ImageUrl = d.ImageUrl,
                            Price = d.Price,
                            Id = d.Id,
                            Title = d.Title
                        }).ToList()
                    },
                    Message = ResponseMessages.Success,
                    Success = true
                };
            }
            return new OutputResponse<FirmDetailsResponse>()
            {
                Message = ResponseMessages.NotFound,
                Success = false,
                Model = null
            };
        }
    }
}
