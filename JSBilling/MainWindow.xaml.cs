using System.Windows;
using System.Windows.Controls;

using JSBilling.Model;
using Microsoft.Data.SqlClient;
using JSBilling.BL;
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

        private TextBox GetTxtphone()
        {
            return txtphone;
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

           Reg oreg=new Reg();
            Student ostudent = new Student();
            ostudent.Name = txtregname.Text;
            ostudent.phone = Convert.ToInt64(txtphone.Text);
            ostudent.email = txtregemail.Text;
            ostudent.password = pbregpwd.Password;
            ostudent.role = role;
            int i =oreg.Register(ostudent);
            if(i>=1)
            {
                MessageBox.Show("Congratulations! The registration is successful!");
            }
            else
            {
                MessageBox.Show("The registration failed!");
            }

            //sql connection
            //string sql = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=JS;Data Source=DESKTOP-10MGO6D\\SQLEXPRESS;Encrypt=False\r\n";
            //SqlConnection sqlConnection = new SqlConnection(sql);
            //sqlConnection.Open();

            ////sql command
            //string query = $"INSERT INTO Reg VALUES('{txtregname.Text}',{txtphone.Text},'{txtregemail.Text}','{pbregpwd.Password}',{role})";
            //SqlCommand ocmd = new SqlCommand(query,sqlConnection);
           
            //int i=ocmd.ExecuteNonQuery();
           
            //sqlConnection.Close();
        }

        private void btnlogin_Click(object sender, RoutedEventArgs e)
        {
            int role = 1;
            ComboBoxItem item = (ComboBoxItem)cmblogin.SelectedItem;
            if (item.Content.ToString() == "Staff")
            {
                role = 1;
            }
            else
            {
                role = 2;
            }
            //string sql = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=JS;Data Source=DESKTOP-10MGO6D\\SQLEXPRESS;Encrypt=False\r\n";
            //SqlConnection sqlConnection = new SqlConnection(sql);
            //sqlConnection.Open();
            //string query = $"SELECT COUNT(*) FROM Reg WHERE EmailId='{txtloginemail.Text}' AND Password='{pbloginpwd.Password}' AND Role={role}";
            // SqlCommand sqlCommand = new SqlCommand(query,sqlConnection);
            Reg loginAndReg = new();
            Student ostudent = new();
            ostudent.email = txtloginemail.Text;
            ostudent.password = pbloginpwd.Password;
            ostudent.role = role;
            int i = (int)loginAndReg.LoginCheck(ostudent);
            if (i >= 1)
            {
                if (role == 1)
                {
                    AdminDashboard admin = new AdminDashboard();
                    admin.Show();
                    this.Close();
                    MessageBox.Show("Login success");
                }
                else
                {
                    StudentDahboard studentpage = new StudentDahboard(txtloginemail.Text, pbloginpwd.Password);
                    studentpage.Show();
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