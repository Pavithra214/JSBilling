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
    /// Interaction logic for AdminDashboard.xaml
    /// </summary>
    public partial class AdminDashboard : Window
    {
        public AdminDashboard()
        {
            InitializeComponent();
            string sql = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=JS;Data Source=DESKTOP-10MGO6D\\SQLEXPRESS;Encrypt=False\r\n";
            SqlConnection sqlConnection = new SqlConnection(sql);
            sqlConnection.Open();
            string query = "Select * from StudentDetails";
            SqlCommand ocmd=new SqlCommand(query, sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(ocmd);
            DataSet set = new DataSet();
            adapter.Fill(set);
            lststudent.ItemsSource = set.Tables[0].DefaultView;
            sqlConnection.Close();
        }
    }
}
