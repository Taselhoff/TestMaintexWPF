using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMaintexWPF.classes
{
    internal class par_excel
    {
        public string file_name { get; set; }
        public Microsoft.Office.Interop.Excel.Application xlApp { get; set; }
        public Microsoft.Office.Interop.Excel.Worksheet xlSht { 
            get {
                xlApp.Visible = false;
                xlApp.Workbooks.Open(file_name);
                return (Microsoft.Office.Interop.Excel.Worksheet)xlApp.Worksheets.get_Item(1);            
            }}

    }
}
