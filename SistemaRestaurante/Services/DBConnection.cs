using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace SistemaRestaurante.Services
{
    public static class DBConnection
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["RestauranteDB"].ConnectionString;
            return new SqlConnection(connectionString);
        }
    }
}