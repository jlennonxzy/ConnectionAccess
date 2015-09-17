using System;
using System.Data;
using System.Windows.Forms;
using ConnectionAccess.Common_Class;

namespace ConnectionAccess
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        SqlCon datacon = new SqlCon();
        SqlOperate dataoperate = new SqlOperate();
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text == "")
            {
                errorProName.SetError(textBoxName, "用户名不能为空!");
            }
            else
            {
                errorProName.Clear();
                string strSql = "select * from Login where loginName='" + textBoxName.Text + "' and Password='" + textBoxPassWord.Text + "'";
                DataSet ds = dataoperate.getDs(strSql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string strPermission = ds.Tables[0].Rows[0]["Permission"].ToString();
                    this.Hide();
                    if (strPermission == "package")
                    {
                        Frm_Main frmmain = new Frm_Main();
                        frmmain.Show();
                    }
                    else
                        if(strPermission=="dm")
                        {
                            Data_Mange datamange = new Data_Mange();
                            datamange.Show();
                        }
                    else
                    {
                        MessageBox.Show("错误的登陆用户，请使用正确的账号登陆！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //return;使用return会退到上一层不停循环，导致进程无法关闭
                        Application.Exit();
                    }
                }
                else
                {
                    MessageBox.Show("用户名或密码错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBoxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void textBoxPassWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //聚焦到按钮（一个Button）
                buttonLogin.Focus();
                //生成按钮的 Click 事件.该按钮的click操作一定要先定义好了。
                buttonLogin.PerformClick();
                e.Handled = true;  //一定不能少了这个命令，当回车后，会自动转到下一行，然后再执行click事件。如果没有这个命令，再下一次发送数据前，会多出一个空格。
            }
        }
    }
}
