using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMaintexWPF.functions
{
    internal class ClearLV
    {
        public static void Clear_LV(System.Windows.Controls.ListView LV)
        {
            if(LV.ItemsSource != null) { LV.ItemsSource = null; }
            if(LV.Items.Count > 0) { LV.Items.Clear(); }
        }
    }
}
