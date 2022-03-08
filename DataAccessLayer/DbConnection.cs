using CommonLayer.Models;
using Microsoft.Data.SqlClient;
using System;

namespace DataAccessLayer
{
    public class DbConnection
    {
        public SqlConnection connection;
        public DbConnection()
        {
            connection = new SqlConnection(Connection.Connectionstr);

        }
    }
}
