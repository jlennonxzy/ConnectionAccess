using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ConnectionAccess.Common_Class
{
    class SqlOperate
    {
        SqlConnection conn = SqlCon.MyConnection();//得到数据库连接对象
        DataSet ds;//需添加data引用
        //SqlDataAdapter da;// = new SqlDataAdapter();
        /// <summary>
        /// 操作数据库，执行各种SQL语句
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <returns>方法返回受影响的行数</returns>
        public int OperateData(string strSql)
        {
            conn.Open();//打开数据库连接
            SqlCommand cmd = new SqlCommand(strSql, conn);//创建命令对象
            int i = (int)cmd.ExecuteNonQuery();//执行SQL命令
            conn.Close();//关闭数据库连接
            return i;//返回数值
        }

        /// <summary>
        /// 查找指定数据表的人数
        /// </summary>
        /// <param name="strsql">SQL语句</param>
        /// <returns>方法返回指定记录的数量</returns>
        public int SelectData(string strsql)
        {
            conn.Open();//打开数据库连接
            SqlCommand cmd = new SqlCommand(strsql, conn);//创建命令对象
            int i = (int)cmd.ExecuteScalar();//执行SQL命令
            conn.Close();//关闭数据库连接
            return i;//返回数值
        }

        public DataSet getDs(string strsql)
        {
            conn.Open();//打开数据库连接
            SqlCommand cmd = new SqlCommand(strsql, conn);//创建命令对象
            ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            conn.Close();
            return ds;
        }
    }
}
