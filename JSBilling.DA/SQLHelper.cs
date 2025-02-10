using Microsoft.Data.SqlClient;
using System.Data;
namespace JSBilling.DA
    
{
    public class SQLHelper
    {
        public readonly string ConnectionString;

        public SQLHelper()
        {
            ConnectionString = "Server=tcp:jsquare1.database.windows.net,1433;Initial Catalog=jscollege;Persist Security Info=False;User ID=jsquare;Password=Welcome@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public int SqlExecuteNonQuery(String sqlQuery, SqlParameter[] parameters)
        {
            int output;
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    cmd.Parameters.AddRange(parameters);
                    output = cmd.ExecuteNonQuery();

                }
                conn.Close();
            }
            return output;
        }

        public object SqlExecuteScalar(String sqlQuery, SqlParameter[] parameters = null)
        {
            object output;
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    output = cmd.ExecuteScalar();
                }
                conn.Close();
            }

            return output;
        }

        public SqlDataReader SqlDataRead(String sqlQuery, SqlParameter[] parameters = null)
        {
            SqlDataReader output;
            SqlConnection conn = GetConnection();

            conn.Open();
            using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                output = cmd.ExecuteReader();
            }

            return output;
        }

        public DataSet SqlDataset(String sqlQuery, SqlParameter[] parameters = null)
        {
            DataSet output = new DataSet();
            SqlConnection conn = GetConnection();

            conn.Open();
            using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

               SqlDataAdapter oda=new SqlDataAdapter(cmd);
                oda.Fill(output);
            }

            return output;
        }

    }
}
