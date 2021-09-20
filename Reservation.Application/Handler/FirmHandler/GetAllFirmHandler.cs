using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Reservation.Application.Common.Response;
using Reservation.Application.Dtos;
using Reservation.Application.Query.FirmQuery;
using Reservation.Infrastructure.Data.ApplicationDbContext;
using Reservation.Infrastructure.Helpers;

namespace Reservation.Application.Handler.FirmHandler
{
    public class GetAllFirmHandler : IRequestHandler<ListFirmQuery, OutputResponse<List<ListFirmResponse>>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllFirmHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<OutputResponse<List<ListFirmResponse>>> Handle(ListFirmQuery request, CancellationToken cancellationToken)
        {
            var listFirm = await _context.Firms
                .Select(d => new ListFirmResponse()
                {
                    Name = d.Name,
                    Address = d.Address,
                    Email = d.Email,
                    Id = d.Id,
                    Mobile = d.Mobile,
                    Landline = d.Landline,
                    Note = d.Note,
                    Website = d.Website,
                    Rate = FirmHelper.CalculationRate(d.Id),
                    RateCount = FirmHelper.RateCount(d.Id)
                }).Take(request.PageSize).ToListAsync(cancellationToken: cancellationToken);
            return new OutputResponse<List<ListFirmResponse>>()
            {
                Model = listFirm,
                Message = ResponseMessages.Success,
                Success = true
            };
        }
    }
}
