using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JSBilling.DA;
using JSBilling.Model;
using System.Xml.Linq;
using System.Reflection.Metadata;

namespace JSBilling.BL
{
    public class StudentDash
    {
        private readonly SQLHelper databaseHelper;

        public StudentDash()
        {
            databaseHelper = new SQLHelper();
        }
        public int Checkin(bool? notes, bool? demo, bool? project, int? userid)
        {
            
            int notesv = notes == true ? 1 : 0;
            int demov = notes == true ? 1 : 0;
            int projv = notes == true ? 1 : 0;

            string query = "INSERT INTO StudentActivity values(@date,@notes,@demo,@proj,@userid)";
            SqlParameter[] parameters =
            {
 new SqlParameter("@date", DateTime.Now.Date),
            new SqlParameter("@notes", notesv),
            new SqlParameter("@demo", demov),
            new SqlParameter("@proj", projv),
            new SqlParameter("@userid", userid)
        };
            return databaseHelper.SqlExecuteNonQuery(query, parameters);
        }

        public int UpdateStudent(Student student)
        {
           

            //sql command
            string query = "UPDATE Reg set FullName=@name,EmailId=@emailid,Password=@password WHERE Id=@userid";
            SqlParameter[] parameter = {
            
new SqlParameter("@name", student.Name),
            new SqlParameter("@emailid", student.email),
            new SqlParameter("@password", student.password),
            new SqlParameter("@userid", student.Id)
            };
           
           return databaseHelper.SqlExecuteNonQuery(query, parameter);
        }


        public object DisableCheckin(Student student)
        {
            string sqlquery = "Select count(*) from STUDENTCHECKIN WHERE emailid=@email and password=@password and checkin=@checkin";

            SqlParameter[] parameters =
            {
new SqlParameter("@email",student.email),
new SqlParameter("@password",student.password),
new SqlParameter("@Checkin",DateTime.Now.Date)
            };
            return databaseHelper.SqlExecuteScalar(sqlquery, parameters);
        }

        public Student GetStudent(string email, string password)
        {
            Student student = new Student();
            string query = "SELECT * FROM Reg WHERE EmailId=@email AND Password=@password";
            SqlParameter[] parameters =
                        {
new SqlParameter("@email",email),
new SqlParameter("@password",password)

            };
            SqlDataReader reader = databaseHelper.SqlDataRead(query, parameters);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    student.email = reader.GetString(3);
                    student.password = reader.GetString(4);
                    long phid = (long)reader.GetDecimal(2);
                    student.phone = phid;
                    student.Name = reader.GetString(1);
                    int id = (int)reader.GetDecimal(0);
                    student.Id = id;
                }
            }
            return student;
        }
    }
}
