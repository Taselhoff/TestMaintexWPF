using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMaintexWPF.Classes
{
    internal class block
    {
        public int id { get; set; } // номер блока, столбец заголовок 1 экс
        public DateTime date_input { get; set; } //дата ввода, столбец заголовок 2 экс
        public string? comment { get; set; } //комментарий, столбец заголовок 21
        public double u_pr { get; set; }
        public double acid_pr { get; set; }
        public double ph_pr { get; set; }
        public double ovp_pr { get; set; }
        public double so_pr { get; set; }
        public double no_pr { get; set; }
        public double fe_pr { get; set; }
        public double dryses_pr { get; set; }
        public double k_acid_pr { get; set; }

        public double? u_ms { get; set; }
        public double? acid_ms { get; set; }

        public bool ism { get; set; }
    }
}
