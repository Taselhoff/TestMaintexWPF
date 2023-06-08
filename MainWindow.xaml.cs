using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.Generic;

namespace TestMaintexWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Adminka_start(object sender, EventArgs e)
        {
            AdminkaMSSQL.adminka_Form form = new AdminkaMSSQL.adminka_Form();
            form.zapusk(variables.conn);
            form.Visible = true;
        }




        public void Load_from_bd(object sender, EventArgs e)
        {
            //var t = DateTime.Parse("20.12.1989").ToBinary();//      DateTime.Now.ToBinary();
            //System.Windows.MessageBox.Show(t.ToString());
            //System.Windows.MessageBox.Show(DateTime.FromBinary(t).ToString());

            System.Windows.Controls.ListView LV = LV_table_xls;
            functions.ClearLV.Clear_LV(LV);
            var gridview = new GridView();
            LV.View = gridview;
            gridview.Columns.Add(new GridViewColumn
            {
                Header = "№ блока\n1",
                DisplayMemberBinding = new System.Windows.Data.Binding("ID")
            });
            gridview.Columns.Add(new GridViewColumn
            {
                Header = "Дата ввода\n2",
                DisplayMemberBinding = new System.Windows.Data.Binding("ShortName")
            });
            gridview.Columns.Add(new GridViewColumn
            {
                Header = "U\nмг/дм³\n3",
                DisplayMemberBinding = new System.Windows.Data.Binding("LongName")
            });
            gridview.Columns.Add(new GridViewColumn
            {
                Header = "Кислотность\nг/дм³\n4",
                DisplayMemberBinding = new System.Windows.Data.Binding("LongName")
            });
            gridview.Columns.Add(new GridViewColumn
            {
                Header = "pH\n5",
                DisplayMemberBinding = new System.Windows.Data.Binding("LongName")
            });
            gridview.Columns.Add(new GridViewColumn
            {
                Header = "ОВП\nмВ\n6",
                DisplayMemberBinding = new System.Windows.Data.Binding("LongName")
            });
            gridview.Columns.Add(new GridViewColumn
            {
                Header = "SO4-2\nг/дм³\n7",
                DisplayMemberBinding = new System.Windows.Data.Binding("LongName")
            });
            gridview.Columns.Add(new GridViewColumn
            {
                Header = "NO3-3\nг/дм³\n8",
                DisplayMemberBinding = new System.Windows.Data.Binding("LongName")
            });
            gridview.Columns.Add(new GridViewColumn
            {
                Header = "Fe3+\nг/дм³\n9",
                DisplayMemberBinding = new System.Windows.Data.Binding("LongName")
            });
            gridview.Columns.Add(new GridViewColumn
            {
                Header = "сухой остаток\nг/дм³\n10",
                DisplayMemberBinding = new System.Windows.Data.Binding("LongName")
            });
            gridview.Columns.Add(new GridViewColumn
            {
                Header = "Коэффициент окисления\n11",
                DisplayMemberBinding = new System.Windows.Data.Binding("LongName")
            });
            gridview.Columns.Add(new GridViewColumn
            {
                Header = "U\nмг/дм³\n12",
                DisplayMemberBinding = new System.Windows.Data.Binding("LongName")
            });
            gridview.Columns.Add(new GridViewColumn
            {
                Header = "Кислотность\nг/дм³\n13",
                DisplayMemberBinding = new System.Windows.Data.Binding("LongName")
            });
            gridview.Columns.Add(new GridViewColumn
            {
                Header = "Комментарий\n21",
                DisplayMemberBinding = new System.Windows.Data.Binding("LongName")
            });
            System.Data.DataTable dt = functions.GET.Get_block.get_table_all_block();
            List <Classes.block> list_s = functions.GET.Get_block.get_list_all_block(dt);
            LV.ItemsSource = list_s;








        }



    }
}
