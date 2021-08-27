using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Reservation.Application.Commands;
using Reservation.Application.Commands.TripUserCommand;
using Reservation.Application.Common.Response;
using Reservation.Application.Repository.TripUser.Dtos.Responses;
using Reservation.Infrastructure.Data.ApplicationDbContext;

namespace Reservation.Application.Repository.TripUser
{
    public class TripUserServices : ITripUser, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapperManager;

        public TripUserServices(IMapper mapperManager, ApplicationDbContext context)
        {
            _mapperManager = mapperManager;
            _context = context;
        }

        public async Task<OutputResponse<CreateTripUserResponse>> CreateTripUser(CreateTripUserCommand model)
        {

            try
            {
                var tripUser = _mapperManager.Map<Core.Entities.TripUser>(model);
                var result = await _context.TripUsers.AddAsync(tripUser);
                await _context.SaveChangesAsync();
                return new OutputResponse<CreateTripUserResponse>()
                {
                    Model = _mapperManager.Map<CreateTripUserResponse>(result.Entity),
                    Message = ResponseMessages.Success,
                    Success = true
                };
            }
            catch (Exception e)
            {
                return new OutputResponse<CreateTripUserResponse>()
                {
                    Message = e.Message,
                    Success = false,
                    Model = null
                };
            }
        }

        public async Task<OutputResponse<List<GetUsersName>>> SearchUsers(string name)

        {
            var result = await _context.Users.Where(d => d.Name.Contains(name)
                                                    || name == null).ToListAsync();
            return new OutputResponse<List<GetUsersName>>()
            {
                Model = _mapperManager.Map<List<GetUsersName>>(result),
                Message = ResponseMessages.Success,
                Success = true
            };
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
