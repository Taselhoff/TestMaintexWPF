using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMaintexWPF
{
    internal class variables
    {
        public static string conn_param = "Server=" + File.ReadAllLines(Directory.GetCurrentDirectory() + "\\sqlserver.ini")[0];
        public static SqlConnection conn = new SqlConnection(conn_param);
        public static SqlCommand cmd;
        public static string bd_tableName = "first_table";
        public static int exc_row_start = 9;
        public static int exc_col_start = 2;
    }
}
