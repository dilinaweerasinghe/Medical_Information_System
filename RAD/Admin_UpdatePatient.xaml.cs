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

namespace RAD
{
    /// <summary>
    /// Interaction logic for Admin_UpdatePatient.xaml
    /// </summary>
    public partial class Admin_UpdatePatient : Window
    {
        private int userID;
        SqlConnection connection = new SqlConnection(@"Data Source=ASUS;Initial Catalog=UOR_MedicalCenterDB; Integrated Security=True;");
        public Admin_UpdatePatient(int userID)
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
                SqlCommand Query = new SqlCommand("SELECT firstname, lastname, date_of_birth, address, reg_no, contact, emergency_contact, long_term_diseases, allergy, faculty from patients WHERE Id = @USERID", connection);
                Query.Parameters.AddWithValue("@USERID", this.userID);
                SqlDataReader reader = Query.ExecuteReader();
                if (reader.Read())
                {
                    txtFirstname.Text = reader["firstname"].ToString();
                    txtLastname.Text = reader["lastname"].ToString();
                    picker_dob.Text = reader["date_of_birth"].ToString();
                    txtAddress.Text = reader["address"].ToString();
                    txtRegNo.Text = reader["reg_no"].ToString();
                    txtContact.Text = reader["contact"].ToString();
                    txtEmergencyContact.Text = reader["emergency_contact"].ToString();
                    txtDisease.Text = reader["long_term_diseases"].ToString();
                    txtAllergy.Text = reader["allergy"].ToString();
                    cmbFaculty.Text = reader["faculty"].ToString();
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

        private void btnUpdatePatient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                connection.Open();
                SqlCommand Query = new SqlCommand("UPDATE patients SET firstname = @FIRSTNAME, lastname = @LASTNAME, date_of_birth = @DOB, address = @ADDRESS, reg_no = @REGNO, contact = @CONTACT, emergency_contact = @ECONTACT, long_term_diseases = @DISEASE, allergy = @ALLERGY, faculty = @FACULTY WHERE id = @USERID", connection);
                Query.Parameters.AddWithValue("@FIRSTNAME", txtFirstname.Text);
                Query.Parameters.AddWithValue("@LASTNAME", txtLastname.Text);
                Query.Parameters.AddWithValue("@DOB", picker_dob.Text);
                Query.Parameters.AddWithValue("@ADDRESS", txtAddress.Text);
                Query.Parameters.AddWithValue("@REGNO", txtRegNo.Text);
                Query.Parameters.AddWithValue("@CONTACT", txtContact.Text);
                Query.Parameters.AddWithValue("@ECONTACT", txtEmergencyContact.Text);
                Query.Parameters.AddWithValue("@DISEASE", txtDisease.Text);
                Query.Parameters.AddWithValue("@ALLERGY", txtAllergy.Text);
                Query.Parameters.AddWithValue("@FACULTY", cmbFaculty.Text);
                Query.Parameters.AddWithValue("@USERID", this.userID);
                Query.ExecuteNonQuery();
                connection.Close();
                this.Hide();
                Admin_DisplayPatient admin_DisplayPatient = new Admin_DisplayPatient();
                admin_DisplayPatient.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Admin_DisplayPatient admin_DisplayPatient = new Admin_DisplayPatient();
            admin_DisplayPatient.Show();
        }

    }
}
