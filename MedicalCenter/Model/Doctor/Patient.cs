using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenter.Model.Doctor
{
    public class Patient
    {
        private string _studentId;
        private string _name;
        private int _age;
        private string _gender;
        private DateTime date;

        public string StudentId
        {
            get { return _studentId; }
            set { _studentId = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }


        

    }
}
