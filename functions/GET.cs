using System;
using System.Collections.Generic;
using System.Linq;
using TestMaintexWPF.classes;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows;
using System.Collections.ObjectModel;

namespace TestMaintexWPF.functions
{
    internal class GET
    {
        public static class Get_block
        {
            public static System.Data.DataTable get_table_all_block_from_bd()
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                dt.TableName = "bd";
                try
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
                    dt = RedBdSql.Get.Get_Table(variables.conn, zapros);
                    return dt;
                }
                catch (Exception ex)
                { Console.WriteLine(ex.Message); }
                return dt;
            }
            public static System.Data.DataTable get_table_all_block_from_exc(par_excel par_Excel)
            {
                System.Data.DataTable dt_temp = new System.Data.DataTable();
                par_Excel.xlApp.Visible = false;
                try
                {
                    bool all_done = false;
                    int r_count = 1;
                    int r_count_max = 1;
                    int c_count = 1;
                    int c_count_max = 1;
                    while (!all_done)
                    {
                        bool r_done = false;
                        bool c_done = false;
                        int c_count_max_find = par_Excel.xlSht.Cells[r_count, par_Excel.xlSht.Columns.Count].End[Excel.XlDirection.xlToLeft].Column; //последний заполненный столбец в r_count строке
                        int r_count_max_find = par_Excel.xlSht.Cells[par_Excel.xlSht.Rows.Count, c_count].End[Excel.XlDirection.xlUp].Row; //последняя заполненная строка в столбце c_count
                        if (c_count_max < c_count_max_find) { c_count_max = c_count_max_find; }
                        if (r_count_max < r_count_max_find) { r_count_max = r_count_max_find; }
                        if (r_count < r_count_max) { r_count++; } else { r_done = true; }
                        if (c_count < c_count_max) { c_count++; } else { c_done = true; }
                        if (r_done && c_done) { all_done = true; }
                    }
                    dt_temp.TableName = "excel";
                    for (int i_col = variables.exc_col_start; i_col < 16; i_col++)
                    {
                        if (!dt_temp.Columns.Contains(i_col.ToString())) { dt_temp.Columns.Add(i_col.ToString()); }
                        for (int i_row = variables.exc_row_start; i_row < r_count_max; i_row++)
                        {
                            string orig = "";
                            if (par_Excel.xlApp.Cells[i_row, variables.exc_col_start] != null)
                            {
                                string _orig = Convert.ToString(par_Excel.xlApp.Cells[i_row, variables.exc_col_start].value);
                                if (_orig.ToLower().Trim().Contains("итого")) { break; }
                            }
                            if (par_Excel.xlApp.Cells[i_row, i_col] != null)
                            {
                                orig = Convert.ToString(par_Excel.xlApp.Cells[i_row, i_col].value);
                            }
                            if (dt_temp.Rows.Count < i_row - variables.exc_row_start + 1) { dt_temp.Rows.Add(); }
                            dt_temp.Rows[i_row - variables.exc_row_start][i_col - variables.exc_col_start] = orig;
                        }
                    }
                    dt_temp.Columns[0].ColumnName = "id";
                    dt_temp.Columns[1].ColumnName = "date_input";
                    dt_temp.Columns[2].ColumnName = "u_pr";
                    dt_temp.Columns[3].ColumnName = "acid_pr";
                    dt_temp.Columns[4].ColumnName = "ph_pr";
                    dt_temp.Columns[5].ColumnName = "ovp_pr";
                    dt_temp.Columns[6].ColumnName = "so_pr";
                    dt_temp.Columns[7].ColumnName = "no_pr";
                    dt_temp.Columns[8].ColumnName = "fe_pr";
                    dt_temp.Columns[9].ColumnName = "dryses_pr";
                    dt_temp.Columns[10].ColumnName = "k_acid_pr";
                    dt_temp.Columns[11].ColumnName = "u_ms";
                    dt_temp.Columns[12].ColumnName = "acid_ms";
                    dt_temp.Columns[13].ColumnName = "comment";

                    foreach (System.Data.DataRow row in dt_temp.Rows)
                    {
                        row["date_input"] = DateTime.Parse(row["date_input"].ToString()).ToOADate();
                    }
                    return dt_temp;
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
                return dt_temp;
            }
            public static ObservableCollection<Classes.block> get_list_all_block(System.Data.DataTable dt)
            {
                ObservableCollection<Classes.block> list = new ObservableCollection<Classes.block>();
                try
                {
                    foreach (System.Data.DataRow rr in dt.Rows)
                    {
                        Classes.block block = new Classes.block();                        
                        block.id = rr["id"].ToString();
                        block.date_from = DateTime.FromOADate(double.Parse(rr["date_input"].ToString().Replace(".", ",")));
                        block.date_input = DateTime.FromOADate(double.Parse(rr["date_input"].ToString().Replace(".", ","))).ToShortDateString();
                        switch (rr["comment"].ToString()) { case "": break; default: block.comment = rr["comment"].ToString(); break; };
                        block.u_pr = double.Parse(rr["u_pr"].ToString().Replace(".", ","));
                        block.acid_pr = double.Parse(rr["acid_pr"].ToString().Replace(".", ","));
                        block.ph_pr = double.Parse(rr["ph_pr"].ToString().Replace(".", ","));
                        block.ovp_pr = double.Parse(rr["ovp_pr"].ToString().Replace(".", ","));
                        block.so_pr = double.Parse(rr["so_pr"].ToString().Replace(".", ","));
                        block.no_pr = double.Parse(rr["no_pr"].ToString().Replace(".", ","));
                        block.fe_pr = double.Parse(rr["fe_pr"].ToString().Replace(".", ","));
                        block.dryses_pr = double.Parse(rr["dryses_pr"].ToString().Replace(".", ","));
                        block.k_acid_pr = double.Parse(rr["k_acid_pr"].ToString().Replace(".", ","));
                        switch (rr["u_ms"].ToString()) { case "": break; default: block.u_ms = double.Parse(rr["u_ms"].ToString().Replace(".", ",")); break; };
                        switch (rr["acid_ms"].ToString()) { case "": break; default: block.acid_ms = double.Parse(rr["acid_ms"].ToString().Replace(".", ",")); break; };
                        if (dt.TableName == "excel") { block.ism = true; } else { block.ism = false; }

                        list.Add(block);
                    }
                    return list;
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
                return list;
            }
            public static Classes.block Get_one_block(string id_block, ObservableCollection<Classes.block> all_block)
            {
                Classes.block block = new Classes.block();
                try
                {
                    block = all_block.First(item => item.id.ToLower().Trim() == id_block.ToLower().Trim());
                    return block;
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
                return block;
            }
        }
    }
}
