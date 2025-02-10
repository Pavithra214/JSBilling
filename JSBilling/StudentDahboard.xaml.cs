using JSBilling.BL;
using JSBilling.Model;
using System.Windows;
using System.Windows.Media;
using Microsoft.Data.SqlClient;

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
            StudentDash ostudentdash = new();
            Student ostud = ostudentdash.GetStudent(email, password);

            txtname.Text = ostud.Name;
            txtemail.Text = ostud.email;
            pbpwd.Text = ostud.password;
            userid = ostud.Id;





            //Disable the Check-in

            StudentDash dash = new();
            Student ostudent = new Student();
            ostudent.email = email;
            ostudent.password = password;

            object value = dash.DisableCheckin(ostudent);
            int count = (int)value;
            btncheckin.Background = Brushes.Yellow;
            if (count > 0)
            {

                btncheckin.IsEnabled = false;

            }

        }








        private void btnsave_Click(object sender, RoutedEventArgs e)
        {
            StudentDash dash=new StudentDash();
            Student ostudent=new Student();
            ostudent.Id=Convert.ToInt32(userid);
            ostudent.Name=txtname.Text;
            ostudent.email=txtemail.Text;
            ostudent.password=pbpwd.Text;
            dash.UpdateStudent(ostudent);

               
            MessageBox.Show("Updated succesfully");
           
        }

        private void btncheckin_Click(object sender, RoutedEventArgs e)
        {
            StudentDash studentDash = new StudentDash();
            studentDash.Checkin(rdbnotesyes.IsChecked, rdbdemodone.IsChecked, rdbprojdone.IsChecked, Convert.ToInt16(userid));
           
          
            MessageBox.Show("Inserted successfully");
        }
    }
}
