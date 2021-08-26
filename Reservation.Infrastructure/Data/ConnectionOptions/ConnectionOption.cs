using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

namespace Reservation.Infrastructure.Data.ConnectionOptions
{
   public class ConnectionOption
    {
        public static string Create()
        {
            return SqlServerConnection();
        }

        private static string SqlServerConnection()
        {
            var builder = new SqlConnectionStringBuilder()
            {
                DataSource = @".",
                InitialCatalog = "Reservations",
                ApplicationName = "Reservation",
                IntegratedSecurity = true,
                MultipleActiveResultSets = true
            };
            return builder.ConnectionString;
        }
    }
}
