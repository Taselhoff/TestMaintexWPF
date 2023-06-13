using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMaintexWPF.functions
{
    internal class Math
    {
        public static Classes.block srZnachEsli(ObservableCollection<Classes.block> list_s)
        {
            double? u_pr = 0;
            double? acid_pr = 0;
            double? ph_pr = 0;
            double? ovp_pr = 0;
            double? so_pr = 0;
            double? no_pr = 0;
            double? fe_pr = 0;
            double? dryses_pr = 0;
            double? k_acid_pr = 0;

            int i_u_pr = 0;
            int i_acid_pr = 0;
            int i_ph_pr = 0;
            int i_ovp_pr = 0;
            int i_so_pr = 0;
            int i_no_pr = 0;
            int i_fe_pr = 0;
            int i_dryses_pr = 0;
            int i_k_acid_pr = 0;

            foreach (Classes.block c in list_s)
            {
                if(c.u_pr > 0 && c.u_pr != null)
                {
                    i_u_pr++;
                    u_pr = u_pr += c.u_pr;
                }
                if (c.acid_pr > 0 && c.acid_pr != null)
                {
                    i_acid_pr++;
                    acid_pr = acid_pr += c.acid_pr;
                }
                if (c.ph_pr > 0 && c.ph_pr != null)
                {
                    i_ph_pr++;
                    ph_pr = ph_pr += c.ph_pr;
                }
                if (c.ovp_pr > 0 && c.ovp_pr != null)
                {
                    i_ovp_pr++;
                    ovp_pr = ovp_pr += c.ovp_pr;
                }
                if (c.so_pr > 0 && c.so_pr != null)
                {
                    i_so_pr++;
                    so_pr = so_pr += c.so_pr;
                }
                if (c.no_pr > 0 && c.no_pr != null)
                {
                    i_no_pr++;
                    no_pr = no_pr += c.no_pr;
                }
                if (c.fe_pr > 0 && c.fe_pr != null)
                {
                    i_fe_pr++;
                    fe_pr = fe_pr += c.fe_pr;
                }
                if (c.dryses_pr > 0 && c.dryses_pr != null)
                {
                    i_dryses_pr++;
                    dryses_pr = dryses_pr += c.dryses_pr;
                }
                if (c.k_acid_pr > 0 && c.k_acid_pr != null)
                {
                    i_k_acid_pr++;
                    k_acid_pr = k_acid_pr += c.k_acid_pr;
                }
            }

            Classes.block totalBlock = new Classes.block()
            {
                id = "Итого",
                date_input = "",
                u_pr = double.Parse(MathF.Round((float)(u_pr / i_u_pr), 1).ToString()),
                acid_pr = double.Parse(MathF.Round((float)(acid_pr / i_acid_pr), 1).ToString()),
                ph_pr = double.Parse(MathF.Round((float)(ph_pr / i_ph_pr), 1).ToString()),
                ovp_pr = double.Parse(MathF.Round((float)(ovp_pr / i_ovp_pr), 1).ToString()),
                so_pr = double.Parse(MathF.Round((float)(so_pr / i_so_pr), 1).ToString()),
                no_pr = double.Parse(MathF.Round((float)(no_pr / i_no_pr), 1).ToString()),
                fe_pr = double.Parse(MathF.Round((float)(fe_pr / i_fe_pr), 1).ToString()),
                dryses_pr = double.Parse(MathF.Round((float)(dryses_pr / i_dryses_pr), 1).ToString()),
                k_acid_pr = double.Parse(MathF.Round((float)(k_acid_pr / i_k_acid_pr), 1).ToString()),
                u_ms = null,
                acid_ms = null,
                ism = false
            };
            return totalBlock;
        }
    }
}
