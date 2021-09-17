using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace Data.Database
{
    public class Adapter
    {
        const string consKeyDefaultCnnString = "ConnStringLocal";
        protected SqlConnection sqlConn;
        protected void OpenConnection()
        {
            //var connectionString = ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString;
            var connectionString = @"Server=(localdb)\mssqllocaldb;Database=academia;Trusted_Connection=True;MultipleActiveResultSets=true";
            //var connectionString = @"Server=.\LOCALHOST;Database=Academia; User=net; Password=net";
            this.sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();
        }

        protected void CloseConnection()
        {
            sqlConn.Close();
            sqlConn = null;
        }
    }
}
