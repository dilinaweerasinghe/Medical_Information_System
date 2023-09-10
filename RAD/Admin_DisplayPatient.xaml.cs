using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace RAD
{
    /// <summary>
    /// Interaction logic for Admin_Patient.xaml
    /// </summary>
    public partial class Admin_DisplayPatient : Window
    {
        SqlConnection connection = new SqlConnection(@"Data Source=ASUS;Initial Catalog=UOR_MedicalCenterDB; Integrated Security=True;");

        public Admin_DisplayPatient()
        {
            InitializeComponent();
            this.Left = 100;
            this.Top = 100;
            retrieveAll();
        }

        private void retrieveAll()
        {
            connection.Open();
            DataTable dataTable = new DataTable();
            SqlCommand Query = new SqlCommand("SELECT id, firstname, lastname, date_of_birth, reg_no, contact FROM Patients", connection);
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(Query);
            sqlAdapter.Fill(dataTable);
            admin_dataGrid.ItemsSource = dataTable.DefaultView;
            connection.Close();
        }

        private void ViewButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the selected user's ID from the DataGrid
            DataRowView selectedRow = (DataRowView)admin_dataGrid.SelectedItem;
            int userID = (int)selectedRow["id"];

            // Open a form for updating user data, passing the user ID
            Admin_ViewPatient admin_ViewPatient = new Admin_ViewPatient(userID);
            admin_ViewPatient.ShowDialog();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the selected user's ID from the DataGrid
            DataRowView selectedRow = (DataRowView)admin_dataGrid.SelectedItem;
            int userID = (int)selectedRow["id"];

            // Open a form for updating user data, passing the user ID
            Admin_UpdatePatient admin_UpdatePatient = new Admin_UpdatePatient(userID);
            admin_UpdatePatient.ShowDialog();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the selected user's ID from the DataGrid
            DataRowView selectedRow = (DataRowView)admin_dataGrid.SelectedItem;
            int userID = (int)selectedRow["id"];

            // Show a confirmation dialog before deleting
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this user?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    connection.Open();
                    SqlCommand Query = new SqlCommand("DELETE Patients WHERE ID=@USERID", connection);
                    Query.Parameters.AddWithValue("@USERID", userID);
                    Query.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Successfully Deleted!");
                    retrieveAll();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void btn_addPatient_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Admin_AddPatient admin_AddPatient = new Admin_AddPatient();
            admin_AddPatient.Show();
        }

        private void btn_Back_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Admin_Dashboard admin_Dashboard = new Admin_Dashboard();
            admin_Dashboard.ShowDialog();
        }
    }
}
