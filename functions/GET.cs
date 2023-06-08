using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMaintexWPF.functions
{
    internal class GET
    {
        public static class Get_block
        {
            public static System.Data.DataTable get_table_all_block()
            {
                string zapros = "select " +
                    "id," +
                    "date_input," +
                    "comment," +
                    "u_pr," +
                    "acid_pr," +
                    "ph_pr," +
                    "ovp_pr," +
                    "so_pr," +
                    "no_pr," +
                    "fe_pr," +
                    "dryses_pr," +
                    "k_acid_pr," +
                    "u_ms," +
                    "acid_ms " +
                    "from first_table";
                System.Data.DataTable dt = RedBdSql.Get.Get_Table(variables.conn, zapros);
                return dt;
            }
            public static List<Classes.block> get_list_all_block(System.Data.DataTable dt)
            {
                List<Classes.block> list = new List<Classes.block>();
                foreach (System.Data.DataRow rr in dt.Rows)
                {
                    list.Add(new Classes.block
                    {
                        id = int.Parse(rr["id"].ToString()),
                        date_input = DateTime.FromBinary(long.Parse(rr["date_input"].ToString())),
                        comment = rr["comment"].ToString(),
                        u_pr = double.Parse(rr["u_pr"].ToString().Replace(".", ",")),
                        acid_pr = double.Parse(rr["acid_pr"].ToString().Replace(".", ",")),
                        ph_pr = double.Parse(rr["ph_pr"].ToString().Replace(".", ",")),
                        ovp_pr = double.Parse(rr["ovp_pr"].ToString().Replace(".", ",")),
                        so_pr = double.Parse(rr["so_pr"].ToString().Replace(".", ",")),
                        no_pr = double.Parse(rr["no_pr"].ToString().Replace(".", ",")),
                        fe_pr = double.Parse(rr["fe_pr"].ToString().Replace(".", ",")),
                        dryses_pr = double.Parse(rr["dryses_pr"].ToString().Replace(".", ",")),
                        k_acid_pr = double.Parse(rr["k_acid_pr"].ToString().Replace(".", ",")),
                        u_ms = double.Parse(rr["u_ms"].ToString().Replace(".", ",")),
                        acid_ms = double.Parse(rr["acid_ms"].ToString().Replace(".", ","))
                    });
                }
                return list;
            }
            public static Classes.block Get_one_block(int id_block, List<Classes.block> all_block)
            {
                Classes.block block = all_block.First(item => item.id == id_block);
                return block;
            }
        }





    }
}
