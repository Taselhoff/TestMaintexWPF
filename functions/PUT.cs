using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMaintexWPF.functions
{
    internal class PUT
    {
        public static class Put_Block
        {
            public static void Put_Block_to_bd(Classes.block block)
            {
                try
                {
                    string zapros = $"UPDATE {variables.bd_tableName} SET " +
                        $"date_input={block.date_from.ToBinary()}," +
                        $"comment=\'{block.comment}\'," +
                        $"u_pr={block.u_pr}," +
                        $"acid_pr={block.acid_pr}," +
                        $"ph_pr={block.ph_pr}," +
                        $"ovp_pr={block.ovp_pr}," +
                        $"so_pr={block.so_pr}," +
                        $"no_pr={block.no_pr}," +
                        $"fe_pr={block.fe_pr}," +
                        $"dryses_pr={block.dryses_pr}," +
                        $"k_acid_pr={block.k_acid_pr}," +
                        $"u_ms={block.u_ms}," +
                        $"acid_ms={block.acid_ms} " +
                        $"WHERE id={block.id}";
                    RedBdSql.Get.Vipolnit(variables.conn, zapros);
                }
                catch (Exception ex)
                { Console.WriteLine(ex.ToString()); }
            }
        }
    }
}
