using System;
using System.Collections.Generic;
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
    /// Interaction logic for Admin_Dashboard.xaml
    /// </summary>
    public partial class Admin_Dashboard : Window
    {
        public Admin_Dashboard()
        {
            InitializeComponent();
            this.Left = 100;
            this.Top = 100;
        }

        private void btn_admin_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Admin_DisplayAdmin admin_DisplayAdmin = new Admin_DisplayAdmin();
            admin_DisplayAdmin.Show();
        }

        private void btn_patient_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Admin_DisplayPatient admin_DisplayPatient = new Admin_DisplayPatient();
            admin_DisplayPatient.Show();
        }

        private void btn_medicalreport_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Admin_DisplayReport admin_DisplayReport = new Admin_DisplayReport();
            admin_DisplayReport.Show();
        }

        private void btn_Doctor_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Admin_DisplayDoctor admin_DisplayDoctor = new Admin_DisplayDoctor();
            admin_DisplayDoctor.Show();
        }

        private void btn_MedicalList_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Admin_DisplayMedicalList admin_DisplayMedicalList = new Admin_DisplayMedicalList();
            admin_DisplayMedicalList.Show();
        }

        private void btn_WaitingList_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Admin_DisplayWaitingList admin_DisplayWaitingList = new Admin_DisplayWaitingList();
            admin_DisplayWaitingList.Show();
        }
    }
}
