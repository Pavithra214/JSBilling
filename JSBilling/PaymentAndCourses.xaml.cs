using Microsoft.Data.SqlClient;
using System.Data;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;

namespace JSBilling
{
    /// <summary>
    /// Interaction logic for PaymentAndCourses.xaml
    /// </summary>
    public partial class PaymentAndCourses : Window
    {
        public PaymentAndCourses()
        {
            InitializeComponent();
            string sql = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=JS;Data Source=DESKTOP-10MGO6D\\SQLEXPRESS;Encrypt=False\r\n";
            using (SqlConnection sqlConnection = new SqlConnection(sql))
            {
                sqlConnection.Open();
                string query = "select distinct coursename from COURSEDETAILS";
                SqlCommand ocmd = new SqlCommand(query, sqlConnection);
                using (SqlDataReader reader=ocmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        cmbcourse.Items.Add(reader.GetString(0));
                    }
                }
                    sqlConnection.Close();

            }

            //using (SqlConnection sqlConnection = new SqlConnection(sql))
            //{
            //    sqlConnection.Open();
            //    string query = "select FullName from Reg";
            //    SqlCommand ocmd = new SqlCommand(query, sqlConnection);
            //    using (SqlDataReader reader = ocmd.ExecuteReader())
            //    {
            //        while (reader.Read())
            //        {
            //            cmbstudpayment.Items.Add(reader.GetString(0));
            //        }
            //    }
            //    sqlConnection.Close();

            //}



        }

        private void cmbcourse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void cmbbatches_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string sql1 = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=JS;Data Source=DESKTOP-10MGO6D\\SQLEXPRESS;Encrypt=False\r\n";

            using (SqlConnection sqlConnection = new SqlConnection(sql1))
            {
                sqlConnection.Open();

                string batch = cmbbatches.Text;
                string cours = cmbcourse.Text;
                if (batch == "Batch1" && cours == "Azure developer")
                {
                    string query = "select timing from COURSEDETAILS where batches='batch1' AND CourseName='Azure Developer";
                    SqlCommand ocmd1 = new SqlCommand(query, sqlConnection);
                    ocmd1.ExecuteNonQuery();
                    txttime.Text = ocmd1.CommandText;
                }
                if (batch == "Batch2" && cours == "Azure developer")
                {
                    string query = "select timing from COURSEDETAILS where batches='batch2' AND CourseName='Azure Developer";
                    SqlCommand ocmd2 = new SqlCommand(query, sqlConnection);
                    ocmd2.ExecuteNonQuery();
                    txttime.Text = ocmd2.CommandText;
                }
                if (batch == "Batch1" && cours == "Full Stack Development")
                {
                    string query = "select timing from COURSEDETAILS where batches='batch1' AND CourseName='Full Stack Development";
                    SqlCommand ocmd3 = new SqlCommand(query, sqlConnection);
                    ocmd3.ExecuteNonQuery();
                    txttime.Text = ocmd3.CommandText;
                }
                if (batch == "Batch2" && cours == "Full Stack Development")
                {
                    string query = "select timing from COURSEDETAILS where batches='batch2' AND CourseName='Full Stack Development";
                    SqlCommand ocmd4 = new SqlCommand(query, sqlConnection);
                    ocmd4.ExecuteNonQuery();
                    txttime.Text = ocmd4.CommandText;
                }
                else
                {
                    string timing = "8:30";
                    txttime.Text = timing;
                }

                sqlConnection.Close();

            }
        }
    }
}
