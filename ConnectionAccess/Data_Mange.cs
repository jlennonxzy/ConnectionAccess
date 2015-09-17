using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using NPOI.HSSF.UserModel;
using System.IO;

namespace ConnectionAccess
{
    public partial class Data_Mange : Form
    {
        public Data_Mange()
        {
            InitializeComponent();
        }

        //SqlCon datacon = new SqlCon();
        //SqlOperate dataoperate = new SqlOperate();
        SqlConnection conn;
        DataSet ds = new DataSet();
        SqlDataAdapter sda;

        private void Data_Mange_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Data_Mange_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 5;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            //string searchSelect = (string)comboBox1.SelectedItem;
            //SqlOperate operate = new SqlOperate();
            //string strSearch =
            //        "select * from Tek733Package where " + searchSelect + " like " + "'" + textBox1.Text + "'";
            //DataSet ds = dataoperate.getDs(strSearch);
            //this.dataGridViewEdit.DataSource = ds.Tables[0];
            ds.Tables.Clear();
            conn = new SqlConnection(@"Server=.\;Database=testdb;uid=sa;pwd=062455Xzy");
            string searchSelect = (string)comboBox1.SelectedItem;
            string sQ = textBox1.Text;
            string sqlSelect = "select * from Tek733Package where " + searchSelect + " like " + "'" + textBox1.Text + "'";
            sda = new SqlDataAdapter(sqlSelect, conn);
            SqlCommand cmd = new SqlCommand(sqlSelect, conn);
            conn.Open();
            sda.Fill(ds);
            this.dataGridViewEdit.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommandBuilder scb = new SqlCommandBuilder(sda);
            sda.Update(ds);
            this.dataGridViewEdit.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();//通过SaveFileDialog类弹出一个保存对话框                     
            sfd.Filter = "Excel文件|*.xls";//设置文件的保存类型，默认选中Excel文件             
            sfd.FileName = "";//设置默认保存文件名称             
            if (sfd.ShowDialog() == DialogResult.OK)//如果用户点击了保存对话框的确定按钮 
            {
                string filename = sfd.FileName;//获取到Excel文件名 
                //获取学生列表 
                //List<Student> list = dataGridView1.DataSource as List<Student>;                 
                HSSFWorkbook workbook = new HSSFWorkbook();//内存中创建一个空的Excel文件                 
                HSSFSheet sheet = workbook.CreateSheet("sheet1");//在Excel文件上通过对HSSFSheet创建一个工作表                 
                HSSFRow row1 = sheet.CreateRow(0);//给工作表上添加一行 

                //在添加的航上创建一个列 
                //HSSFCell cell1 =row1.CreateCell(0, CellType.STRING).SetCellValue(username);
                HSSFCell cell1 = row1.CreateCell(0, NPOI.HSSF.UserModel.HSSFCellType.STRING);
                //HSSFCell cell1 = row1.CreateCell(0, HSSFCell.NPOI.HSSF.UserModel.HSSFCellType.STRING);

                //设置该列的值 
                cell1.SetCellValue("ID");
                cell1 = row1.CreateCell(1, NPOI.HSSF.UserModel.HSSFCellType.STRING);
                cell1.SetCellValue("DateTested");
                cell1 = row1.CreateCell(2, NPOI.HSSF.UserModel.HSSFCellType.STRING);
                cell1.SetCellValue("DatePackage");
                cell1 = row1.CreateCell(3, NPOI.HSSF.UserModel.HSSFCellType.STRING);
                cell1.SetCellValue("TekNum");
                cell1 = row1.CreateCell(4, NPOI.HSSF.UserModel.HSSFCellType.STRING);
                cell1.SetCellValue("BatchNum");
                cell1 = row1.CreateCell(5, NPOI.HSSF.UserModel.HSSFCellType.STRING);
                cell1.SetCellValue("WeekNum");
                cell1 = row1.CreateCell(6, NPOI.HSSF.UserModel.HSSFCellType.STRING);
                cell1.SetCellValue("Serial");
                cell1 = row1.CreateCell(7, NPOI.HSSF.UserModel.HSSFCellType.STRING);
                cell1.SetCellValue("PhoneNum");
                cell1 = row1.CreateCell(8, NPOI.HSSF.UserModel.HSSFCellType.STRING);
                cell1.SetCellValue("IMEI");
                cell1 = row1.CreateCell(9, NPOI.HSSF.UserModel.HSSFCellType.STRING);
                cell1.SetCellValue("ICCID");
                cell1 = row1.CreateCell(10, NPOI.HSSF.UserModel.HSSFCellType.STRING);
                cell1.SetCellValue("IMSI");
                cell1 = row1.CreateCell(11, NPOI.HSSF.UserModel.HSSFCellType.STRING);
                cell1.SetCellValue("FirmwareVer");
                cell1 = row1.CreateCell(12, NPOI.HSSF.UserModel.HSSFCellType.STRING);
                cell1.SetCellValue("BatteryVoltage");
                cell1 = row1.CreateCell(13, NPOI.HSSF.UserModel.HSSFCellType.STRING);
                cell1.SetCellValue("TestPC");
                cell1 = row1.CreateCell(14, NPOI.HSSF.UserModel.HSSFCellType.STRING);
                cell1.SetCellValue("SettingsProfile");
                cell1 = row1.CreateCell(15, NPOI.HSSF.UserModel.HSSFCellType.STRING);
                cell1.SetCellValue("Deleted");
                cell1 = row1.CreateCell(16, NPOI.HSSF.UserModel.HSSFCellType.STRING);
                cell1.SetCellValue("Box");
                //遍历dataGridView中的所有列，然后将列添加到Excel工作表中 
                HSSFFont font = workbook.CreateFont(); //设置字体 
                font.FontName = "宋体";//字体名称 
                font.FontHeightInPoints = 25;//设置字体大小 
                for (int i = 1; i < dataGridViewEdit.Rows.Count + 1; i++)//不+1会少一行
                { 
                    //设置列的样式 
                    HSSFCellStyle style1 = workbook.CreateCellStyle();
                    //设置列的背景色 
                    style1.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.ORANGE.index;
                    //设置填充边框样式 
                    //style1.FillPattern = HSSFCellStyle.SOLID_FOREGROUND;
                    //设置字体显示样式 
                    style1.SetFont(font);

                    HSSFCellStyle style2 = workbook.CreateCellStyle();
                    style2.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.YELLOW.index;

                    //style2.FillPattern = HSSFCellStyle.SOLID_FOREGROUND;
                    HSSFRow row = sheet.CreateRow(i);

                    HSSFCell cell = row.CreateCell(0, NPOI.HSSF.UserModel.HSSFCellType.STRING);
                    cell.CellStyle = style2;
                    cell.SetCellValue(dataGridViewEdit.Rows[i - 1].Cells[0].Value.ToString());

                    cell = row.CreateCell(1, NPOI.HSSF.UserModel.HSSFCellType.STRING);
                    cell.CellStyle = style2;
                    cell.SetCellValue(dataGridViewEdit.Rows[i - 1].Cells[1].Value.ToString());

                    cell = row.CreateCell(2, NPOI.HSSF.UserModel.HSSFCellType.STRING);
                    cell.CellStyle = style2;
                    cell.SetCellValue(dataGridViewEdit.Rows[i - 1].Cells[2].Value.ToString());

                    cell = row.CreateCell(3, NPOI.HSSF.UserModel.HSSFCellType.STRING);
                    cell.CellStyle = style2;
                    cell.SetCellValue(dataGridViewEdit.Rows[i - 1].Cells[3].Value.ToString());

                    cell = row.CreateCell(4, NPOI.HSSF.UserModel.HSSFCellType.STRING);
                    cell.CellStyle = style2;
                    cell.SetCellValue(dataGridViewEdit.Rows[i - 1].Cells[4].Value.ToString());

                    cell = row.CreateCell(5, NPOI.HSSF.UserModel.HSSFCellType.STRING);
                    cell.CellStyle = style2;
                    cell.SetCellValue(dataGridViewEdit.Rows[i - 1].Cells[5].Value.ToString());

                    cell = row.CreateCell(6, NPOI.HSSF.UserModel.HSSFCellType.STRING);
                    cell.CellStyle = style2;
                    cell.SetCellValue(dataGridViewEdit.Rows[i - 1].Cells[6].Value.ToString());

                    cell = row.CreateCell(7, NPOI.HSSF.UserModel.HSSFCellType.STRING);
                    cell.CellStyle = style2;
                    cell.SetCellValue(dataGridViewEdit.Rows[i - 1].Cells[7].Value.ToString());

                    cell = row.CreateCell(8, NPOI.HSSF.UserModel.HSSFCellType.STRING);
                    cell.CellStyle = style2;
                    cell.SetCellValue(dataGridViewEdit.Rows[i - 1].Cells[8].Value.ToString());

                    cell = row.CreateCell(9, NPOI.HSSF.UserModel.HSSFCellType.STRING);
                    cell.CellStyle = style2;
                    cell.SetCellValue(dataGridViewEdit.Rows[i - 1].Cells[9].Value.ToString());

                    cell = row.CreateCell(10, NPOI.HSSF.UserModel.HSSFCellType.STRING);
                    cell.CellStyle = style2;
                    cell.SetCellValue(dataGridViewEdit.Rows[i - 1].Cells[10].Value.ToString());

                    cell = row.CreateCell(11, NPOI.HSSF.UserModel.HSSFCellType.STRING);
                    cell.CellStyle = style2;
                    cell.SetCellValue(dataGridViewEdit.Rows[i - 1].Cells[11].Value.ToString());

                    cell = row.CreateCell(12, NPOI.HSSF.UserModel.HSSFCellType.STRING);
                    cell.CellStyle = style2;
                    cell.SetCellValue(dataGridViewEdit.Rows[i - 1].Cells[12].Value.ToString());

                    cell = row.CreateCell(13, NPOI.HSSF.UserModel.HSSFCellType.STRING);
                    cell.CellStyle = style2;
                    cell.SetCellValue(dataGridViewEdit.Rows[i - 1].Cells[13].Value.ToString());

                    cell = row.CreateCell(14, NPOI.HSSF.UserModel.HSSFCellType.STRING);
                    cell.CellStyle = style2;
                    cell.SetCellValue(dataGridViewEdit.Rows[i - 1].Cells[14].Value.ToString());

                    cell = row.CreateCell(15, NPOI.HSSF.UserModel.HSSFCellType.STRING);
                    cell.CellStyle = style2;
                    cell.SetCellValue(dataGridViewEdit.Rows[i - 1].Cells[15].Value.ToString());

                    cell = row.CreateCell(16, NPOI.HSSF.UserModel.HSSFCellType.STRING);
                    cell.CellStyle = style2;
                    cell.SetCellValue(dataGridViewEdit.Rows[i - 1].Cells[16].Value.ToString());
                }

                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    //将内容写入到硬盘中 
                    workbook.Write(fs);
                }
                MessageBox.Show("导出成功！");
            }
        }
    }
}

