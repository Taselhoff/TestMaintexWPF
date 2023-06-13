using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMaintexWPF.functions
{
    internal class base_allow
    {
        public static void allow_bd()
        {
            try
            {
                if (!exist_table_on_bd(variables.bd_tableName))
                {
                    RedBdSql.Redact.Create_New_Table_with_intNotNull_id(variables.conn, variables.bd_tableName);
                }
                System.Data.DataTable table = RedBdSql.ShemaBD.GetSpisokColumns(variables.conn, variables.bd_tableName);
                string columnName;
                columnName = "date_input"; if (!exist_column_on_table(columnName, table)) { RedBdSql.Redact.Create_New_Column_FLOAT(variables.conn, variables.bd_tableName, columnName); }
                columnName = "u_pr"; if (!exist_column_on_table(columnName, table)) { RedBdSql.Redact.Create_New_Column_FLOAT(variables.conn, variables.bd_tableName, columnName); }
                columnName = "acid_pr"; if (!exist_column_on_table(columnName, table)) { RedBdSql.Redact.Create_New_Column_FLOAT(variables.conn, variables.bd_tableName, columnName); }
                columnName = "ph_pr"; if (!exist_column_on_table(columnName, table)) { RedBdSql.Redact.Create_New_Column_FLOAT(variables.conn, variables.bd_tableName, columnName); }
                columnName = "ovp_pr"; if (!exist_column_on_table(columnName, table)) { RedBdSql.Redact.Create_New_Column_FLOAT(variables.conn, variables.bd_tableName, columnName); }
                columnName = "so_pr"; if (!exist_column_on_table(columnName, table)) { RedBdSql.Redact.Create_New_Column_FLOAT(variables.conn, variables.bd_tableName, columnName); }
                columnName = "no_pr"; if (!exist_column_on_table(columnName, table)) { RedBdSql.Redact.Create_New_Column_FLOAT(variables.conn, variables.bd_tableName, columnName); }
                columnName = "fe_pr"; if (!exist_column_on_table(columnName, table)) { RedBdSql.Redact.Create_New_Column_FLOAT(variables.conn, variables.bd_tableName, columnName); }
                columnName = "dryses_pr"; if (!exist_column_on_table(columnName, table)) { RedBdSql.Redact.Create_New_Column_FLOAT(variables.conn, variables.bd_tableName, columnName); }
                columnName = "k_acid_pr"; if (!exist_column_on_table(columnName, table)) { RedBdSql.Redact.Create_New_Column_FLOAT(variables.conn, variables.bd_tableName, columnName); }
                columnName = "u_ms"; if (!exist_column_on_table(columnName, table)) { RedBdSql.Redact.Create_New_Column_FLOAT(variables.conn, variables.bd_tableName, columnName); }
                columnName = "acid_ms"; if (!exist_column_on_table(columnName, table)) { RedBdSql.Redact.Create_New_Column_FLOAT(variables.conn, variables.bd_tableName, columnName); }
                columnName = "comment"; if (!exist_column_on_table(columnName, table)) { RedBdSql.Redact.Create_New_Column_TEXT(variables.conn, variables.bd_tableName, columnName); }
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
        }
        private static bool exist_table_on_bd(string name_table)
        {
            try
            {
                System.Data.DataTable table = RedBdSql.ShemaBD.GetSpisokTables(variables.conn);
                foreach (System.Data.DataRow row in table.Rows)
                {
                    if (row["NameTable"].ToString().ToLower() == name_table.ToLower())
                    { return true; }
                }
                return false;
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            return false;
        }
        private static bool exist_column_on_table(string ColumnName, System.Data.DataTable table)
        {
            try
            {
                foreach (System.Data.DataRow row in table.Rows)
                {
                    if (row["ColumnName"].ToString().ToLower() == ColumnName.ToLower())
                    { return true; }
                }
                return false;
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            return false;
        }
    }
}
