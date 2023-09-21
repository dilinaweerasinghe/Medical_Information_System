using MedicalCenter.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenter.Model.Doctor
{
    public class Drugdetails: ModelBase
    {
        private String _drug;
        private String _unit;
        private String _dosage;

        public String Drug 
        { 
            get { return _drug; }
            set { SetProperty(ref _drug, value); }
        }
        public String Unit
        {
            get { return _unit; }
            set { SetProperty(ref _unit, value); }
        }    
        public String Dosage 
        {
            get { return _dosage; }
            set { SetProperty(ref _dosage, value); }
        }

    }
}
