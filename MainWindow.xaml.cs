using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestMaintexWPF.functions;
using TestMaintexWPF.classes;
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
using MessageBox = System.Windows.MessageBox;
using System.Collections.ObjectModel;
using System.Data;

namespace TestMaintexWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    /// При запуске проверяется база данных на наличие таблицы. Если таблицы нет, создется. Наименование таблицы указано в variables.
    /// файл sqlserver.ini в первой строке содержит строку подключения к серверу, файл должен находиться рядом с exe.
    /// даты сохраняются как FLOAT значения в бд.
    /// AdminkaMSSQL - библиотека для отслеживания изменений в бд, корректировки. Параметры подключения берет из основного приложения.
    /// ввыполнение запросов выведено в отдельную библиотеку для удобства (RedBdSql)
    /// При импорте из экселя файл открывается в фоне, считывается, затем становится видимым, можно закрывать. 
    /// Не стал делать закрытие, чтобы сразу увидеть и сравнить.
    /// Убрал месаджи в ошибках методов редактирования ячеек, чтобы игнорировать клики мыши не в облать ячейки.
    /// Стили использоал по своему усмотрению, нет смысла с ними возиться.
    /// Приложение простое и данные малообъемные, асинхрон использовать не стал.
    /// Итоги рассчитываются после окончания редактирования любой ячейки таблицы, а так же при загрузке из базы\экселя.


    public partial class MainWindow : Window
    {
        public ObservableCollection<Classes.block> Blocks { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            base_allow.allow_bd();
            Load_from_bd(null,null);
            DataContext = this;
        }
        private void Adminka_start(object sender, EventArgs e)//клик "Админка"
        {
            try
            {
                AdminkaMSSQL.adminka_Form form = new AdminkaMSSQL.adminka_Form();
                form.zapusk(variables.conn);
                form.Visible = true;
            } catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
        public void Load_from_bd(object sender, EventArgs e)//клик "из базы"
        {
            try
            {
                System.Data.DataTable dt = GET.Get_block.get_table_all_block_from_bd();
                Blocks = GET.Get_block.get_list_all_block(dt);
                fill_datagrid(Blocks);
                btn_to_bd.IsEnabled = false;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
        public void Load_from_excel(object sender, EventArgs e)//клик "из экселя"
        {
            try
            {
                string exc_file = Select_File.Selected_Excel();
                par_excel par_Excel = new()
                {
                    xlApp = new Microsoft.Office.Interop.Excel.Application(),
                    file_name = exc_file
                };
                System.Data.DataTable dt = GET.Get_block.get_table_all_block_from_exc(par_Excel);
                Blocks = GET.Get_block.get_list_all_block(dt);
                fill_datagrid(Blocks);
                par_Excel.xlApp.Visible=true;
                btn_to_bd.IsEnabled = true;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
        private void fill_datagrid(ObservableCollection<Classes.block> list_s)
        {
            try
            {
                list_s.Add(functions.Math.srZnachEsli(list_s));
                DG_table_xls.ItemsSource = null;
                DG_table_xls.ItemsSource = list_s;
                DG_table_xls.Columns[0].Header = "№ блока\n1";
                DG_table_xls.Columns[1].Header = "Дата ввода\n2";
                DG_table_xls.Columns[2].Header = "U\nмг/дм³\n3";
                DG_table_xls.Columns[3].Header = "Кислотность\nг/дм³\n4";
                DG_table_xls.Columns[4].Header = "pH\n5";
                DG_table_xls.Columns[5].Header = "ОВП\nмВ\n6";
                DG_table_xls.Columns[6].Header = "SO4 2-\nг/дм³\n7";
                DG_table_xls.Columns[7].Header = "NO3 3-\nг/дм³\n8";
                DG_table_xls.Columns[8].Header = "Fe3+\nг/дм³\n9";
                DG_table_xls.Columns[9].Header = "сухой остаток\nг/дм³\n10";
                DG_table_xls.Columns[10].Header = "Коэффициент окисления\n11";
                DG_table_xls.Columns[11].Header = "U\nмг/дм³\n12";
                DG_table_xls.Columns[12].Header = "Кислотность\nг/дм³\n13";
                DG_table_xls.Columns[13].Header = "Комментарий\n21";
                DG_table_xls.SelectedIndex = list_s.Count - 1;                
                DG_table_xls.ScrollIntoView(DG_table_xls.SelectedItem);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
        private void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            try
            {
                Classes.block block = (Classes.block)e.Row.Item;
                if(block.id == "Итого") 
                { 
                    e.Row.IsEnabled = false;
                }
                else { e.Row.IsEnabled = true; }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
        private void Save_to_bd(object sender, EventArgs e)
        {
            try
            {
            foreach(Classes.block block in Blocks)
            {
                if (block.ism) { POST.Post_Block.Post_Block_to_bd(block); block.ism = false; }
            }
            btn_to_bd.IsEnabled = false;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
        private void dg_cell_edit_end(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                Classes.block block = (Classes.block)e.Row.Item;
                System.Windows.Controls.TextBox textBox = (System.Windows.Controls.TextBox)e.EditingElement;
                if (textBox.Text != block.val) 
                { 
                    block.ism = true;
                    btn_to_bd.IsEnabled = true;
                    block = GET.Get_block.Get_one_block("Итого", Blocks);
                    Blocks.Remove(block);
                    Blocks.Add(functions.Math.srZnachEsli(Blocks));
                }
            }
            catch (Exception ex)
            { }
        }
        private void dg_cell_edit_start(object sender, DataGridBeginningEditEventArgs e)
        {
            try
            {
                Classes.block block = (Classes.block)e.Row.Item;
                TextBlock textBlock = (TextBlock)e.EditingEventArgs.Source;
                block.val = textBlock.Text;
            }
            catch (Exception ex)
            {  }
        }
    }
}
