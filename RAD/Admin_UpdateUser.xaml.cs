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
    /// Interaction logic for Admin_Update.xaml
    /// </summary>
    public partial class Admin_UpdateUser : Window
    {
        private int userID;
        SqlConnection connection = new SqlConnection(@"Data Source=ASUS;Initial Catalog=UOR_MedicalCenterDB; Integrated Security=True;");

        public Admin_UpdateUser(int userID)
        {
            InitializeComponent();
            this.Left = 100;
            this.Top = 100;
            this.userID = userID;
            retriveUser();
        }

        private void retriveUser()
        {
            try
            {
                connection.Open();
                SqlCommand Query = new SqlCommand("SELECT username, firstname, lastname, mobile, address, email FROM users WHERE Id = @USERID", connection);
                Query.Parameters.AddWithValue("@USERID", this.userID);
                SqlDataReader reader = Query.ExecuteReader();
                if(reader.Read())
                {
                    txtUsername.Text = reader["username"].ToString();
                    txtFirstname.Text = reader["firstname"].ToString();
                    txtLastname.Text = reader["lastname"].ToString();
                    txtMobile.Text = reader["mobile"].ToString();
                    txtAddress.Text = reader["address"].ToString();
                    txtEmail.Text = reader["email"].ToString();
                }
                else
                {
                    MessageBox.Show("User not found.");
                }
                reader.Close();
                connection.Close();
            }
            catch { }
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                connection.Open();
                SqlCommand Query = new SqlCommand("UPDATE users SET username=@USERNAME, firstname = @FIRSTNAME, lastname = @LASTNAME, mobile = @MOBILE, address = @ADDRESS, email = @EMAIL  WHERE ID=@USERID", connection);
                Query.Parameters.AddWithValue("@USERNAME", txtUsername.Text);
                Query.Parameters.AddWithValue("@FIRSTNAME", txtFirstname.Text);
                Query.Parameters.AddWithValue("@LASTNAME", txtLastname.Text);
                Query.Parameters.AddWithValue("@MOBILE", txtMobile.Text);
                Query.Parameters.AddWithValue("@ADDRESS", txtAddress.Text);
                Query.Parameters.AddWithValue("@EMAIL", txtEmail.Text);
                Query.Parameters.AddWithValue("@USERID", userID);
                Query.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Successfully Updated!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

            this.Hide();
            Admin_DisplayAdmin admin_DisplayAdmin = new Admin_DisplayAdmin();
            admin_DisplayAdmin.Show();

        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Admin_DisplayAdmin admin_DisplayAdmin = new Admin_DisplayAdmin();
            admin_DisplayAdmin.Show();
        }
    }
}
