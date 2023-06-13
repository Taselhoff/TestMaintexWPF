using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestMaintexWPF.functions
{
    internal class Select_File
    {
        public static string Selected_Excel()
        {
            string fname = "";
            try
            {
                OpenFileDialog fd = new OpenFileDialog();
                string init_dir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                fd.InitialDirectory = init_dir;
                fd.Title = "Выберите или введите имя файла";
                fd.Filter = "Файл xlsx, xls (*.xlsx,*.xls)|*.xlsx;*.xls";
                fd.FilterIndex = 1;
                fd.FileName = "";
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    fname = fd.FileName;
                }
                return fname;
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message);}
            return fname;
        }



    }
}
