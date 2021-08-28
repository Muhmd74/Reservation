using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Application.Common.Response
{
  public  class OutputResponse<T>
    {
        public bool Success { get; set; }
        public object Message { get; set; }
        public T Model { get; set; }
        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();

    }
}
