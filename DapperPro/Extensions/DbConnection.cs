using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DapperPro.Extensions
{
    public class DbConnection
    {
        private SqlConnection _sqlConnection;

        public SqlConnection SqlConnection
        {
            get { return _sqlConnection; }
            set { _sqlConnection = value; }
        }

        public DbConnection(string connectionString)
        {
            _sqlConnection = new SqlConnection(connectionString);
        }

        public void Connect()
        {
            if (_sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }
        }
    }
}
