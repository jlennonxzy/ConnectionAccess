using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using ConnectionAccess.Common_Class;
using System.Data.SqlClient;
using System.IO;

namespace ConnectionAccess
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            string mdbPath = string.Format("{0}\\TEK586BatchDB.mdb",//MDB文件存在判断
            Application.StartupPath);
            if (!File.Exists(mdbPath))
            {
                MessageBox.Show("MDB文件不存在，请点击'导入数据'按钮！", "提示",//弹出消息对话框
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;//退出事件
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")//条码漏空提示
            {
                errorProviderText.SetError(textBox1, "条码不能为空!");
            }
            else
            {
                errorProviderText.Clear();
                //SqlConnection conn = SqlCon.MyConnection();//创建数据库连接对象
                //conn.Open();//打开数据库连接
                SqlOperate operate = new SqlOperate();//创建数据操作对象
                string str =//创建SQL字符串
                        "select count(*) from Tek733Package where Serial=" + "'" + textBox1.Text + "'";
                int i = operate.SelectData(str);
                if (i > 0)
                {
                    MessageBox.Show("此条码已包装", "提示",//弹出消息对话框
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //return;//退出事件--退出上一层函数，导致后面的清空无效
                }
                else
                {
                    string ConStr = string.Format(//设置数据库连接字符串
                    @"Provider=Microsoft.Jet.OLEDB.4.0;Data source='{0}\TEK586BatchDB.mdb'",
                    Application.StartupPath);//Format(String, Object) ,  将指定的 String 中的格式项替换为指定的 Object 实例的值的文本等效项。  
                    OleDbConnection oleCon = new OleDbConnection(ConStr);//创建数据库连接对象
                    OleDbDataAdapter oleDap = new OleDbDataAdapter(//创建数据适配器对象
                        "select * from TBLtest3 where Serial = " + "'" + textBox1.Text + "'", oleCon);
                    DataSet ds = new DataSet();//创建数据集
                    oleDap.Fill(ds, "TBLtest3");//填充数据集
                    //this.dataGridView1.DataSource =//设置数据源
                    //    ds.Tables[0].DefaultView;
                    oleCon.Close();//关闭数据库连接
                    oleCon.Dispose();//释放连接资源

                    if (ds.Tables[0].Rows.Count == 0)//判断ds的表是否为空
                    {
                        MessageBox.Show("无此测试数据，请重新导入新的MDB文件", "提示",//弹出消息对话框
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        //MDB的dataset数据分离
                        string strID = ds.Tables[0].Rows[0]["ID"].ToString();
                        string strDateTested = ds.Tables[0].Rows[0]["DateTested"].ToString();

                        string strTekNum = ds.Tables[0].Rows[0]["TekNum"].ToString();
                        string strBatchNum = ds.Tables[0].Rows[0]["BatchNum"].ToString();
                        string strWeekNum = ds.Tables[0].Rows[0]["WeekNum"].ToString();
                        string strSerial = ds.Tables[0].Rows[0]["Serial"].ToString();
                        string strPhoneNum = ds.Tables[0].Rows[0]["PhoneNum"].ToString();
                        string strIMEI = ds.Tables[0].Rows[0]["IMEI"].ToString();
                        string strICCID = ds.Tables[0].Rows[0]["ICCID"].ToString();
                        string strIMSI = ds.Tables[0].Rows[0]["IMSI"].ToString();
                        string strFirmwareVer = ds.Tables[0].Rows[0]["FirmwareVer"].ToString();
                        string strBatteryVoltage = ds.Tables[0].Rows[0]["BatteryVoltage"].ToString();
                        string strTestPC = ds.Tables[0].Rows[0]["TestPC"].ToString();
                        string strSettingsProfile = ds.Tables[0].Rows[0]["SettingsProfile"].ToString();
                        string strDeleted = ds.Tables[0].Rows[0]["Deleted"].ToString();

                        //string[] row = { strID, strDateTested, strTekNum, strBatchNum, strWeekNum, strSerial, strPhoneNum, strIMEI, strICCID, strIMSI, strFirmwareVer, strBatteryVoltage, strTestPC, strSettingsProfile, strDeleted };

                        //box检索判断
                        string box = "";
                        SqlConnection conn = new SqlConnection(@"server = .\;database =testdb;UID=sa;PWD=062455Xzy");
                        string sqlBoxCheck = "select top 1 * from Tek733Package order by DatePackage desc";
                        SqlCommand cmdBoxSelect = new SqlCommand(sqlBoxCheck, conn);
                        conn.Open();
                        SqlDataReader readerBox = cmdBoxSelect.ExecuteReader();
                        //int reCheckFlag = readerFlag.GetOrdinal("flag");
                        int selBox = readerBox.GetOrdinal("box");

                        if (readerBox.Read())//筛选此batch之前有过包装记录
                        {
                            int boxX = 0, boxY = 0;
                            string boxFront = "", boxEnd = "";
                            string strBoxPP = readerBox[selBox].ToString();
                            if (radioButtonRecount.Checked)//分割,此环境与648不同，各个小系列的产品serial是连续交叉着记录的
                            {
                                //string[] BoxPP = strBoxPP.Split(new char[] { '-' });
                                //boxFront = BoxPP[0];
                                //boxX = Convert.ToInt32(boxFront);
                                //boxEnd = "1";
                                //boxX = boxX + 1;
                                //boxFront = Convert.ToString(boxX);
                                //box = boxFront + "-" + boxEnd;
                                box = "1" + "-" + "1";
                                radioButtonRecount.Checked = false;
                            }
                            else//不分割
                            {
                                string[] BoxPP = strBoxPP.Split(new char[] { '-' });
                                boxFront = BoxPP[0];
                                boxEnd = BoxPP[1];
                                boxY = Convert.ToInt32(boxEnd);
                                boxX = Convert.ToInt32(boxFront);
                                boxY = boxY + 1;
                                boxEnd = Convert.ToString(boxY);
                                boxFront = Convert.ToString(boxX);
                                box = boxFront + "-" + boxEnd;
                            }
                            if (boxY == 20)
                            {
                                MessageBox.Show("已装满一箱！", "注意", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                            }
                            else if (boxY > 20)
                            {
                                boxY = 1;
                                boxEnd = Convert.ToString(boxY);
                                boxX = boxX + 1;
                                boxFront = Convert.ToString(boxX);
                                box = boxFront + "-" + boxEnd;
                            }
                        }
                        else
                        {
                            box = "1" + "-" + "1";
                            radioButtonRecount.Checked = false;
                        }

                        conn.Close();

                        //参数化insert sql
                        string strInsert =
                        "insert into Tek733Package(ID,DateTested,DatePackage,TekNum,BatchNum,WeekNum,Serial,PhoneNum,IMEI,ICCID,IMSI,FirmwareVer,BatteryVoltage,TestPC,SettingsProfile,Deleted,Box) " +
                        "values(@StrID, @StrDateTested,convert(varchar(25), getdate(), 121), @StrTekNum, @StrBatchNum, @StrWeekNum, @StrSerial, @StrPhoneNum, @StrIMEI, @StrICCID, @StrIMSI, @StrFirmwareVer, @StrBatteryVoltage, @StrTestPC, @StrSettingsProfile, @StrDeleted,@StrBox)";

                        SqlParameter parameterStrID = new SqlParameter("@StrID", SqlDbType.NVarChar);
                        parameterStrID.Value = strID;
                        SqlParameter parameterStrDateTested = new SqlParameter("@StrDateTested", SqlDbType.NVarChar);
                        parameterStrDateTested.Value = strDateTested;
                        SqlParameter parameterStrTekNum = new SqlParameter("@StrTekNum", SqlDbType.NVarChar);
                        parameterStrTekNum.Value = strTekNum;
                        SqlParameter parameterStrBatchNum = new SqlParameter("@StrBatchNum", SqlDbType.NVarChar);
                        parameterStrBatchNum.Value = strBatchNum;
                        SqlParameter parameterStrWeekNum = new SqlParameter("@StrWeekNum", SqlDbType.NVarChar);
                        parameterStrWeekNum.Value = strWeekNum;
                        SqlParameter parameterStrSerial = new SqlParameter("@StrSerial", SqlDbType.NVarChar);
                        parameterStrSerial.Value = strSerial;
                        SqlParameter parameterStrPhoneNum = new SqlParameter("@StrPhoneNum", SqlDbType.NVarChar);
                        parameterStrPhoneNum.Value = strPhoneNum;
                        SqlParameter parameterStrIMEI = new SqlParameter("@StrIMEI", SqlDbType.NVarChar);
                        parameterStrIMEI.Value = strIMEI;
                        SqlParameter parameterStrICCID = new SqlParameter("@StrICCID", SqlDbType.NVarChar);
                        parameterStrICCID.Value = strICCID;
                        SqlParameter parameterStrIMSI = new SqlParameter("@StrIMSI", SqlDbType.NVarChar);
                        parameterStrIMSI.Value = strIMSI;
                        SqlParameter parameterStrFirmwareVer = new SqlParameter("@StrFirmwareVer", SqlDbType.NVarChar);
                        parameterStrFirmwareVer.Value = strFirmwareVer;
                        SqlParameter parameterStrBatteryVoltage = new SqlParameter("@StrBatteryVoltage", SqlDbType.NVarChar);
                        parameterStrBatteryVoltage.Value = strBatteryVoltage;
                        SqlParameter parameterStrTestPC = new SqlParameter("@StrTestPC", SqlDbType.NVarChar);
                        parameterStrTestPC.Value = strTestPC;
                        SqlParameter parameterStrSettingsProfile = new SqlParameter("@StrSettingsProfile", SqlDbType.NVarChar);
                        parameterStrSettingsProfile.Value = strSettingsProfile;
                        SqlParameter parameterStrDeleted = new SqlParameter("@StrDeleted", SqlDbType.NVarChar);
                        parameterStrDeleted.Value = strDeleted;
                        SqlParameter parameterStrBox = new SqlParameter("@StrBox", SqlDbType.NVarChar);
                        parameterStrBox.Value = box;

                        //SqlConnection conn = new SqlConnection(@"server = .\;database =testdb;UID=sa;PWD=062455Xzy");
                        SqlCommand cmdInsert = new SqlCommand(strInsert, conn);
                        cmdInsert.Parameters.Add(parameterStrID);
                        cmdInsert.Parameters.Add(parameterStrDateTested);
                        cmdInsert.Parameters.Add(parameterStrTekNum);
                        cmdInsert.Parameters.Add(parameterStrBatchNum);
                        cmdInsert.Parameters.Add(parameterStrWeekNum);
                        cmdInsert.Parameters.Add(parameterStrSerial);
                        cmdInsert.Parameters.Add(parameterStrPhoneNum);
                        cmdInsert.Parameters.Add(parameterStrIMEI);
                        cmdInsert.Parameters.Add(parameterStrICCID);
                        cmdInsert.Parameters.Add(parameterStrIMSI);
                        cmdInsert.Parameters.Add(parameterStrFirmwareVer);
                        cmdInsert.Parameters.Add(parameterStrBatteryVoltage);
                        cmdInsert.Parameters.Add(parameterStrTestPC);
                        cmdInsert.Parameters.Add(parameterStrSettingsProfile);
                        cmdInsert.Parameters.Add(parameterStrDeleted);
                        cmdInsert.Parameters.Add(parameterStrBox);

                        conn.Open();
                        //cmdInsert.ExecuteNonQuery();
                        int n = (int)cmdInsert.ExecuteNonQuery();//执行SQL命令
                        conn.Close();

                        if (n > 0)//data insert结果判断
                        {
                            //MessageBox.Show("Insert Successful", "Hint",//弹出消息对话框
                            //MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //return;//退出事件

                            //select insert读取到dataset
                            string strSelect = "select * from Tek733Package where Serial='" + textBox1.Text + "'";
                            SqlCommand cmd = new SqlCommand(strSelect, conn);//创建命令对象
                            //operate.SelectData(strSelect);
                            conn.Open();
                            cmd.ExecuteScalar();
                            SqlDataAdapter da = new SqlDataAdapter(cmd); //创建DataAdapter数据适配器实例
                            DataSet dsDataGridView = new DataSet();//创建DataSet实例
                            da.Fill(dsDataGridView);
                            conn.Close();

                            //从dataset读取到datagridview
                            //string strDGID = dsDataGridView.Tables[0].Rows[0]["ID"].ToString();
                            //string strDGDateTested = dsDataGridView.Tables[0].Rows[0]["DateTested"].ToString();
                            string strDGDatePackage = dsDataGridView.Tables[0].Rows[0]["DatePackage"].ToString();
                            string strDGTekNum = dsDataGridView.Tables[0].Rows[0]["TekNum"].ToString();
                            string strDGBatchNum = dsDataGridView.Tables[0].Rows[0]["BatchNum"].ToString();
                            string strDGWeekNum = dsDataGridView.Tables[0].Rows[0]["WeekNum"].ToString();
                            string strDGSerial = dsDataGridView.Tables[0].Rows[0]["Serial"].ToString();
                            string strDGPhoneNum = dsDataGridView.Tables[0].Rows[0]["PhoneNum"].ToString();
                            string strDGIMEI = dsDataGridView.Tables[0].Rows[0]["IMEI"].ToString();
                            string strDGICCID = dsDataGridView.Tables[0].Rows[0]["ICCID"].ToString();
                            string strDGIMSI = dsDataGridView.Tables[0].Rows[0]["IMSI"].ToString();
                            string strDGFirmwareVer = dsDataGridView.Tables[0].Rows[0]["FirmwareVer"].ToString();
                            string strDGBatteryVoltage = dsDataGridView.Tables[0].Rows[0]["BatteryVoltage"].ToString();
                            string strDGTestPC = dsDataGridView.Tables[0].Rows[0]["TestPC"].ToString();
                            string strDGSettingsProfile = dsDataGridView.Tables[0].Rows[0]["SettingsProfile"].ToString();
                            string strDGDeleted = dsDataGridView.Tables[0].Rows[0]["Deleted"].ToString();
                            string strDGBox = dsDataGridView.Tables[0].Rows[0]["Box"].ToString();
                            string[] row = { 
                                           //strDGID, strDGDateTested,
                                           strDGDatePackage, strDGTekNum, strDGBatchNum, strDGWeekNum, strDGSerial, strDGPhoneNum, strDGIMEI, strDGICCID, strDGIMSI, strDGFirmwareVer, strDGBatteryVoltage, strDGTestPC, strDGSettingsProfile, strDGDeleted, strDGBox };
                            //给dataGridViewScan控件添加数据
                            dataGridView1.Rows.Add(row);
                            //datagridview显示排序-降序,按照第1列排序
                            this.dataGridView1.Sort(this.dataGridView1.Columns[0], ListSortDirection.Descending);
                        }
                        else
                        {
                            MessageBox.Show("数据插入失败", "提示",//弹出消息对话框
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;//退出事件
                        }
                    }
                }
                textBox1.Text = "";
                textBox1.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string importPath = "";
            string exportPath = string.Format("{0}\\",
                Application.StartupPath);
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Access文件|*.mdb";
            folderBrowserDialog1.SelectedPath = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                importPath = openFileDialog1.FileName;
                folderBrowserDialog1.SelectedPath = exportPath;

                string tem_Dfile = importPath;
                tem_Dfile = tem_Dfile.Substring(tem_Dfile.LastIndexOf("\\") + 1, tem_Dfile.Length - tem_Dfile.LastIndexOf("\\") - 1);
                tem_Dfile = exportPath + "\\" + tem_Dfile;
                CopyFile(importPath, tem_Dfile, 1024);
            }
        }

        FileStream FormerOpen;
        FileStream ToFileOpen;
        /// <summary>
        /// 文件的复制
        /// </summary>
        /// <param FormerFile="string">源文件路径</param>
        /// <param toFile="string">目的文件路径</param> 
        /// <param SectSize="int">传输大小</param> 
        /// <param progressBar="ProgressBar">ProgressBar控件</param> 
        public void CopyFile(string FormerFile, string toFile, int SectSize)
        {
            FileStream fileToCreate = new FileStream(toFile, FileMode.Create);		//创建目的文件，如果已存在将被覆盖
            fileToCreate.Close();										//关闭所有资源
            fileToCreate.Dispose();										//释放所有资源
            FormerOpen = new FileStream(FormerFile, FileMode.Open, FileAccess.Read);//以只读方式打开源文件
            ToFileOpen = new FileStream(toFile, FileMode.Append, FileAccess.Write);	//以写方式打开目的文件
            //根据一次传输的大小，计算传输的个数
            int FileSize;												//要拷贝的文件的大小
            //如果分段拷贝，即每次拷贝内容小于文件总长度
            if (SectSize < FormerOpen.Length)
            {
                byte[] buffer = new byte[SectSize];							//根据传输的大小，定义一个字节数组
                long copied = 0;										//记录传输的大小
                while (copied <= FormerOpen.Length - SectSize)			//拷贝主体部分
                {
                    FileSize = FormerOpen.Read(buffer, 0, SectSize);			//从0开始读，每次最大读SectSize
                    FormerOpen.Flush();								//清空缓存
                    ToFileOpen.Write(buffer, 0, SectSize);					//向目的文件写入字节
                    ToFileOpen.Flush();									//清空缓存
                    ToFileOpen.Position = FormerOpen.Position;				//使源文件和目的文件流的位置相同
                    copied += FileSize;									//记录已拷贝的大小
                }
                int left = (int)(FormerOpen.Length - copied);						//获取剩余大小
                FileSize = FormerOpen.Read(buffer, 0, left);					//读取剩余的字节
                FormerOpen.Flush();									//清空缓存
                ToFileOpen.Write(buffer, 0, left);							//写入剩余的部分
                ToFileOpen.Flush();									//清空缓存
            }
            //如果整体拷贝，即每次拷贝内容大于文件总长度
            else
            {
                byte[] buffer = new byte[FormerOpen.Length];				//获取文件的大小
                FormerOpen.Read(buffer, 0, buffer.Length);			//读取源文件的字节XX INT
                FormerOpen.Flush();									//清空缓存
                ToFileOpen.Write(buffer, 0, buffer.Length);			//写放字节XX INT
                ToFileOpen.Flush();									//清空缓存
            }
            FormerOpen.Close();										//释放所有资源
            ToFileOpen.Close();										//释放所有资源
            //MessageBox.Show("文件导入完成");
            if (MessageBox.Show("文件导入完成!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                textBox1.Focus();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    button1.Focus();
                    button1.PerformClick();
                    e.Handled = true;
                }
        }
        
        private void Frm_Main_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void radioButtonRecount_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要从第一箱开始计数?", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                textBox1.Focus();
            }
            else
            {
                radioButtonRecount.Checked = false;
                textBox1.Focus();
            }
        }
    }
}
