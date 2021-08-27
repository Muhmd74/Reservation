using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Reservation.Application.Common.Files
{
    public class UploadCore
    {
        private static IHttpContextAccessor _context;

        public UploadCore(IHttpContextAccessor context)
        {
            _context = context;
        }
        public string GetBaseUrl()
        {
            var request = _context.HttpContext.Request;
            var baseUrl = $"{request.Scheme}://{request.Host.Value}";
            return baseUrl;
        }
    }
}
