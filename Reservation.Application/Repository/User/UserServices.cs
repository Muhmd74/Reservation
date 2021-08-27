﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Reservation.Application.Common.Response;
using Reservation.Application.Repository.User.Dtos.Responses;
using Reservation.Infrastructure.Data.ApplicationDbContext;

namespace Reservation.Application.Repository.User
{
    public class UserServices : IUser,IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapperManager;

        public UserServices(ApplicationDbContext context, IMapper mapperManager)
        {
            _context = context;
            _mapperManager = mapperManager;
        }

        public async Task<OutputResponse<List<GetAllUserResponse>>> GetAllUser(int pageSize = Int32.MaxValue)
        {
            var model =await _context.Users.Take(pageSize).ToListAsync();
            return new OutputResponse<List<GetAllUserResponse>>()
            {
                Model = _mapperManager.Map<List<GetAllUserResponse>>(model),
                Message = ResponseMessages.Success,
                Success = true
            };

        }

        public async Task<OutputResponse<bool>> ChangeActivity(Guid userId)
        {
            var result =await _context.Users.FirstOrDefaultAsync(d => d.Id == userId);
            if (result!=null)
            {
                result.IsActive = !result.IsActive;
                await _context.SaveChangesAsync();
                return new OutputResponse<bool>()
                {
                    Model = result.IsActive,
                    Message = ResponseMessages.Success,
                    Success = true
                };
            }
            return new OutputResponse<bool>()
            {
                Model = false,
                Message = ResponseMessages.Failure,
                Success = false
            };
        }


        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}