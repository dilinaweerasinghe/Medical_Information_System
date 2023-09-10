using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Xml.Linq;

namespace RAD
{
    /// <summary>
    /// Interaction logic for Admin_AddNew.xaml
    /// </summary>
    public partial class Admin_AddAdmin : Window
    {
        public Admin_AddAdmin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=ASUS;Initial Catalog=UOR_MedicalCenterDB; Integrated Security=True;");
            try
            {
                connection.Open();
                SqlCommand Query = new SqlCommand("INSERT INTO users(username, firstname, lastname, mobile, address, email, password, type) VALUES (@USERNAME, @FIRSTNAME, @LASTNAME, @MOBILE, @ADDRESS, @EMAIL, @PASSWORD, @TYPE)", connection);
                Query.Parameters.AddWithValue("@USERNAME", txtUsername.Text);
                Query.Parameters.AddWithValue("@FIRSTNAME", txtFirstname.Text);
                Query.Parameters.AddWithValue("@LASTNAME", txtLastname.Text);
                Query.Parameters.AddWithValue("@MOBILE", txtMobile.Text);
                Query.Parameters.AddWithValue("@ADDRESS", txtAddress.Text);
                Query.Parameters.AddWithValue("@EMAIL", txtEmail.Text);
                Query.Parameters.AddWithValue("@PASSWORD", txtPassword.Text);
                Query.Parameters.AddWithValue("@TYPE", "admin");
                Query.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Successfully Saved!");
                txtUsername.Text = "";
                txtFirstname.Text = "";
                txtLastname.Text = "";
                txtAddress.Text = "";
                txtMobile.Text = "";
                txtPassword.Text = "";
                txtCpassword.Text = "";
                txtEmail.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Admin_DisplayAdmin admin_DisplayAdmin = new Admin_DisplayAdmin();
            admin_DisplayAdmin.Show();
        }
    }
}
