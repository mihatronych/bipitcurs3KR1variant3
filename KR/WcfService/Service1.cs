using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service1 : IService1
    {
        public string Delete(int k)
        {
            var path = "workstation id=epictable1.mssql.somee.com;packet size=4096;user id=Mihail12336_SQLLogin_1;pwd=1edtmfxeen;data source=epictable1.mssql.somee.com;persist security info=False;initial catalog=epictable1";
            var query = "DELETE FROM T1 WHERE K=@K";
            var str = "";
            using (var conn = new SqlConnection(path))
            {
                using (var cmd = new SqlCommand(query))
                {
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@K", k);
                    conn.Open();
                    str = "Изменено " + cmd.ExecuteNonQuery() + " строк в таблице T1";
                }
            }
            return str;
        }

        public string Insert(int k, DateTime cur, string author, string description)
        {
            var path = "workstation id=epictable1.mssql.somee.com;packet size=4096;user id=Mihail12336_SQLLogin_1;pwd=1edtmfxeen;data source=epictable1.mssql.somee.com;persist security info=False;initial catalog=epictable1";
            var query = "INSERT INTO T1(K, dt, author, descr)  values(@K, @dt, @author, @descr)";
            var str = "";
            using (var conn = new SqlConnection(path))
            {
                using (var cmd = new SqlCommand(query))
                {
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@K", k);
                    cmd.Parameters.AddWithValue("@dt", cur);
                    cmd.Parameters.AddWithValue("@author", author);
                    cmd.Parameters.AddWithValue("@descr", description);
                    conn.Open();
                    str = "Изменено " + cmd.ExecuteNonQuery() + " строк в таблице Outputs";
                }
            }
            return str;
        }

        public DataSet Select(DateTime before, DateTime after)
        {
            //ПЕРЕДЕЛАТЬ СЕРВЕР!!!
            var path = "workstation id=epictable1.mssql.somee.com;packet size=4096;user id=Mihail12336_SQLLogin_1;pwd=1edtmfxeen;data source=epictable1.mssql.somee.com;persist security info=False;initial catalog=epictable1";
            var query = "SELECT * FROM T1"; //WHERE T1.dt BETWEEN CONVERT(datetime, '" + after + "', 104) AND CONVERT(datetime, '" + before + "', 104)";
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(path))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.Fill(ds, "T1");
                ds.Tables["T1"].Columns[0].ColumnName = "Код";
                ds.Tables["T1"].Columns[1].ColumnName = "Дата и время";
                ds.Tables["T1"].Columns[2].ColumnName = "Автор";
                ds.Tables["T1"].Columns[3].ColumnName = "Описание";
            }
            return ds;
        }

        public string Update(int k, DateTime cur, string author, string description)
        {
            var path = "workstation id=epictable1.mssql.somee.com;packet size=4096;user id=Mihail12336_SQLLogin_1;pwd=1edtmfxeen;data source=epictable1.mssql.somee.com;persist security info=False;initial catalog=epictable1";
            var query = "UPDATE T1 SET [dt]=@dt, [author]=@author, [descr]=@descr WHERE K=@K";
            var str = "";
            using (var conn = new SqlConnection(path))
            {
                using (var cmd = new SqlCommand(query))
                {
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@K", k);
                    cmd.Parameters.AddWithValue("@dt", cur);
                    cmd.Parameters.AddWithValue("@author", author);
                    cmd.Parameters.AddWithValue("@descr", description);
                    conn.Open();
                    str = "Изменено " + cmd.ExecuteNonQuery() + " строк в таблице Outputs";
                }
            }
            return str;
        }
    }
}
