using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TestMaintexWPF.functions
{
    internal class POST
    {
        public static class Post_Block
        {
            public static void Post_Block_to_bd(Classes.block block)
            {
                try
                {
                    string acid_ms = ""; switch (block.acid_ms) { case null : acid_ms = "null"; break; default: acid_ms = block.acid_ms.ToString().Replace(",", "."); break; }
                    string u_ms = ""; switch (block.u_ms) { case null : u_ms = "null"; break; default: u_ms = block.u_ms.ToString().Replace(",", "."); break; }
                    string _zapros = $"MERGE {variables.bd_tableName} AS target " +
$"USING (SELECT " +
$"{block.id} AS id," +
$"{block.date_from.ToOADate().ToString().Replace(",", ".")} AS date_input," +
$"\'{block.comment}\' AS comment," +
$"{block.u_pr.ToString().Replace(",", ".")} AS u_pr," +
$"{block.acid_pr.ToString().Replace(",", ".")} AS acid_pr," +
$"{block.ph_pr.ToString().Replace(",", ".")} AS ph_pr," +
$"{block.ovp_pr.ToString().Replace(",", ".")} AS ovp_pr," +
$"{block.so_pr.ToString().Replace(",", ".")} AS so_pr," +
$"{block.no_pr.ToString().Replace(",", ".")} AS no_pr," +
$"{block.fe_pr.ToString().Replace(",", ".")} AS fe_pr," +
$"{block.dryses_pr.ToString().Replace(",", ".")} AS dryses_pr," +
$"{block.k_acid_pr.ToString().Replace(",", ".")} AS k_acid_pr," +
$"{u_ms} AS u_ms," +
$"{acid_ms} AS acid_ms" +
$") AS source " +
$"ON (target.id = source.id) " +
$"WHEN MATCHED THEN " +
$"UPDATE SET " +
$"target.date_input=source.date_input," +
$"target.comment=source.comment," +
$"target.u_pr=source.u_pr," +
$"target.acid_pr=source.acid_pr," +
$"target.ph_pr=source.ph_pr," +
$"target.ovp_pr=source.ovp_pr," +
$"target.so_pr=source.so_pr," +
$"target.no_pr=source.no_pr," +
$"target.fe_pr=source.fe_pr," +
$"target.dryses_pr=source.dryses_pr," +
$"target.k_acid_pr=source.k_acid_pr," +
$"target.u_ms=source.u_ms," +
$"target.acid_ms=source.acid_ms " +
$"WHEN NOT MATCHED THEN " +
$"INSERT (" +
$"id," +
$"date_input," +
$"comment," +
$"u_pr," +
$"acid_pr," +
$"ph_pr," +
$"ovp_pr," +
$"so_pr," +
$"no_pr," +
$"fe_pr," +
$"dryses_pr," +
$"k_acid_pr," +
$"u_ms," +
$"acid_ms" +
$") VALUES (" +
 $"source.id," +
$"source.date_input," +
$"source.comment," +
$"source.u_pr," +
$"source.acid_pr," +
$"source.ph_pr," +
$"source.ovp_pr," +
$"source.so_pr," +
$"source.no_pr," +
$"source.fe_pr," +
$"source.dryses_pr," +
$"source.k_acid_pr," +
$"source.u_ms," +
$"source.acid_ms" +
$");";
                    RedBdSql.Get.Vipolnit(variables.conn, _zapros);
                }
                catch(Exception ex)
                { Console.WriteLine(ex.ToString()); }
            }
        }
    }
}
