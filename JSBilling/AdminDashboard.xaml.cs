using JSBilling.BL;
using JSBilling.Model;
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

            AdminDash adminDash = new AdminDash();
            string query = "Select * from StudentDetails";
            List<Admin> list=adminDash.getCheckindata(query);
            lststudent.ItemsSource = list;
           
        }

        private void btnpaycourse_Click(object sender, RoutedEventArgs e)
        {
           

        }
    }
}
