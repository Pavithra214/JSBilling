using System.Windows;
using System.Windows.Controls;
using Microsoft.Data.SqlClient;
namespace JSBilling
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnregister_Click(object sender, RoutedEventArgs e)
        {
            int role = 1;
            string ans = cmbregister.Text;
            if (ans == "Staff")
            {
                role = 1;
            }
            else
            {
                role = 2;
            }
            //sql connection
            string sql = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=JS;Data Source=DESKTOP-10MGO6D\\SQLEXPRESS;Encrypt=False\r\n";
            SqlConnection sqlConnection = new SqlConnection(sql);
            sqlConnection.Open();

            //sql command
            string query = $"INSERT INTO Reg VALUES('{txtregname.Text}',{txtphone.Text},'{txtregemail.Text}','{pbregpwd.Password}',{role})";
            SqlCommand ocmd = new SqlCommand(query,sqlConnection);
           
            int i=ocmd.ExecuteNonQuery();
            MessageBox.Show("Congratulations! The registration is successful");
            sqlConnection.Close();
        }

        private void btnlogin_Click(object sender, RoutedEventArgs e)
        {
            int role = 1;
            ComboBoxItem item = (ComboBoxItem)cmblogin.SelectedItem;
            if(item.Content.ToString()=="Staff")
            {
                role = 1;
            }
            else
            {
                role = 2;
            }
            string sql = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=JS;Data Source=DESKTOP-10MGO6D\\SQLEXPRESS;Encrypt=False\r\n";
            SqlConnection sqlConnection = new SqlConnection(sql);
            sqlConnection.Open();
            string query = $"SELECT COUNT(*) FROM Reg WHERE EmailId='{txtloginemail.Text}' AND Password='{pbloginpwd.Password}' AND Role={role}";
             SqlCommand sqlCommand = new SqlCommand(query,sqlConnection);
            int i=(int)sqlCommand.ExecuteScalar();
            if(i>=1)
            {
                if(role==1)
                {
                    AdminDashboard admin=new AdminDashboard();
                    admin.Show();
                    this.Close();
                    MessageBox.Show("Login success");
                }
                else
                {
                    StudentDahboard student = new StudentDahboard(txtloginemail.Text,pbloginpwd.Password);
                    student.Show();
                    this.Close();
                }
                
            }
            else
            {
                MessageBox.Show("Login failed");
            }
        }
    }
}