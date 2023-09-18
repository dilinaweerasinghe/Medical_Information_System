using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenter.Model
{
    public class User
    {
        private string username;
        private SecureString password;
        private string loginType;

        public string Username { get => username; set => username = value; }
        public SecureString Password { get => password; set => password = value; }
        public string LoginType { get => loginType; set => loginType = value; }

        public static implicit operator User(ObservableCollection<User> v)
        {
            throw new NotImplementedException();
        }
    }
}
