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
        private string connStr = @"Server=LAPTOP-TR083D7U;Database=LMS;User Id=sa;Password=lehuutrung11102006;";


        public SqlConnection GetConnection()
        {
            return new SqlConnection(connStr);
        }
    }
}
