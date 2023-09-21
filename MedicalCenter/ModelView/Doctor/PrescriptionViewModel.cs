using MedicalCenter.Model.Doctor;
using MedicalCenter.View.Doctor;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MedicalCenter.ModelView.Doctor
{
    public class PrescriptionViewModel : ModelBase
    {
        private string _imageURL;
        private string _username = "dilina123";
        private string _name = "Dilina Weerasinghe";
        private Patient _patient;
        private string _drug;
        private string _unit;
        private string _dosage;
        private string _diagnosed;
        private ObservableCollection<Drugdetails> _drugdetails;

        public ObservableCollection<Drugdetails> Drugdetails
        {
            get { return _drugdetails; }
            set { SetProperty(ref _drugdetails, value); }
        }
        public string ImageURL
        {
            get { return _imageURL; }
            set { SetProperty(ref _imageURL, value);}
        }

        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); OnPropertyChanged(nameof(Username)); }
        }

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); OnPropertyChanged(nameof(Name)); }
        }

        public Patient Patient
        {
            get { return _patient; }
            set { _patient = value; OnPropertyChanged(nameof(Patient)); }
        }
        public string DrugToAdd
        {
            get { return _drug; }
            set { SetProperty(ref _drug, value); OnPropertyChanged(nameof(DrugToAdd)); }
        }
        public string UnitToAdd
        {
            get { return _unit; }
            set { SetProperty(ref _unit, value); OnPropertyChanged(nameof(UnitToAdd)); }
        }
        public string DosageToAdd
        {
            get { return _dosage; }
            set { SetProperty(ref _dosage, value); OnPropertyChanged(nameof(DosageToAdd)); }
        }

        public string Diagnosed
        {
            get
            {
                return _diagnosed;
            }
            set
            {
                SetProperty(ref _diagnosed, value); OnPropertyChanged(nameof(Diagnosed));
            }
        }

        public ObservableCollection<Prescription> Prescriptions { get; } = new ObservableCollection<Prescription>();
        public DelegateCommand AddPrescriptionCommand { get; }
        public DelegateCommand<Drugdetails> DeletePrescriptionCommand { get; }
        public ICommand BackButtonCommand { get; } 

        public PrescriptionViewModel()
        {
            Drugdetails = new ObservableCollection<Drugdetails> { };
            AddPrescriptionCommand = new DelegateCommand(AddPrescription);
            DeletePrescriptionCommand = new DelegateCommand<Drugdetails>(DeletePrescription);
            BackButtonCommand = new RelayCommand(CanExcuteBackButton, ExecuteBackButton);
        }

        private bool ExecuteBackButton(object obj)
        {
            return true;
        }

        private void CanExcuteBackButton(object obj)
        {
            throw new NotImplementedException();
        }

        private void DeletePrescription(Drugdetails drugdetails)
        {
            Drugdetails.Remove(drugdetails);
        }

        private void AddPrescription()
        {
            
            var newItem = new Drugdetails()
            {
                Drug = DrugToAdd,
                Unit = UnitToAdd,
                Dosage = DosageToAdd,


            };

            Drugdetails.Add(newItem);

            // Clear the input fields
            DrugToAdd = string.Empty;
            UnitToAdd = string.Empty;
            DosageToAdd = string.Empty;
        }
    
    }
}
