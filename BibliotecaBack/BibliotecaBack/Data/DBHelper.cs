using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Data
{
    public class DBHelper
    {
        private static DBHelper instance = null;
        private SqlConnection conn;

        private DBHelper()
        {
            conn = new SqlConnection(@"Data Source=DESKTOP-PONN3N6;Initial Catalog=TpProg;Integrated Security=True");
        }

        public static DBHelper GetInstance()
        {
            if (instance == null)
                instance = new DBHelper();
            return instance;
        }
        public SqlConnection GetConnection()
        {
            return conn;
        }

        public DataTable Consultar(string nombreSP, List<SqlParameter>? parameters = null)
        {
            conn.Open();
            SqlCommand comand = new SqlCommand();
            comand.Connection = conn;
            comand.CommandType = CommandType.StoredProcedure;
            comand.CommandText = nombreSP;

            if (parameters != null)
            {
                foreach (var param in parameters)
                    comand.Parameters.AddWithValue(param.ParameterName, param.Value);
            }

            DataTable table = new DataTable();
            table.Load(comand.ExecuteReader());
            conn.Close();
            return table;
        }


        
    }
}
