using System;
using MediatR;
using Reservation.Application.Common.Response;

namespace Reservation.Application.Commands.FirmCommand
{
    public class UpdateFirmCommand : IRequest<OutputResponse<bool>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Landline { get; set; }
        public string Note { get; set; }
        public string Address { get; set; }
        public decimal Lat { get; set; }
        public decimal Long { get; set; }

    }

 
}
