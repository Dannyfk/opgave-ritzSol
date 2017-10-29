using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ritz
{
    public class Dal
    {
        String connStr;
        SqlConnection con;
        public Dal()
        {
            //connStr = @"Data Source=gim.dk;Initial Catalog=Aske_SumP;User ID=aske;Password=aske1234";
            //connStr = @"Data Source=JP-LAPTOP\SQLEXPRESS;Initial Catalog=SUM_PROJEKT;Integrated Security=True";
            //connStr =
            //    @"Data Source=JP-LAPTOP\SQLEXPRESS;Initial Catalog=SUM_PROJEKT;Persist Security Info=True;User ID=sa;Password=1234";
            connStr = @"Data Source=Danny-Laptop\SQLEXPRESS;" +
            "user id=sa; password=122333;" +
            "database=Ritz";
            con = new SqlConnection(connStr);
        }

        public SqlConnection getConnection()
        {
            return con;
        }
    }
}
