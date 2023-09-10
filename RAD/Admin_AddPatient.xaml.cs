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
    /// Interaction logic for Admin_AddPatient.xaml
    /// </summary>
    public partial class Admin_AddPatient : Window
    {
        SqlConnection connection = new SqlConnection(@"Data Source=ASUS;Initial Catalog=UOR_MedicalCenterDB; Integrated Security=True;");

        public Admin_AddPatient()
        {
            InitializeComponent();
        }

        private void btn_addPatient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                connection.Open();
                SqlCommand Query = new SqlCommand("INSERT INTO patients(firstname, lastname, date_of_birth, address, reg_no, contact, emergency_contact, long_term_diseases, allergy, faculty) VALUES " + "( @FIRSTNAME, @LASTNAME, @DOB, @ADDRESS, @REGNO, @CONTACT, @ECONTACT, @DISEASE, @ALLERGY, @FACULTY)", connection);
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
                Query.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Successfully Saved!");
                txtFirstname.Text = "";
                txtLastname.Text = "";
                txtAddress.Text = "";
                picker_dob.Text = "";
                txtAddress.Text = "";
                txtContact.Text = "";
                txtEmergencyContact.Text = "";
                txtDisease.Text = "";
                txtAllergy.Text = "";
                cmbFaculty.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Admin_DisplayPatient admin_DisplayPatient = new Admin_DisplayPatient();
            admin_DisplayPatient.Show();
        }
    }
}
