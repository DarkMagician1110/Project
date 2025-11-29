using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlithuvien
{
    internal class DBConnect
    {
        private string connStr = @"Server=LAPTOP-TFMSKHRA;Database=LMS;User Id=HGT;Password=123456;";


        public SqlConnection GetConnection()
        {
            return new SqlConnection(connStr);
        }
    }
}
