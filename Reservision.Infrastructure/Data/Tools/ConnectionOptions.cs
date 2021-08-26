using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

namespace RegisterUser.Infrastructure.Data.Tools
{
   public class ConnectionOptions
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
                InitialCatalog = "RegisterUser",
                ApplicationName = "Register User",
                IntegratedSecurity = true,
                MultipleActiveResultSets = true
            };
            return builder.ConnectionString;
        }
    }
}
