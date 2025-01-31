using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace JSBilling
{
    /// <summary>
    /// Interaction logic for StudentDahboard.xaml
    /// </summary>
    public partial class StudentDahboard : Window
    {
        object userid;
        public StudentDahboard(string email,string password)
        {
            InitializeComponent();
            string sql = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=JS;Data Source=DESKTOP-10MGO6D\\SQLEXPRESS;Encrypt=False\r\n";
            SqlConnection sqlConnection = new SqlConnection(sql);
            sqlConnection.Open();
            string query = "SELECT * FROM Reg WHERE EmailId=@email AND Password=@password";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("email", email);
            sqlCommand.Parameters.AddWithValue("@password", password);
            SqlDataReader reader= sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    txtname.Text = reader.GetString(1);
                    txtemail.Text = reader.GetString(3);
                    pbpwd.Text = reader.GetString(4);
                    userid=reader.GetValue(0);

                }
            }
            sqlConnection.Close();


            //Disable the Check-in
            SqlConnection sql1 = new SqlConnection(sql);
            sql1.Open();
            string squery = "Select count(*) from STUDENTCHECKIN1 WHERE emailid=@email and password=@password and checkin=@checkin";
            SqlCommand sqlCommand1 = new SqlCommand(squery, sql1);
            sqlCommand1.Parameters.AddWithValue("@email", email);
            sqlCommand1.Parameters.AddWithValue("@password", password);
            sqlCommand1.Parameters.AddWithValue("@checkin", DateTime.Now.Date);
            object value=sqlCommand1.ExecuteScalar();
            int count=(int)value;
            btncheckin.Background = Brushes.Yellow;
            if (count > 0)
            {
               
                btncheckin.IsEnabled=false;
           
            }
           sql1.Close();
        }


        

   
        


        private void btnsave_Click(object sender, RoutedEventArgs e)
        {
            string sql = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=JS;Data Source=DESKTOP-10MGO6D\\SQLEXPRESS;Encrypt=False\r\n";
            SqlConnection sqlConnection = new SqlConnection(sql);
            sqlConnection.Open();

            //sql command
            string query = "UPDATE Reg set FullName=@name,EmailId=@emailid,Password=@password WHERE Id=@userid";
            SqlCommand ocmd = new SqlCommand(query, sqlConnection);
            ocmd.Parameters.AddWithValue("@name",txtname.Text);
            ocmd.Parameters.AddWithValue("@emailid", txtemail.Text);
            ocmd.Parameters.AddWithValue("@password", pbpwd.Text);
            ocmd.Parameters.AddWithValue("@userid", userid);
            int i = ocmd.ExecuteNonQuery();
            MessageBox.Show("Updated succesfully");
            sqlConnection.Close();
        }

        private void btncheckin_Click(object sender, RoutedEventArgs e)
        {
            int notes = rdbnotesyes.IsChecked == true ? 1 : 0;
            int demo=rdbdemodone.IsChecked == true ? 1 : 0;
            int proj=rdbprojdone.IsChecked == true ? 1 : 0;
            string sql = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=JS;Data Source=DESKTOP-10MGO6D\\SQLEXPRESS;Encrypt=False\r\n";
            SqlConnection sqlConnection = new SqlConnection(sql);
            sqlConnection.Open();
            string query = "INSERT INTO StudentActivity values(@date,@notes,@demo,@proj,@userid)";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@date", DateTime.Now);
            command.Parameters.AddWithValue("@notes", notes);
            command.Parameters.AddWithValue("@demo", demo);
            command.Parameters.AddWithValue("@proj", proj);
            command.Parameters.AddWithValue("@userid", userid);
            int i= command.ExecuteNonQuery();
            MessageBox.Show("Inserted successfully");
        }
    }
}
