using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ConnectionAccess.Common_Class
{
    class SqlCon
    {
        /// <summary>
        /// 返回数据库连接的静态方法
        /// </summary>
        /// <returns>方法返回数据库连接对象</returns>
        public static SqlConnection MyConnection()
        {
            return new SqlConnection(//创建数据库连接对象
@"server=.\;database=testdb;uid=sa;pwd=062455Xzy");//数据库连接字符串
        }
    }
}
