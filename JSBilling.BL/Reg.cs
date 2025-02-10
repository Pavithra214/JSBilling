using JSBilling.DA;
using JSBilling.Model;
using Microsoft.Data.SqlClient;
namespace JSBilling.BL
{
    public class Reg
    {
        private readonly SQLHelper DatabaseHelper;

        public Reg()
        {
            DatabaseHelper = new SQLHelper();
        }
        public int Register(Student student)
        {
            string sqlquery = $"INSERT INTO Reg VALUES(@name,@phone,@email,@password,@role)";
            SqlParameter[] sp =
                {
                new SqlParameter("@name",student.Name),
                new SqlParameter("phone",student.phone),
                new SqlParameter("@email",student.email),
                new SqlParameter("@password",student.password),
                new SqlParameter("@role",student.role)
        };
            return DatabaseHelper.SqlExecuteNonQuery(sqlquery, sp);
        }


        public object LoginCheck(Student student)
        {
            string sqlquery = "select count(*) from Reg where EmailId=@email and Password=@password and Role=@role";
            SqlParameter[] parameters =
            {
new SqlParameter("@email",student.email),
new SqlParameter("@password",student.password),
new SqlParameter("@role",student.role)
            };
            return DatabaseHelper.SqlExecuteScalar(sqlquery, parameters);
        }
    }
}
